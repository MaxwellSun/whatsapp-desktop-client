﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class WhatsParser
{
    public WhatsSendHandler WhatsSendHandler { get; private set; }
    private WhatsNetwork whatsNetwork;
    private MessageRecvResponse messResponseHandler;
    private BinTreeNodeWriter _binWriter;

    internal WhatsParser(WhatsNetwork whatsNet, BinTreeNodeWriter writer)
    {
        this.WhatsSendHandler = new WhatsSendHandler(whatsNet, writer);
        this.whatsNetwork = whatsNet;
        this.messResponseHandler = new MessageRecvResponse(this.WhatsSendHandler);
        this._binWriter = writer;
    }

    public void ParseProtocolNode(ProtocolTreeNode protNode)
    {
        if (ProtocolTreeNode.TagEquals(protNode, "iq"))
        {
            string attributeValue = protNode.GetAttribute("type");
            string id = protNode.GetAttribute("id");
            string str3 = protNode.GetAttribute("from");
            if (attributeValue == null)
            {
                throw new Exception("Message-Corrupt: missing 'type' attribute in iq stanza");
            }
            if (!attributeValue.Equals("result"))
            {
                if (attributeValue.Equals("error"))
                {
                }
                else if (!attributeValue.Equals("get"))
                {
                    if (!attributeValue.Equals("set"))
                    {
                        throw new Exception("Message-Corrupt: unknown iq type attribute: " + attributeValue);
                    }
                    ProtocolTreeNode child = protNode.GetChild("query");
                    if (child != null)
                    {
                        string str8 = child.GetAttribute("xmlns");
                        if ("jabber:iq:roster" == str8)
                        {
                            foreach (ProtocolTreeNode node5 in child.GetAllChildren("item"))
                            {
                                node5.GetAttribute("jid");
                                node5.GetAttribute("subscription");
                                node5.GetAttribute("ask");
                            }
                        }
                    }
                }
                else
                {
                    ProtocolTreeNode node3 = protNode.GetChild("ping");
                    if (node3 != null)
                    {
                        // this.EventHandler.OnPing(id);
                    }
                    else if ((!ProtocolTreeNode.TagEquals(node3, "query")
                                || (str3 == null))
                                && (ProtocolTreeNode.TagEquals(node3, "relay")
                                    && (str3 != null)))
                    {
                        int num;
                        string pin = node3.GetAttribute("pin");
                        string tmpTimeout = node3.GetAttribute("timeout");
                        if (
                            !int.TryParse(tmpTimeout ?? "0", WhatsConstants.WhatsAppNumberStyle, CultureInfo.InvariantCulture,
                                            out num))
                        {
                            throw new CorruptStreamException("relay-iq exception parsing timeout attribute: " + tmpTimeout);
                        }
                        if (pin != null)
                        {
                        }
                    }
                }
            }
            else
            {
                // todo: implent
            }
        }
        else if (ProtocolTreeNode.TagEquals(protNode, "presence"))
        {
            string str9 = protNode.GetAttribute("xmlns");
            string jid = protNode.GetAttribute("from");
            if (((str9 == null) || "urn:xmpp".Equals(str9)) && (jid != null))
            {
                string str11 = protNode.GetAttribute("type");
                if ("unavailable".Equals(str11))
                {
                }
                else if ((str11 == null) || "available".Equals(str11))
                {
                }
            }
            else if ("w".Equals(str9) && (jid != null))
            {
                string str12 = protNode.GetAttribute("add");
                string str13 = protNode.GetAttribute("remove");
                string str14 = protNode.GetAttribute("status");
                if (str12 == null)
                {
                    if (str13 == null)
                    {
                        if ("dirty".Equals(str14))
                        {
                            Dictionary<string, long> categories = ParseCategories(protNode);
                        }
                    }
                }
            }
        }
        else if (ProtocolTreeNode.TagEquals(protNode, "message"))
        {
            this.messResponseHandler.ParseMessageRecv(protNode);
        }
        else if ((ProtocolTreeNode.TagEquals(protNode, "ib") /*&& (this.EventHandler != null)*/) &&
                    (protNode.GetChild("offline") != null))
        {
        }
    }

    internal static Dictionary<string, long> ParseCategories(ProtocolTreeNode dirtyNode)
    {
        var dictionary = new Dictionary<string, long>();
        if (dirtyNode.children != null)
        {
            for (int i = 0; i < dirtyNode.children.Count(); i++)
            {
                ProtocolTreeNode node = dirtyNode.children.ElementAt(i);
                if (ProtocolTreeNode.TagEquals(node, "category"))
                {
                    long num2;
                    string attributeValue = node.GetAttribute("name");
                    if (long.TryParse(node.GetAttribute("timestamp"), WhatsConstants.WhatsAppNumberStyle,
                                        CultureInfo.InvariantCulture, out num2))
                    {
                        dictionary[attributeValue] = num2;
                    }
                }
            }
        }
        return dictionary;
    }
}
