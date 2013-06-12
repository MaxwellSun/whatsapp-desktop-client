namespace WhatsappClient
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.PictureBox_Logo = new System.Windows.Forms.PictureBox();
            this.TabControl_Main = new System.Windows.Forms.TabControl();
            this.TabPage_Chats = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.List_Chats = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TabPage_Contacts = new System.Windows.Forms.TabPage();
            this.Button_RemoveContact = new System.Windows.Forms.Button();
            this.Button_NewContact = new System.Windows.Forms.Button();
            this.Panel_ContactDetailed = new System.Windows.Forms.Panel();
            this.Button_Save = new System.Windows.Forms.Button();
            this.Label_Phonenumber = new System.Windows.Forms.Label();
            this.ComboBox_CountryCode = new System.Windows.Forms.ComboBox();
            this.TextBox_ContactPhoneNumber = new System.Windows.Forms.TextBox();
            this.TextBox_ContactsName = new System.Windows.Forms.TextBox();
            this.Label_ContactName = new System.Windows.Forms.Label();
            this.ListBox_Contacts = new System.Windows.Forms.ListBox();
            this.TabPage_Settings = new System.Windows.Forms.TabPage();
            this.TabPage_About = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Logo)).BeginInit();
            this.TabControl_Main.SuspendLayout();
            this.TabPage_Chats.SuspendLayout();
            this.TabPage_Contacts.SuspendLayout();
            this.Panel_ContactDetailed.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox_Logo
            // 
            this.PictureBox_Logo.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox_Logo.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Logo.Image")));
            this.PictureBox_Logo.Location = new System.Drawing.Point(14, 22);
            this.PictureBox_Logo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PictureBox_Logo.Name = "PictureBox_Logo";
            this.PictureBox_Logo.Size = new System.Drawing.Size(279, 67);
            this.PictureBox_Logo.TabIndex = 1;
            this.PictureBox_Logo.TabStop = false;
            // 
            // TabControl_Main
            // 
            this.TabControl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_Main.Controls.Add(this.TabPage_Chats);
            this.TabControl_Main.Controls.Add(this.TabPage_Contacts);
            this.TabControl_Main.Controls.Add(this.TabPage_Settings);
            this.TabControl_Main.Controls.Add(this.TabPage_About);
            this.TabControl_Main.Location = new System.Drawing.Point(14, 104);
            this.TabControl_Main.Name = "TabControl_Main";
            this.TabControl_Main.SelectedIndex = 0;
            this.TabControl_Main.Size = new System.Drawing.Size(893, 480);
            this.TabControl_Main.TabIndex = 2;
            // 
            // TabPage_Chats
            // 
            this.TabPage_Chats.Controls.Add(this.button3);
            this.TabPage_Chats.Controls.Add(this.button2);
            this.TabPage_Chats.Controls.Add(this.List_Chats);
            this.TabPage_Chats.Controls.Add(this.textBox2);
            this.TabPage_Chats.Controls.Add(this.button1);
            this.TabPage_Chats.Controls.Add(this.textBox1);
            this.TabPage_Chats.Location = new System.Drawing.Point(4, 25);
            this.TabPage_Chats.Name = "TabPage_Chats";
            this.TabPage_Chats.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Chats.Size = new System.Drawing.Size(885, 451);
            this.TabPage_Chats.TabIndex = 0;
            this.TabPage_Chats.Text = "Chats";
            this.TabPage_Chats.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(326, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(578, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 52);
            this.button2.TabIndex = 4;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // List_Chats
            // 
            this.List_Chats.FormattingEnabled = true;
            this.List_Chats.ItemHeight = 16;
            this.List_Chats.Location = new System.Drawing.Point(6, 6);
            this.List_Chats.Name = "List_Chats";
            this.List_Chats.Size = new System.Drawing.Size(211, 436);
            this.List_Chats.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(223, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(240, 23);
            this.textBox2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(469, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(223, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(240, 23);
            this.textBox1.TabIndex = 0;
            // 
            // TabPage_Contacts
            // 
            this.TabPage_Contacts.Controls.Add(this.Button_RemoveContact);
            this.TabPage_Contacts.Controls.Add(this.Button_NewContact);
            this.TabPage_Contacts.Controls.Add(this.Panel_ContactDetailed);
            this.TabPage_Contacts.Controls.Add(this.ListBox_Contacts);
            this.TabPage_Contacts.Location = new System.Drawing.Point(4, 25);
            this.TabPage_Contacts.Name = "TabPage_Contacts";
            this.TabPage_Contacts.Size = new System.Drawing.Size(885, 451);
            this.TabPage_Contacts.TabIndex = 4;
            this.TabPage_Contacts.Text = "Contacts";
            this.TabPage_Contacts.UseVisualStyleBackColor = true;
            // 
            // Button_RemoveContact
            // 
            this.Button_RemoveContact.Location = new System.Drawing.Point(7, 418);
            this.Button_RemoveContact.Name = "Button_RemoveContact";
            this.Button_RemoveContact.Size = new System.Drawing.Size(104, 26);
            this.Button_RemoveContact.TabIndex = 3;
            this.Button_RemoveContact.Text = "Remove";
            this.Button_RemoveContact.UseVisualStyleBackColor = true;
            // 
            // Button_NewContact
            // 
            this.Button_NewContact.Location = new System.Drawing.Point(117, 418);
            this.Button_NewContact.Name = "Button_NewContact";
            this.Button_NewContact.Size = new System.Drawing.Size(101, 26);
            this.Button_NewContact.TabIndex = 2;
            this.Button_NewContact.Text = "New";
            this.Button_NewContact.UseVisualStyleBackColor = true;
            this.Button_NewContact.Click += new System.EventHandler(this.Button_NewContact_Click);
            // 
            // Panel_ContactDetailed
            // 
            this.Panel_ContactDetailed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_ContactDetailed.Controls.Add(this.Button_Save);
            this.Panel_ContactDetailed.Controls.Add(this.Label_Phonenumber);
            this.Panel_ContactDetailed.Controls.Add(this.ComboBox_CountryCode);
            this.Panel_ContactDetailed.Controls.Add(this.TextBox_ContactPhoneNumber);
            this.Panel_ContactDetailed.Controls.Add(this.TextBox_ContactsName);
            this.Panel_ContactDetailed.Controls.Add(this.Label_ContactName);
            this.Panel_ContactDetailed.Location = new System.Drawing.Point(224, 8);
            this.Panel_ContactDetailed.Name = "Panel_ContactDetailed";
            this.Panel_ContactDetailed.Size = new System.Drawing.Size(655, 436);
            this.Panel_ContactDetailed.TabIndex = 1;
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(556, 392);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(80, 31);
            this.Button_Save.TabIndex = 5;
            this.Button_Save.Text = "Save";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Label_Phonenumber
            // 
            this.Label_Phonenumber.AutoSize = true;
            this.Label_Phonenumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Phonenumber.Location = new System.Drawing.Point(10, 96);
            this.Label_Phonenumber.Name = "Label_Phonenumber";
            this.Label_Phonenumber.Size = new System.Drawing.Size(97, 16);
            this.Label_Phonenumber.TabIndex = 4;
            this.Label_Phonenumber.Text = "Phonenumber";
            // 
            // ComboBox_CountryCode
            // 
            this.ComboBox_CountryCode.FormattingEnabled = true;
            this.ComboBox_CountryCode.Location = new System.Drawing.Point(13, 115);
            this.ComboBox_CountryCode.Name = "ComboBox_CountryCode";
            this.ComboBox_CountryCode.Size = new System.Drawing.Size(64, 24);
            this.ComboBox_CountryCode.TabIndex = 3;
            // 
            // TextBox_ContactPhoneNumber
            // 
            this.TextBox_ContactPhoneNumber.Location = new System.Drawing.Point(83, 115);
            this.TextBox_ContactPhoneNumber.Name = "TextBox_ContactPhoneNumber";
            this.TextBox_ContactPhoneNumber.Size = new System.Drawing.Size(553, 23);
            this.TextBox_ContactPhoneNumber.TabIndex = 2;
            // 
            // TextBox_ContactsName
            // 
            this.TextBox_ContactsName.Location = new System.Drawing.Point(13, 41);
            this.TextBox_ContactsName.Name = "TextBox_ContactsName";
            this.TextBox_ContactsName.Size = new System.Drawing.Size(623, 23);
            this.TextBox_ContactsName.TabIndex = 1;
            this.TextBox_ContactsName.TextChanged += new System.EventHandler(this.TextBox_ContactsName_TextChanged);
            // 
            // Label_ContactName
            // 
            this.Label_ContactName.AutoSize = true;
            this.Label_ContactName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ContactName.Location = new System.Drawing.Point(8, 9);
            this.Label_ContactName.Name = "Label_ContactName";
            this.Label_ContactName.Size = new System.Drawing.Size(83, 29);
            this.Label_ContactName.TabIndex = 0;
            this.Label_ContactName.Text = "Naam";
            // 
            // ListBox_Contacts
            // 
            this.ListBox_Contacts.FormattingEnabled = true;
            this.ListBox_Contacts.ItemHeight = 16;
            this.ListBox_Contacts.Location = new System.Drawing.Point(7, 8);
            this.ListBox_Contacts.Name = "ListBox_Contacts";
            this.ListBox_Contacts.Size = new System.Drawing.Size(211, 404);
            this.ListBox_Contacts.TabIndex = 0;
            this.ListBox_Contacts.SelectedIndexChanged += new System.EventHandler(this.ListBox_Contacts_SelectedIndexChanged);
            // 
            // TabPage_Settings
            // 
            this.TabPage_Settings.Location = new System.Drawing.Point(4, 25);
            this.TabPage_Settings.Name = "TabPage_Settings";
            this.TabPage_Settings.Size = new System.Drawing.Size(885, 451);
            this.TabPage_Settings.TabIndex = 2;
            this.TabPage_Settings.Text = "Settings";
            this.TabPage_Settings.UseVisualStyleBackColor = true;
            this.TabPage_Settings.Click += new System.EventHandler(this.TabPage_Settings_Click);
            // 
            // TabPage_About
            // 
            this.TabPage_About.Location = new System.Drawing.Point(4, 25);
            this.TabPage_About.Name = "TabPage_About";
            this.TabPage_About.Size = new System.Drawing.Size(885, 451);
            this.TabPage_About.TabIndex = 3;
            this.TabPage_About.Text = "About";
            this.TabPage_About.UseVisualStyleBackColor = true;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(919, 596);
            this.Controls.Add(this.TabControl_Main);
            this.Controls.Add(this.PictureBox_Logo);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_Main";
            this.Text = "WhatsApp Desktop Client v1.0";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Logo)).EndInit();
            this.TabControl_Main.ResumeLayout(false);
            this.TabPage_Chats.ResumeLayout(false);
            this.TabPage_Chats.PerformLayout();
            this.TabPage_Contacts.ResumeLayout(false);
            this.Panel_ContactDetailed.ResumeLayout(false);
            this.Panel_ContactDetailed.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox_Logo;
        private System.Windows.Forms.TabControl TabControl_Main;
        private System.Windows.Forms.TabPage TabPage_Chats;
        private System.Windows.Forms.TabPage TabPage_Settings;
        private System.Windows.Forms.TabPage TabPage_About;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox List_Chats;
        private System.Windows.Forms.TabPage TabPage_Contacts;
        private System.Windows.Forms.Panel Panel_ContactDetailed;
        private System.Windows.Forms.ListBox ListBox_Contacts;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Button_RemoveContact;
        private System.Windows.Forms.Button Button_NewContact;
        private System.Windows.Forms.TextBox TextBox_ContactPhoneNumber;
        private System.Windows.Forms.TextBox TextBox_ContactsName;
        private System.Windows.Forms.Label Label_ContactName;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.Label Label_Phonenumber;
        private System.Windows.Forms.ComboBox ComboBox_CountryCode;
    }
}