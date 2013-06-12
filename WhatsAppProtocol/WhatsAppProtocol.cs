using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

public class WhatsAppProtocol
{
    public enum CONNECTION_STATUS
    {
        DISCONNECTED,
        CONNECTED
    }

    private AccountInfo accountinfo;
    public static bool DEBUG;
    private CONNECTION_STATUS loginStatus;
    private object messageLock = new object();
    private List<ProtocolTreeNode> messageQueue;
    private BinTreeNodeReader reader;
    private BinTreeNodeWriter writer;
    private int timeout = 5000;

    public WhatsNetwork whatsNetwork;
    public WhatsSendHandler WhatsSendHandler { get; private set; }
    public WhatsParser WhatsParser { get; private set; }
    public WhatsappAccount Acc;

    public static readonly Encoding SYSEncoding = Encoding.UTF8;
    private byte[] _encryptionKey;
    private byte[] _challengeBytes;
    private List<IncompleteMessageException> _incompleteBytes;

    public WhatsAppProtocol(WhatsappAccount _Acc)
    {
        this.messageQueue = new List<ProtocolTreeNode>();
        WhatsAppProtocol.DEBUG = false;
        string[] dict = DecodeHelper.getDictionary();
        this.writer = new BinTreeNodeWriter(dict);
        this.reader = new BinTreeNodeReader(dict);
        this.loginStatus = CONNECTION_STATUS.DISCONNECTED;
        this.whatsNetwork = new WhatsNetwork(WhatsConstants.WhatsAppHost, WhatsConstants.WhatsPort, this.timeout);
        this.WhatsParser = new WhatsParser(this.whatsNetwork, this.writer);
        this.WhatsSendHandler = this.WhatsParser.WhatsSendHandler;

        _incompleteBytes = new List<IncompleteMessageException>();

        Acc = _Acc;
    }

    public void AddMessage(ProtocolTreeNode node)
    {
        lock (messageLock)
        {
            this.messageQueue.Add(node);
        }

    }

    public void Connect()
    {
        this.whatsNetwork.Connect();
    }
    public void Disconnect()
    {
        this.whatsNetwork.Connect();
        this.loginStatus = CONNECTION_STATUS.DISCONNECTED;
    }

    public AccountInfo GetAccountInfo()
    {
        return this.accountinfo;
    }

    public ProtocolTreeNode[] GetAllMessages()
    {
        ProtocolTreeNode[] tmpReturn = null;
        lock (messageLock)
        {
            tmpReturn = this.messageQueue.ToArray();
            this.messageQueue.Clear();
        }
        return tmpReturn;
    }

    public bool HasMessages()
    {
        if (this.messageQueue == null)
            return false;
        return this.messageQueue.Count > 0;
    }

    public void Login()
    {
        string resource = string.Format(@"{0}-{1}-{2}",
            WhatsConstants.IphoneDevice,
            WhatsConstants.WhatsAppVer,
            WhatsConstants.WhatsPort);
        var data = this.writer.StartStream(WhatsConstants.WhatsAppServer, resource);
        var feat = this.addFeatures();
        ProtocolTreeNode auth = this.addAuth();
        this.whatsNetwork.SendData(data);
        this.whatsNetwork.SendData(this.writer.Write(feat, false));
        this.whatsNetwork.SendData(this.writer.Write(auth, false));

        this.PollMessages();

        ProtocolTreeNode authResp = this.addAuthResponse_v1_2();
        this.whatsNetwork.SendData(this.writer.Write(authResp, false));
        int cnt = 0;
        {
            this.PollMessages();
            System.Threading.Thread.Sleep(50);
        } while ((cnt++ < 100) &&
                    (this.loginStatus == CONNECTION_STATUS.DISCONNECTED));
    }

    public void Message(string to, string txt)
    {
        var tmpMessage = new FMessage(to, true) { key = { id = TicketManager.GenerateId() }, data = txt };
        this.WhatsParser.WhatsSendHandler.SendMessage(tmpMessage);
    }

    public void MessageImage(string msgid, string to, string url, string file, string size, string icon)
    {
        // implent
    }

    public void PollMessages()
    {
        this.processInboundData(this.whatsNetwork.ReadData());
    }

    public void Pong(string msgid)
    {
        this.WhatsParser.WhatsSendHandler.SendPong(msgid);
    }

    public void RequestLastSeen(string jid)
    {
        this.WhatsParser.WhatsSendHandler.SendQueryLastOnline(jid);
    }

    public void sendNickname(string nickname)
    {
        this.WhatsParser.WhatsSendHandler.SendAvailableForChat(nickname);
    }

    protected ProtocolTreeNode addAuth()
    {
        ProtocolTreeNode node = new ProtocolTreeNode("auth",
            new KeyValue[] { new KeyValue("xmlns", @"urn:ietf:params:xml:ns:xmpp-sasl"),
            new KeyValue("mechanism", "WAUTH-1"),
            new KeyValue("user", Acc.FullPhonenumber) });
        return node;
    }

    protected ProtocolTreeNode addAuthResponse_v1_2()
    {
        while (this._challengeBytes == null)
        {
            this.PollMessages();
            System.Threading.Thread.Sleep(500);
        }

        Rfc2898DeriveBytes r = new Rfc2898DeriveBytes(Acc.Password, _challengeBytes, 16);
        this._encryptionKey = r.GetBytes(20);
        this.reader.Encryptionkey = _encryptionKey;
        this.writer.Encryptionkey = _encryptionKey;

        List<byte> b = new List<byte>();
        b.AddRange(WhatsAppProtocol.SYSEncoding.GetBytes(Acc.Phonenumber));
        b.AddRange(this._challengeBytes);
        b.AddRange(WhatsAppProtocol.SYSEncoding.GetBytes(Func.GetNowUnixTimestamp().ToString()));

        byte[] data = b.ToArray();

        byte[] response = Encryption.WhatsappEncrypt(_encryptionKey, data, false);
        var node = new ProtocolTreeNode("response",
            new KeyValue[] { new KeyValue("xmlns", "urn:ietf:params:xml:ns:xmpp-sasl") },
            response);

        return node;
    }

    protected ProtocolTreeNode addFeatures()
    {
        var child = new ProtocolTreeNode("receipt_acks", null);
        var childList = new List<ProtocolTreeNode>();
        childList.Add(child);
        var parent = new ProtocolTreeNode("stream:features", null, childList, null);
        return parent;
    }

    protected void DebugPrint(string debugMsg)
    {
        if (WhatsAppProtocol.DEBUG && debugMsg.Length > 0)
        {
            Console.WriteLine(debugMsg);
        }
    }

    protected void processChallenge(ProtocolTreeNode node)
    {
        _challengeBytes = node.data;
    }

    protected void processInboundData(byte[] data)
    {
        try
        {
            var node = this.reader.nextTree(data);
            while (node != null)
            {
                this.WhatsParser.ParseProtocolNode(node);
                if (ProtocolTreeNode.TagEquals(node, "challenge"))
                {
                    this.processChallenge(node);
                }
                else if (ProtocolTreeNode.TagEquals(node, "success"))
                {
                    this.loginStatus = CONNECTION_STATUS.CONNECTED;
                    this.accountinfo = new AccountInfo(node.GetAttribute("status"),
                                                        node.GetAttribute("kind"),
                                                        node.GetAttribute("creation"),
                                                        node.GetAttribute("expiration"));
                }
                else if (ProtocolTreeNode.TagEquals(node, "failure"))
                {
                    this.loginStatus = CONNECTION_STATUS.DISCONNECTED;
                }
                if (ProtocolTreeNode.TagEquals(node, "message"))
                {
                    this.AddMessage(node);
                    this.sendMessageReceived(node);
                }
                if (ProtocolTreeNode.TagEquals(node, "stream:error"))
                {
                    Console.Write(node.NodeString());
                }
                if (ProtocolTreeNode.TagEquals(node, "iq")
                    && node.GetAttribute("type").Equals("get", StringComparison.OrdinalIgnoreCase)
                    && ProtocolTreeNode.TagEquals(node.children.First(), "ping"))
                {
                    this.Pong(node.GetAttribute("id"));
                }
                if (ProtocolTreeNode.TagEquals(node, "Replaced by new connection"))
                {
                    this.Connect();
                    this.Login();
                }
                node = this.reader.nextTree();
            }
        }
        catch (IncompleteMessageException e)
        {
           
        }
    }

    protected void sendMessageReceived(ProtocolTreeNode msg)
    {
        ProtocolTreeNode requestNode = msg.GetChild("request");
        if (requestNode == null ||
            !requestNode.GetAttribute("xmlns").Equals("urn:xmpp:receipts", StringComparison.OrdinalIgnoreCase))
            return;

        FMessage tmpMessage = new FMessage(new FMessage.Key(msg.GetAttribute("from"), true, msg.GetAttribute("id")));
        this.WhatsParser.WhatsSendHandler.SendMessageReceived(tmpMessage);
    }

    private string md5(string pass)
    {
        MD5 md5 = MD5.Create();
        byte[] dataMd5 = md5.ComputeHash(WhatsAppProtocol.SYSEncoding.GetBytes(pass));
        var sb = new StringBuilder();
        for (int i = 0; i < dataMd5.Length; i++)
            sb.AppendFormat("{0:x2}", dataMd5[i]);
        return sb.ToString();
    }
    private void PrintInfo(string p)
    {
        this.DebugPrint(p);
    }
}
