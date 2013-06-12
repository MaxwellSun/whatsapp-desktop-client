/*
 * by Stefan Bijen aka Freakypain - stefan.bijen@gmail.com 
 * Updated 2012-11-09 (Freakypain)
 */




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WhatsappClient
{
    /// <summary>
    /// Main Form for users after login
    /// </summary>
    public partial class Form_Main : Form
    {
        /// <summary>
        /// Instance of WhatsAppAccount, represents the logged in user.
        /// </summary>
        private WhatsappAccount Account;

        /// <summary>
        /// Instance of ContactCollection class, holds all contacts.
        /// </summary>
        private ContactCollection Contacts;

        WhatsAppProtocol Prot;

        /// <summary>
        /// Default class constructor, called by Form_Login
        /// </summary>
        /// <param name="_Account">An instance of WhatsAppAccount</param>
        public Form_Main(WhatsappAccount _Account)
        {
            InitializeComponent();
            Account = _Account;
            Prot = new WhatsAppProtocol(Account);
            Contacts = new ContactCollection();
        }

        /// <summary>
        /// Event: Called when the form loads
        /// </summary>
        private void Form_Main_Load(object sender, EventArgs e)
        {
            Thread Th = new Thread(ConnectionStatus);
            CheckForIllegalCrossThreadCalls = false;
            Th.Start();

            // Load all contacts
            ListBox_Contacts.DataSource = Contacts;
            ListBox_Contacts.DisplayMember = "this\\Name";
        }

        // debug
        private void button1_Click(object sender, EventArgs e)
        {
            Prot.Connect();
            //Prot.Login();
        }

        private void ConnectionStatus()
        {
            while (true)
            {
                if (Prot.whatsNetwork.socket.Connected == true)
                {
                    this.Text = "Connected";
                }
                else this.Text = "Disconnected";
                System.Threading.Thread.Sleep(500);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Prot.Login();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Prot.Message("+31624115307", "testc");
        }

        private void ListBox_Contacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox_Contacts.SelectedItem != null)
            {
                Contact SelectedContact = (Contact)ListBox_Contacts.SelectedItem;
                Label_ContactName.Text = SelectedContact.Name;
                TextBox_ContactsName.Text = SelectedContact.PhoneNumber;
                ComboBox_CountryCode.Text = SelectedContact.CountryCode;
            }
        }

        private void TextBox_ContactsName_TextChanged(object sender, EventArgs e)
        {
            ThreadedMethod tMethod = new ThreadedMethod(UpdateContactName);
            tMethod.Start();
        }

        private void UpdateContactName()
        {
            Label_ContactName.Text = TextBox_ContactsName.Text;
        }

        private void Button_NewContact_Click(object sender, EventArgs e)
        {
            Label_ContactName.Text = "Name";
            TextBox_ContactsName.Text = "";
            ComboBox_CountryCode.Text = "";
            TextBox_ContactPhoneNumber.Text = "";
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (ListBox_Contacts.SelectedItem == null)
            {
                // new contact
                Contacts.Add(new Contact(TextBox_ContactPhoneNumber.Text, ComboBox_CountryCode.Text, TextBox_ContactsName.Text));
                MessageBox.Show(Contacts.Count.ToString());
                ListBox_Contacts.DataSource = Contacts;
                ListBox_Contacts.DisplayMember = "this\\Name";
            }
            else
            {
                Contact SelectedItem = (Contact)ListBox_Contacts.SelectedItem;
                SelectedItem.Name = TextBox_ContactsName.Text;
                SelectedItem.PhoneNumber = TextBox_ContactPhoneNumber.Text;
                SelectedItem.CountryCode = ComboBox_CountryCode.Text;
                ListBox_Contacts.DataSource = Contacts;
                ListBox_Contacts.DisplayMember = "this\\Name";
            }
        }

        private void TabPage_Settings_Click(object sender, EventArgs e)
        {

        }
    }
}
