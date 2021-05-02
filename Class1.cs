using System;
using System.Net;
using System.Windows.Forms;

namespace double_ftp
{
    class ftpTools
    {
        public static void uploadFile(string URL, string user, string password, string content)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(user, password);
                    client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    client.UploadString((URL.EndsWith("/") ? URL + "/" : URL) + "", WebRequestMethods.Ftp.UploadFile, content);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                uploadFile(URL, user, password, content);
            }
        }
        public static string downloadFile(string URL, string user, string password)
        {
            WebClient request = new WebClient();
            request.Credentials = new NetworkCredential(user, password);
            request.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            byte[] newFileData = request.DownloadData(URL);
            string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
            request.Dispose();
            return fileString;
        }
    }
    class CommandHandling
    {
        /// <summary>
        /// Lädt Befehl hoch
        /// </summary>
        /// <param name="input">Die Eingabe in der Konsole</param>
        /// <param name="credentials">Die Anmeldedaten (URL, user, pass)</param>
        public static void executeCommand(string input, string url, string user, string pass, System.Windows.Forms.RichTextBox consoleBox)
        {
            System.Diagnostics.Debug.WriteLine(input);
            if (input == "" || input == " ")
                return;


            // Contentmit Zeit
            string commandContent = $"{DateTime.Now}\n{input}";

            // Läd hoch
            ftpTools.uploadFile(url, user, pass, commandContent);


            // Lädt runter was zurück gekommen ist und speichert es in variable
            string content = downloadCallBack(commandContent, url, user, pass);

            System.Diagnostics.Debug.WriteLine(content);
            consoleBox.Text += $"{content}\n";
        }

        private static string downloadCallBack(string commandContent, params string[] creds)
        {
            System.Threading.Thread.Sleep(3000);
            // Liest die Zeit aus
            string time = commandContent.Split('\n')[0];
            try { 
                string tempContent = ftpTools.downloadFile(creds[0], creds[1], creds[2]);
                // Wenn Callback neu ist (unterschiedliches Datum)
                if (tempContent.Split('\n')[0] != time)
                    return tempContent;
                // Wenn nicht dann "Exception" werfen damit zum catch block übergegangen wird
                else
                {
                    System.Diagnostics.Debug.WriteLine("Zeugs ist alt");
                    throw new WebException();
                }
            }
            catch (WebException) { return downloadCallBack(commandContent, creds); }
        }
    }
}
