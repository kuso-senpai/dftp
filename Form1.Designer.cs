namespace double_ftp_main
{
    partial class DFTP
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_settings_page = new System.Windows.Forms.TabPage();
            this.btn_reload_dftpID_list = new System.Windows.Forms.Button();
            this.label_buildFilename = new System.Windows.Forms.Label();
            this.txt_buildFilename = new System.Windows.Forms.TextBox();
            this.check_buildCopyToStartup = new System.Windows.Forms.CheckBox();
            this.label_headerBuildSettings = new System.Windows.Forms.Label();
            this.btn_ftpConnect = new System.Windows.Forms.Button();
            this.label_ftpID = new System.Windows.Forms.Label();
            this.dftpID_choose = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_log = new System.Windows.Forms.RichTextBox();
            this.check_useEncryption = new System.Windows.Forms.CheckBox();
            this.label_headerFtpSettings = new System.Windows.Forms.Label();
            this.btn_loginToFtp = new System.Windows.Forms.Button();
            this.check_showPassword = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ftpUser = new System.Windows.Forms.TextBox();
            this.txt_ftpPassword = new System.Windows.Forms.TextBox();
            this.txt_ftpServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_commandInput = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tab_settings_page.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_settings_page);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1110, 425);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_settings_page
            // 
            this.tab_settings_page.Controls.Add(this.btn_reload_dftpID_list);
            this.tab_settings_page.Controls.Add(this.label_buildFilename);
            this.tab_settings_page.Controls.Add(this.txt_buildFilename);
            this.tab_settings_page.Controls.Add(this.check_buildCopyToStartup);
            this.tab_settings_page.Controls.Add(this.label_headerBuildSettings);
            this.tab_settings_page.Controls.Add(this.btn_ftpConnect);
            this.tab_settings_page.Controls.Add(this.label_ftpID);
            this.tab_settings_page.Controls.Add(this.dftpID_choose);
            this.tab_settings_page.Controls.Add(this.label6);
            this.tab_settings_page.Controls.Add(this.txt_log);
            this.tab_settings_page.Controls.Add(this.check_useEncryption);
            this.tab_settings_page.Controls.Add(this.label_headerFtpSettings);
            this.tab_settings_page.Controls.Add(this.btn_loginToFtp);
            this.tab_settings_page.Controls.Add(this.check_showPassword);
            this.tab_settings_page.Controls.Add(this.label4);
            this.tab_settings_page.Controls.Add(this.txt_ftpUser);
            this.tab_settings_page.Controls.Add(this.txt_ftpPassword);
            this.tab_settings_page.Controls.Add(this.txt_ftpServer);
            this.tab_settings_page.Controls.Add(this.label3);
            this.tab_settings_page.Controls.Add(this.label2);
            this.tab_settings_page.Controls.Add(this.label1);
            this.tab_settings_page.Location = new System.Drawing.Point(4, 22);
            this.tab_settings_page.Name = "tab_settings_page";
            this.tab_settings_page.Padding = new System.Windows.Forms.Padding(3);
            this.tab_settings_page.Size = new System.Drawing.Size(1102, 399);
            this.tab_settings_page.TabIndex = 0;
            this.tab_settings_page.Text = "Einstellungen";
            this.tab_settings_page.UseVisualStyleBackColor = true;
            // 
            // btn_reload_dftpID_list
            // 
            this.btn_reload_dftpID_list.Location = new System.Drawing.Point(644, 35);
            this.btn_reload_dftpID_list.Name = "btn_reload_dftpID_list";
            this.btn_reload_dftpID_list.Size = new System.Drawing.Size(75, 23);
            this.btn_reload_dftpID_list.TabIndex = 21;
            this.btn_reload_dftpID_list.Text = "Neu laden";
            this.btn_reload_dftpID_list.UseVisualStyleBackColor = true;
            this.btn_reload_dftpID_list.Click += new System.EventHandler(this.btn_reload_dftpID_list_Click);
            // 
            // label_buildFilename
            // 
            this.label_buildFilename.AutoSize = true;
            this.label_buildFilename.Location = new System.Drawing.Point(809, 35);
            this.label_buildFilename.Name = "label_buildFilename";
            this.label_buildFilename.Size = new System.Drawing.Size(49, 13);
            this.label_buildFilename.TabIndex = 20;
            this.label_buildFilename.Text = "Filename";
            // 
            // txt_buildFilename
            // 
            this.txt_buildFilename.Location = new System.Drawing.Point(864, 32);
            this.txt_buildFilename.Name = "txt_buildFilename";
            this.txt_buildFilename.Size = new System.Drawing.Size(142, 20);
            this.txt_buildFilename.TabIndex = 19;
            // 
            // check_buildCopyToStartup
            // 
            this.check_buildCopyToStartup.AutoSize = true;
            this.check_buildCopyToStartup.Location = new System.Drawing.Point(812, 58);
            this.check_buildCopyToStartup.Name = "check_buildCopyToStartup";
            this.check_buildCopyToStartup.Size = new System.Drawing.Size(177, 17);
            this.check_buildCopyToStartup.TabIndex = 18;
            this.check_buildCopyToStartup.Text = "Zu shell:startup Ordner kopieren";
            this.check_buildCopyToStartup.UseVisualStyleBackColor = true;
            // 
            // label_headerBuildSettings
            // 
            this.label_headerBuildSettings.AutoSize = true;
            this.label_headerBuildSettings.Location = new System.Drawing.Point(873, 13);
            this.label_headerBuildSettings.Name = "label_headerBuildSettings";
            this.label_headerBuildSettings.Size = new System.Drawing.Size(71, 13);
            this.label_headerBuildSettings.TabIndex = 17;
            this.label_headerBuildSettings.Text = "Build Settings";
            // 
            // btn_ftpConnect
            // 
            this.btn_ftpConnect.Location = new System.Drawing.Point(462, 140);
            this.btn_ftpConnect.Name = "btn_ftpConnect";
            this.btn_ftpConnect.Size = new System.Drawing.Size(268, 23);
            this.btn_ftpConnect.TabIndex = 16;
            this.btn_ftpConnect.Text = "Verbinden";
            this.btn_ftpConnect.UseVisualStyleBackColor = true;
            this.btn_ftpConnect.Click += new System.EventHandler(this.btn_ftpConnect_Click);
            // 
            // label_ftpID
            // 
            this.label_ftpID.AutoSize = true;
            this.label_ftpID.Location = new System.Drawing.Point(459, 39);
            this.label_ftpID.Name = "label_ftpID";
            this.label_ftpID.Size = new System.Drawing.Size(52, 13);
            this.label_ftpID.TabIndex = 15;
            this.label_ftpID.Text = "DFTP ID:";
            // 
            // dftpID_choose
            // 
            this.dftpID_choose.FormattingEnabled = true;
            this.dftpID_choose.Location = new System.Drawing.Point(517, 36);
            this.dftpID_choose.Name = "dftpID_choose";
            this.dftpID_choose.Size = new System.Drawing.Size(121, 21);
            this.dftpID_choose.TabIndex = 14;
            this.dftpID_choose.Text = "ID auswählen";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Log";
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(9, 227);
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.Size = new System.Drawing.Size(1087, 166);
            this.txt_log.TabIndex = 12;
            this.txt_log.Text = "";
            // 
            // check_useEncryption
            // 
            this.check_useEncryption.AutoSize = true;
            this.check_useEncryption.Location = new System.Drawing.Point(462, 63);
            this.check_useEncryption.Name = "check_useEncryption";
            this.check_useEncryption.Size = new System.Drawing.Size(268, 17);
            this.check_useEncryption.TabIndex = 11;
            this.check_useEncryption.Text = "Verschlüsselung bei der Befehlsübertragung nutzen";
            this.check_useEncryption.UseVisualStyleBackColor = true;
            // 
            // label_headerFtpSettings
            // 
            this.label_headerFtpSettings.AutoSize = true;
            this.label_headerFtpSettings.Location = new System.Drawing.Point(525, 13);
            this.label_headerFtpSettings.Name = "label_headerFtpSettings";
            this.label_headerFtpSettings.Size = new System.Drawing.Size(68, 13);
            this.label_headerFtpSettings.TabIndex = 9;
            this.label_headerFtpSettings.Text = "FTP Settings";
            // 
            // btn_loginToFtp
            // 
            this.btn_loginToFtp.Location = new System.Drawing.Point(9, 140);
            this.btn_loginToFtp.Name = "btn_loginToFtp";
            this.btn_loginToFtp.Size = new System.Drawing.Size(343, 23);
            this.btn_loginToFtp.TabIndex = 8;
            this.btn_loginToFtp.Text = "Anmelden";
            this.btn_loginToFtp.UseVisualStyleBackColor = true;
            this.btn_loginToFtp.Click += new System.EventHandler(this.btn_loginToFtp_Click);
            // 
            // check_showPassword
            // 
            this.check_showPassword.AutoSize = true;
            this.check_showPassword.Location = new System.Drawing.Point(86, 117);
            this.check_showPassword.Name = "check_showPassword";
            this.check_showPassword.Size = new System.Drawing.Size(115, 17);
            this.check_showPassword.TabIndex = 7;
            this.check_showPassword.Text = "Passwort anzeigen";
            this.check_showPassword.UseVisualStyleBackColor = true;
            this.check_showPassword.CheckedChanged += new System.EventHandler(this.check_showPassword_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "General";
            // 
            // txt_ftpUser
            // 
            this.txt_ftpUser.Location = new System.Drawing.Point(86, 65);
            this.txt_ftpUser.Name = "txt_ftpUser";
            this.txt_ftpUser.Size = new System.Drawing.Size(266, 20);
            this.txt_ftpUser.TabIndex = 2;
            this.txt_ftpUser.Text = "kuso-sama";
            // 
            // txt_ftpPassword
            // 
            this.txt_ftpPassword.Location = new System.Drawing.Point(86, 91);
            this.txt_ftpPassword.Name = "txt_ftpPassword";
            this.txt_ftpPassword.Size = new System.Drawing.Size(266, 20);
            this.txt_ftpPassword.TabIndex = 3;
            this.txt_ftpPassword.Text = "v)lE(D3fJpz(vzeYEIBP";
            this.txt_ftpPassword.UseSystemPasswordChar = true;
            // 
            // txt_ftpServer
            // 
            this.txt_ftpServer.Location = new System.Drawing.Point(86, 39);
            this.txt_ftpServer.Name = "txt_ftpServer";
            this.txt_ftpServer.Size = new System.Drawing.Size(266, 20);
            this.txt_ftpServer.TabIndex = 1;
            this.txt_ftpServer.Text = "ftp://files.000webhost.com/public_html/ftp/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Passwort:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Benutzername:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FTP Server:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_commandInput);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1102, 399);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Remote-Konsole";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_commandInput
            // 
            this.txt_commandInput.BackColor = System.Drawing.SystemColors.WindowText;
            this.txt_commandInput.ForeColor = System.Drawing.SystemColors.Window;
            this.txt_commandInput.Location = new System.Drawing.Point(7, 7);
            this.txt_commandInput.Name = "txt_commandInput";
            this.txt_commandInput.Size = new System.Drawing.Size(1089, 386);
            this.txt_commandInput.TabIndex = 0;
            this.txt_commandInput.Text = "";
            this.txt_commandInput.Click += new System.EventHandler(this.txt_commandInput_Click);
            this.txt_commandInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_commandInput_KeyDown);
            // 
            // DFTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 506);
            this.Controls.Add(this.tabControl1);
            this.Name = "DFTP";
            this.Text = "DFTP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_settings_page.ResumeLayout(false);
            this.tab_settings_page.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_settings_page;
        private System.Windows.Forms.TextBox txt_ftpUser;
        private System.Windows.Forms.TextBox txt_ftpPassword;
        private System.Windows.Forms.TextBox txt_ftpServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox check_showPassword;
        private System.Windows.Forms.Button btn_loginToFtp;
        private System.Windows.Forms.CheckBox check_useEncryption;
        private System.Windows.Forms.Label label_headerFtpSettings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txt_log;
        private System.Windows.Forms.Label label_ftpID;
        private System.Windows.Forms.ComboBox dftpID_choose;
        private System.Windows.Forms.Label label_buildFilename;
        private System.Windows.Forms.TextBox txt_buildFilename;
        private System.Windows.Forms.CheckBox check_buildCopyToStartup;
        private System.Windows.Forms.Label label_headerBuildSettings;
        private System.Windows.Forms.Button btn_ftpConnect;
        private System.Windows.Forms.RichTextBox txt_commandInput;
        private System.Windows.Forms.Button btn_reload_dftpID_list;
    }
}

