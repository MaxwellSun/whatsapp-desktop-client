namespace WhatsappClient
{
    partial class Form_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.PictureBox_Logo = new System.Windows.Forms.PictureBox();
            this.Button_Login = new System.Windows.Forms.Button();
            this.ComboBox_Login = new System.Windows.Forms.ComboBox();
            this.Button_AddAccount = new System.Windows.Forms.Button();
            this.GroupBox_AddAccount = new System.Windows.Forms.GroupBox();
            this.Button_AddThisAccount = new System.Windows.Forms.Button();
            this.TextBox_ImeiMac = new System.Windows.Forms.TextBox();
            this.Label_ImeiMac = new System.Windows.Forms.Label();
            this.ComboBox_DeviceOS = new System.Windows.Forms.ComboBox();
            this.Label_DeviceOS = new System.Windows.Forms.Label();
            this.TextBox_Phonenumber = new System.Windows.Forms.TextBox();
            this.Label_Phonenumber = new System.Windows.Forms.Label();
            this.Label_Status = new System.Windows.Forms.Label();
            this.ComboBox_CountryCode = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Logo)).BeginInit();
            this.GroupBox_AddAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox_Logo
            // 
            this.PictureBox_Logo.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox_Logo.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Logo.Image")));
            this.PictureBox_Logo.Location = new System.Drawing.Point(12, 13);
            this.PictureBox_Logo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PictureBox_Logo.Name = "PictureBox_Logo";
            this.PictureBox_Logo.Size = new System.Drawing.Size(239, 65);
            this.PictureBox_Logo.TabIndex = 0;
            this.PictureBox_Logo.TabStop = false;
            // 
            // Button_Login
            // 
            this.Button_Login.Location = new System.Drawing.Point(368, 116);
            this.Button_Login.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_Login.Name = "Button_Login";
            this.Button_Login.Size = new System.Drawing.Size(87, 28);
            this.Button_Login.TabIndex = 2;
            this.Button_Login.Text = "Login";
            this.Button_Login.UseVisualStyleBackColor = true;
            this.Button_Login.Click += new System.EventHandler(this.Button_Login_Click);
            // 
            // ComboBox_Login
            // 
            this.ComboBox_Login.AccessibleName = "ComboBox_Login";
            this.ComboBox_Login.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Login.FormattingEnabled = true;
            this.ComboBox_Login.Location = new System.Drawing.Point(12, 85);
            this.ComboBox_Login.Name = "ComboBox_Login";
            this.ComboBox_Login.Size = new System.Drawing.Size(443, 24);
            this.ComboBox_Login.TabIndex = 3;
            // 
            // Button_AddAccount
            // 
            this.Button_AddAccount.Location = new System.Drawing.Point(257, 116);
            this.Button_AddAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button_AddAccount.Name = "Button_AddAccount";
            this.Button_AddAccount.Size = new System.Drawing.Size(105, 28);
            this.Button_AddAccount.TabIndex = 4;
            this.Button_AddAccount.Text = "Add account";
            this.Button_AddAccount.UseVisualStyleBackColor = true;
            this.Button_AddAccount.Click += new System.EventHandler(this.Button_AddAccount_Click);
            // 
            // GroupBox_AddAccount
            // 
            this.GroupBox_AddAccount.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox_AddAccount.Controls.Add(this.ComboBox_CountryCode);
            this.GroupBox_AddAccount.Controls.Add(this.Button_AddThisAccount);
            this.GroupBox_AddAccount.Controls.Add(this.TextBox_ImeiMac);
            this.GroupBox_AddAccount.Controls.Add(this.Label_ImeiMac);
            this.GroupBox_AddAccount.Controls.Add(this.ComboBox_DeviceOS);
            this.GroupBox_AddAccount.Controls.Add(this.Label_DeviceOS);
            this.GroupBox_AddAccount.Controls.Add(this.TextBox_Phonenumber);
            this.GroupBox_AddAccount.Controls.Add(this.Label_Phonenumber);
            this.GroupBox_AddAccount.ForeColor = System.Drawing.Color.White;
            this.GroupBox_AddAccount.Location = new System.Drawing.Point(12, 165);
            this.GroupBox_AddAccount.Name = "GroupBox_AddAccount";
            this.GroupBox_AddAccount.Size = new System.Drawing.Size(443, 227);
            this.GroupBox_AddAccount.TabIndex = 5;
            this.GroupBox_AddAccount.TabStop = false;
            this.GroupBox_AddAccount.Text = "Add account";
            // 
            // Button_AddThisAccount
            // 
            this.Button_AddThisAccount.ForeColor = System.Drawing.Color.Black;
            this.Button_AddThisAccount.Location = new System.Drawing.Point(322, 190);
            this.Button_AddThisAccount.Name = "Button_AddThisAccount";
            this.Button_AddThisAccount.Size = new System.Drawing.Size(115, 31);
            this.Button_AddThisAccount.TabIndex = 6;
            this.Button_AddThisAccount.Text = "Add this account";
            this.Button_AddThisAccount.UseVisualStyleBackColor = true;
            this.Button_AddThisAccount.Click += new System.EventHandler(this.Button_AddThisAccount_Click);
            // 
            // TextBox_ImeiMac
            // 
            this.TextBox_ImeiMac.Location = new System.Drawing.Point(9, 161);
            this.TextBox_ImeiMac.Name = "TextBox_ImeiMac";
            this.TextBox_ImeiMac.Size = new System.Drawing.Size(428, 23);
            this.TextBox_ImeiMac.TabIndex = 5;
            this.TextBox_ImeiMac.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label_ImeiMac
            // 
            this.Label_ImeiMac.AutoSize = true;
            this.Label_ImeiMac.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ImeiMac.Location = new System.Drawing.Point(6, 142);
            this.Label_ImeiMac.Name = "Label_ImeiMac";
            this.Label_ImeiMac.Size = new System.Drawing.Size(314, 16);
            this.Label_ImeiMac.TabIndex = 4;
            this.Label_ImeiMac.Text = "International Mobile Equipment Identity (IMEI):";
            // 
            // ComboBox_DeviceOS
            // 
            this.ComboBox_DeviceOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_DeviceOS.FormattingEnabled = true;
            this.ComboBox_DeviceOS.Items.AddRange(new object[] {
            "Android",
            "iOS",
            "Symbian",
            "Windows Phone"});
            this.ComboBox_DeviceOS.Location = new System.Drawing.Point(9, 99);
            this.ComboBox_DeviceOS.Name = "ComboBox_DeviceOS";
            this.ComboBox_DeviceOS.Size = new System.Drawing.Size(428, 24);
            this.ComboBox_DeviceOS.TabIndex = 3;
            this.ComboBox_DeviceOS.SelectedIndexChanged += new System.EventHandler(this.ComboBox_DeviceOS_SelectedIndexChanged);
            // 
            // Label_DeviceOS
            // 
            this.Label_DeviceOS.AutoSize = true;
            this.Label_DeviceOS.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_DeviceOS.Location = new System.Drawing.Point(6, 80);
            this.Label_DeviceOS.Name = "Label_DeviceOS";
            this.Label_DeviceOS.Size = new System.Drawing.Size(176, 16);
            this.Label_DeviceOS.TabIndex = 2;
            this.Label_DeviceOS.Text = "Device Operating System:";
            // 
            // TextBox_Phonenumber
            // 
            this.TextBox_Phonenumber.Location = new System.Drawing.Point(85, 38);
            this.TextBox_Phonenumber.Name = "TextBox_Phonenumber";
            this.TextBox_Phonenumber.Size = new System.Drawing.Size(352, 23);
            this.TextBox_Phonenumber.TabIndex = 1;
            this.TextBox_Phonenumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label_Phonenumber
            // 
            this.Label_Phonenumber.AutoSize = true;
            this.Label_Phonenumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Phonenumber.Location = new System.Drawing.Point(6, 19);
            this.Label_Phonenumber.Name = "Label_Phonenumber";
            this.Label_Phonenumber.Size = new System.Drawing.Size(106, 16);
            this.Label_Phonenumber.TabIndex = 0;
            this.Label_Phonenumber.Text = "Phone number:";
            // 
            // Label_Status
            // 
            this.Label_Status.AutoSize = true;
            this.Label_Status.BackColor = System.Drawing.Color.Transparent;
            this.Label_Status.ForeColor = System.Drawing.Color.Red;
            this.Label_Status.Location = new System.Drawing.Point(9, 122);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(244, 16);
            this.Label_Status.TabIndex = 6;
            this.Label_Status.Text = "Please wait while we verify your account.";
            this.Label_Status.Visible = false;
            // 
            // ComboBox_CountryCode
            // 
            this.ComboBox_CountryCode.FormattingEnabled = true;
            this.ComboBox_CountryCode.Items.AddRange(new object[] {
            "+93",
            "+355",
            "+213",
            "+1684",
            "+376",
            "+244",
            "+1264",
            "+672",
            "+1268",
            "+54",
            "+374",
            "+297",
            "+247",
            "+61",
            "+672",
            "+43",
            "+994",
            "+1242",
            "+973",
            "+880",
            "+1246",
            "+1268",
            "+375",
            "+32",
            "+501",
            "+229",
            "+1441",
            "+975",
            "+591",
            "+387",
            "+267",
            "+55",
            "+1284",
            "+673",
            "+359",
            "+226",
            "+257",
            "+855",
            "+237",
            "+1",
            "+238",
            "+1345",
            "+236",
            "+235",
            "+64",
            "+56",
            "+86",
            "+618",
            "+61",
            "+57",
            "+269",
            "+242",
            "+243",
            "+682",
            "+506",
            "+225 ",
            "+385",
            "+53",
            "+5399",
            "+599",
            "+357",
            "+420 ",
            "+45",
            "+246",
            "+253",
            "+1767",
            "+1809",
            "+1829",
            "+670",
            "+56",
            "+593 ",
            "+20",
            "+503",
            "+8812",
            "+8813",
            "+88213",
            "+240",
            "+291",
            "+372",
            "+251",
            "+500",
            "+298",
            "+679",
            "+358",
            "+33",
            "+596",
            "+594",
            "+689",
            "+241",
            "+220",
            "+995",
            "+49",
            "+233",
            "+350",
            "+881",
            "+8818",
            "+8819",
            "+30",
            "+299",
            "+1473",
            "+590",
            "+1671",
            "+5399",
            "+502",
            "+245",
            "+224",
            "+592",
            "+509",
            "+504",
            "+852",
            "+36",
            "+8810",
            "+8811",
            "+354 ",
            "+91",
            "+62",
            "+871",
            "+874",
            "+873",
            "+872",
            "+870",
            "+800",
            "+808",
            "+98",
            "+964",
            "+353",
            "+8816",
            "+8817",
            "+972",
            "+39",
            "+1876",
            "+81",
            "+962",
            "+7",
            "+254 ",
            "+686",
            "+850",
            "+82",
            "+965",
            "+996",
            "+856",
            "+371",
            "+961",
            "+266",
            "+231",
            "+218",
            "+423",
            "+370",
            "+352",
            "+853",
            "+389",
            "+261",
            "+265",
            "+60",
            "+960",
            "+223",
            "+356",
            "+692",
            "+596",
            "+222",
            "+230",
            "+269",
            "+52",
            "+691",
            "+1808",
            "+373",
            "+377",
            "+976",
            "+382",
            "+1664",
            "+212",
            "+258",
            "+95",
            "+264",
            "+674",
            "+977",
            "+31",
            "+599",
            "+1869",
            "+687",
            "+64",
            "+505",
            "+227",
            "+234 ",
            "+683",
            "+672",
            "+1670",
            "+47",
            "+968",
            "+92",
            "+680",
            "+970",
            "+507",
            "+675",
            "+595",
            "+51",
            "+63",
            "+48",
            "+351",
            "+1787 ",
            "+1939",
            "+974 ",
            "+262",
            "+40",
            "+7",
            "+250",
            "+290",
            "+1869",
            "+1758",
            "+508",
            "+1784",
            "+685",
            "+378",
            "+239",
            "+966",
            "+221",
            "+381",
            "+248",
            "+232",
            "+65",
            "+421",
            "+386",
            "+677",
            "+252",
            "+27",
            "+34",
            "+94",
            "+249",
            "+597",
            "+268",
            "+46",
            "+41",
            "+963",
            "+886",
            "+992",
            "+255",
            "+66",
            "+88216",
            "+670",
            "+228",
            "+690",
            "+676",
            "+1868",
            "+216",
            "+90 ",
            "+993",
            "+1649",
            "+688",
            "+256",
            "+380",
            "+971",
            "+44",
            "+1",
            "+1340",
            "+878",
            "+598",
            "+998",
            "+678",
            "+39",
            "+379",
            "+58",
            "+84",
            "+808",
            "+681",
            "+967",
            "+260 ",
            "+255",
            "+263 "});
            this.ComboBox_CountryCode.Location = new System.Drawing.Point(9, 37);
            this.ComboBox_CountryCode.Name = "ComboBox_CountryCode";
            this.ComboBox_CountryCode.Size = new System.Drawing.Size(70, 24);
            this.ComboBox_CountryCode.TabIndex = 7;
            this.ComboBox_CountryCode.Text = "+31";
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(473, 408);
            this.Controls.Add(this.Label_Status);
            this.Controls.Add(this.GroupBox_AddAccount);
            this.Controls.Add(this.Button_AddAccount);
            this.Controls.Add(this.ComboBox_Login);
            this.Controls.Add(this.Button_Login);
            this.Controls.Add(this.PictureBox_Logo);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_Login";
            this.Text = "Whatsapp Desktop Client Login";
            this.Load += new System.EventHandler(this.Form_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Logo)).EndInit();
            this.GroupBox_AddAccount.ResumeLayout(false);
            this.GroupBox_AddAccount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox_Logo;
        private System.Windows.Forms.Button Button_Login;
        private System.Windows.Forms.ComboBox ComboBox_Login;
        private System.Windows.Forms.Button Button_AddAccount;
        private System.Windows.Forms.GroupBox GroupBox_AddAccount;
        private System.Windows.Forms.Button Button_AddThisAccount;
        private System.Windows.Forms.TextBox TextBox_ImeiMac;
        private System.Windows.Forms.Label Label_ImeiMac;
        private System.Windows.Forms.ComboBox ComboBox_DeviceOS;
        private System.Windows.Forms.Label Label_DeviceOS;
        private System.Windows.Forms.TextBox TextBox_Phonenumber;
        private System.Windows.Forms.Label Label_Phonenumber;
        private System.Windows.Forms.Label Label_Status;
        private System.Windows.Forms.ComboBox ComboBox_CountryCode;
    }
}