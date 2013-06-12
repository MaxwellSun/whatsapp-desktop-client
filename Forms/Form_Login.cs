using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
/*
 * by Swen Kooij aka Kirk - swenkooij@gmail.com 
 */

using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WhatsappClient
{
    /// <summary>
    /// The whatsapp login form, select an account from the list or create one here.
    /// </summary>
    public partial class Form_Login : Form
    {
        /// <summary>
        /// An instance of the SQLiteDatabase class, represents a connection to
        /// a SQL Lite database.
        /// </summary>
        public SQLiteDatabase Database;

        /// <summary>
        /// A list that holds instances of the the Account class. This list will be filled on form load.
        /// </summary>
        private List<WhatsappAccount> WhatsappAccounts = new List<WhatsappAccount>();

        /// <summary>
        /// Class Constructor
        /// </summary>
        public Form_Login()
        {
            InitializeComponent();

            // Check if the databas exists
            if (System.IO.File.Exists("whatsapp_db.s3db"))
            {
                Database = new SQLiteDatabase("whatsapp_db.s3db");
            }
            else
            {
                MessageBox.Show("The database is missing (whatsapp_db.s3db), make sure it's in the same folder as the application.", "Error: Database missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Event: Called when the form has loaded.
        /// </summary>
        private void Form_Login_Load(object sender, EventArgs e)
        {
            // Load accounts
            updateAccounts();

            // Set form size
            this.Size = new Size(483, 191);

            // Set default Device OS
            ComboBox_DeviceOS.Text = "Android";
        }

        /// <summary>
        /// Reloads all accounts from the database
        /// </summary>
        private void updateAccounts()
        {
            // Read all info from the database
            WhatsappAccounts.Clear();
            ComboBox_Login.DataSource = null;
            ComboBox_Login.Items.Clear();
            DataRowCollection Rows = Database.GetTableRows("accounts", "");
            foreach (DataRow Row in Rows)
            {
                WhatsappAccount Acc = new WhatsappAccount(Row["countrycode"].ToString(), Row["phonenumber"].ToString(), Row["password"].ToString(), Row["phonenumber"].ToString());
                WhatsappAccounts.Add(Acc);
            }

            // Set data source and display member of combobox
            ComboBox_Login.DataSource = WhatsappAccounts;
            ComboBox_Login.DisplayMember = "FullPhonenumber";
        }

        /// <summary>
        /// Event: 'Add account' button has been clicked, resize form
        /// </summary>
        private void Button_AddAccount_Click(object sender, EventArgs e)
        {
            if (this.Size == new Size(483, 440))
            {
                CollapseForm();
            }
            else
            {
                ExpandForm();
            }
        }
        
        /// <summary>
        /// Expands the size of the form so the 'Add account' groupbox is visible.
        /// </summary>
        private void ExpandForm()
        {
            this.Size = new Size(483, 440);
        }

        /// <summary>
        /// Collapses the size of the form so the 'Add account' groupbox is no longer visible.
        /// </summary>
        private void CollapseForm()
        {
            this.Size = new Size(483, 191);
        }

        /// <summary>
        /// Sets the Enabled property of all controls on the form.
        /// </summary>
        /// <param name="trueFalse">Boolean value, true to enable and false to disable.</param>
        private void SetControlsEnabled(bool trueFalse)
        {
            ComboBox_DeviceOS.Enabled = trueFalse;
            Button_AddAccount.Enabled = trueFalse;
            Button_Login.Enabled = trueFalse;
            Button_AddThisAccount.Enabled = trueFalse;
            TextBox_ImeiMac.Enabled = trueFalse;
            TextBox_Phonenumber.Enabled = trueFalse;
            ComboBox_Login.Enabled = trueFalse;
        }

        /// <summary>
        /// Event: The selected item in de DeviceOS combo box changed
        /// </summary>
        private void ComboBox_DeviceOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox_DeviceOS.Text == "iOS")
                Label_ImeiMac.Text = "Wifi Mac Adress:";
            else
                Label_ImeiMac.Text = "International Mobile Equipment Identity (IMEI):";
        }

        /// <summary>
        /// Event: The 'Add this account' button has been clicked.
        /// </summary>
        private void Button_AddThisAccount_Click(object sender, EventArgs e)
        {
            // Disable controls
            SetControlsEnabled(false);

            // Show 'please wait' message
            Label_Status.Visible = true;

            // Start verifyAccount() in a new thread
            ThreadedMethod tMethod = new ThreadedMethod(verifyAccount);
            tMethod.Start();
        }

        /// <summary>
        /// Verifies the new account that is about to be added, this method is supposed to run
        /// in a seperated thread.
        /// </summary>
        private void verifyAccount()
        {
            WhatsAppHelper Helper = new WhatsAppHelper();
            WhatsAppHelper.DeviceOS OS = WhatsAppHelper.DeviceOS.Other;
            if (ComboBox_DeviceOS.Text == "iOS") OS = WhatsAppHelper.DeviceOS.iOS;
            string Password = Helper.generatePassword(TextBox_ImeiMac.Text, OS);
            bool Result = Helper.verifyAccount(ComboBox_CountryCode.Text, TextBox_Phonenumber.Text, Password);
            if (Result == true)
            {
                // Account exists, insert into database
                Dictionary<string, string> Values = new Dictionary<string,string>();
                Values.Add("countrycode", ComboBox_CountryCode.Text);
                Values.Add("phonenumber", TextBox_Phonenumber.Text);
                Values.Add("password", Password);
                Database.Insert("accounts", Values);

                // Resize form
                CollapseForm();

                // Update combobox
                updateAccounts();

                // Set phonenumber as selected
                ComboBox_Login.Text = TextBox_Phonenumber.Text;

                // Clear all fields
                TextBox_ImeiMac.Text = "";
                TextBox_Phonenumber.Text = "";
                ComboBox_DeviceOS.Text = "Android";
                Label_ImeiMac.Text = "International Mobile Equipment Identity (IMEI):";

                // Re-enable controls
                SetControlsEnabled(true);
                Label_Status.Visible = false;
            }
            else
            {
                // Account does not exists
                MessageBox.Show("Sorry, your account does not exists or you have given invalid information. Please re-check all field.", "Error: Account does not exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// Event: The login button has been clicked
        /// </summary>
        private void Button_Login_Click(object sender, EventArgs e)
        {
            // Diable constrols and show message
            Label_Status.Visible = true;
            Label_Status.Text = "Logging in...";
            SetControlsEnabled(false);

            ThreadedMethod tMethod = new ThreadedMethod(login);
            tMethod.Start();
        }

        /// <summary>
        /// Handles logging in, supposed to run in a seperated thread
        /// </summary>
        private void login()
        {
            if (ComboBox_Login.SelectedItem == null)
                return;
            WhatsappAccount Account = (WhatsappAccount)ComboBox_Login.SelectedItem;

            // Verify Account
            WhatsAppHelper Helper = new WhatsAppHelper();
            bool Result = Helper.verifyAccount(Account.CountryCode, Account.Phonenumber, Account.Password);
            if (Result == true)
            {
                // Account is valid, show main form
                Form_Main frmMain = new Form_Main(Account);
                this.Close();
                frmMain.ShowDialog();
            }
            else
            {
                DialogResult Re = MessageBox.Show("The selected acocunt does not appear to be working, do you want to remove it?", "Error: Account not working", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (Re == DialogResult.Yes)
                {
                    // Delete account
                    Database.Query("DELETE FROM accounts WHERE phonenumber='" + Account.Phonenumber + "'");

                    // Reload combobox
                    updateAccounts();

                    // Hide status label
                    Label_Status.Visible = false;
                    Label_Status.Text = "Please wait while we verify your account.";

                    // Enable controls
                    SetControlsEnabled(true);
                }
                else
                {
                    // Reload combobox
                    updateAccounts();

                    // Hide status label
                    Label_Status.Visible = false;
                    Label_Status.Text = "Please wait while we verify your account.";

                    // Enable controls
                    SetControlsEnabled(true);
                }
            }
        }
    }
}
