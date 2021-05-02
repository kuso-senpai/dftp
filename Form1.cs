//FTP Main
//Author: kuso-sama
//Created: 09/16/2020

//Alle Using
#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;
#endregion

//Namespace
namespace double_ftp_main
{
    public partial class DFTP : MaterialForm
    {
        string context = $"{System.Environment.MachineName}@{System.Environment.UserName}> ";

        public DFTP()
        {
            // Initializiert alle Komponenten (Textboxen, etc...)
            InitializeComponent();

            // Autoscale
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            // Vorbereitung
            txt_commandInput.Text += context;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // Alle Buildsettings deaktivieren
            this.check_buildCopyToStartup.Enabled = false;
            this.txt_buildFilename.Enabled = false;
            this.label_headerBuildSettings.Enabled = false;
            this.label_buildFilename.Enabled = false;
            // Alle FTP Connection Settings deaktivieren
            this.btn_ftpConnect.Enabled = false;
            this.label_headerFtpSettings.Enabled = false;
            this.label_ftpID.Enabled = false;
            this.check_useEncryption.Enabled = false;
            this.dftpID_choose.Enabled = false;
            this.btn_reload_dftpID_list.Enabled = false;
            // Consoleinput textbox dekativieren
            this.txt_commandInput.Enabled = false;
        }

        /// <summary>
        /// Wenn das show_password Objekt sich ändert (nur der Haken)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void check_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Passwordanzeigen ist das gegenteil von .checked
            txt_ftpPassword.UseSystemPasswordChar = !check_showPassword.Checked;
        }

        /// <summary>
        /// Lädt alle ftp Sessions in der Liste neu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reload_dftpID_list_Click(object sender, EventArgs e)
        {
            dftpID_choose.Items.Clear();
            foreach (string item in ListDirectory())
            {
                if (item.EndsWith(".dftp"))
                    dftpID_choose.Items.Add(item);
            }
            MessageBox.Show("Die Liste wurde neu geladen!");
        }

        /// <summary>
        /// Guckt ob Login Daten richtig sind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_loginToFtp_Click(object sender, EventArgs e)
        {
            if (!ValidCredentials())
            {
                MessageBox.Show("Die Anmeldedaten sind falsch!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Enable all Build Settings
            this.check_buildCopyToStartup.Enabled = true;
            this.txt_buildFilename.Enabled = true;
            this.label_headerBuildSettings.Enabled = true;
            this.label_buildFilename.Enabled = true;
            // Enable all FTP Connection Settings
            this.btn_ftpConnect.Enabled = true;
            this.label_headerFtpSettings.Enabled = true;
            this.label_ftpID.Enabled = true;
            this.check_useEncryption.Enabled = true;
            this.dftpID_choose.Enabled = true;
            this.btn_reload_dftpID_list.Enabled = true;

            dftpID_choose.Items.Clear();
            foreach (string item in ListDirectory())
            {
                if(item.EndsWith(".dftp"))
                    dftpID_choose.Items.Add(item);
            }
        }


        #region tools
        public string[] ListDirectory()
        {
            try
            {
                var list = new List<string>();

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txt_ftpServer.Text);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(txt_ftpUser.Text, txt_ftpPassword.Text);
                request.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, true))
                        {
                            while (!reader.EndOfStream)
                            {
                                list.Add(reader.ReadLine());
                            }
                        }
                    }
                    response.Close();
                }
                return list.ToArray();
            } catch(WebException)
            {
                return ListDirectory();
            }
        }

        /// <summary>
        /// Gibt zurück ob die Credentials richtig sind (funktionieren)
        /// </summary>
        /// <returns>True wenn Anmeldedaten richtig sind, False wenn Anmeldedaten falsch sind</returns>
        private bool ValidCredentials()
        {
            try
            {
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(txt_ftpServer.Text);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(txt_ftpUser.Text, txt_ftpPassword.Text);

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (Exception ex)
            {
                writeToLog(ex.ToString());
                return false;
            }
        }
        #endregion


        #region consoleInput
        private void txt_commandInput_KeyDown(object sender, KeyEventArgs e)
        {
            // Wenn position vor dem input ist
            if (txt_commandInput.SelectionStart < context.Length)
            {
                txt_commandInput.SelectionStart = txt_commandInput.Text.Length;
                txt_commandInput.Focus();
                e.Handled = true;
            }

            // Wenn Enter gedrückt wurde
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                double_ftp.CommandHandling.executeCommand(txt_commandInput.Text.Split('\n').Last().Replace(context, ""), 
                    $"{txt_ftpServer.Text}{dftpID_choose.SelectedItem}", txt_ftpUser.Text, txt_ftpPassword.Text, txt_commandInput);

                txt_commandInput.Text += $"\n{context}";
                txt_commandInput.SelectionStart = txt_commandInput.Text.Length;
                txt_commandInput.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Back)
            {
                int newLineIndex = txt_commandInput.Text.LastIndexOf('\n') == -1 ? 0 : txt_commandInput.Text.LastIndexOf('\n');
                
                try
                {
                    // Index von dem Letzen "\n"
                    string checkString = txt_commandInput.Text.Substring(newLineIndex, context.Length);
                    string inputString = txt_commandInput.Text.Substring(newLineIndex, txt_commandInput.SelectionStart);

                    writeToLog($"Checkstring: '{checkString}'\ninputString: '{inputString}'");
                    writeToLog($"CheckstringLen: '{checkString.Length}'\ninputStringLen: '{inputString.Length}'\n");

                    // Wenn der Input NICHT durch das Backspace die context variable in der Textbox löschen würde
                    if (inputString.Length >= checkString.Length + 1)
                        // Dann wird ein Char vom Text gelöscht
                        txt_commandInput.Text = txt_commandInput.Text.Remove(txt_commandInput.Text.Length - 1);

                    // Setzt Fokus wieder
                    txt_commandInput.SelectionStart = txt_commandInput.Text.Length;
                    txt_commandInput.Focus();

                    // Ignoriert eigentliche Handlung
                    e.Handled = true;
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString() + $"newLineIndex{newLineIndex}");
                }
            }
        }


        private void txt_commandInput_Click(object sender, EventArgs e)
        {
            txt_commandInput.SelectionStart = txt_commandInput.Text.Length;
            txt_commandInput.Focus();
        }
        #endregion

        private void btn_ftpConnect_Click(object sender, EventArgs e)
        {
            try
            {
                writeToLog($"{txt_ftpServer.Text}{dftpID_choose.SelectedItem}");
                // Lädt Text runter
                string content = double_ftp.ftpTools.downloadFile($"{txt_ftpServer.Text}{dftpID_choose.SelectedItem}", txt_ftpUser.Text, txt_ftpPassword.Text);
                if (content != "")
                    writeToLog(content);

                MessageBox.Show($"Erfolgreich Verbunden mit {dftpID_choose.SelectedItem}", "Verbindung hergestellt", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Consoleinput aktivieren
                this.txt_commandInput.Enabled = true;
            }
            catch (System.Net.WebException)
            {
                if(dftpID_choose.SelectedItem == null)
                    MessageBox.Show("Es wurde keine Session ausgewählt", "Fehler bei Verbindung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Ein unbekannter Fehler beim Verbinden ist aufgetreten", "Fehler bei Verbindung", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Ein unbekannter Fehler ist aufgetreten", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        #region tools
        /// <summary>
        /// Schreibt angegebenen Text in die Log Textbox
        /// </summary>
        /// <param name="text">Text der geschrieben werden soll</param>
        private void writeToLog(string text)
        {
            // Schreibt in txt_log + neue Line
            txt_log.Text += $"{text}\n";
        }
        #endregion
    }
}
