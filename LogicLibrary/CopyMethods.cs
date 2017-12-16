using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
    public class CopyMethods
    {
        public List<string> GetFolders { get; set; }

        public CopyMethods()
        {
            GetFolders = new List<string>();
        }

        public CopyMethods(string ipAddress)
        {
            try
            {
                List<string> listfolders = new List<string>();
                string[] notUse = new string[] { "All Users", "Default User", "Public", "Администратор", "Все пользователи" };
                foreach (var folder in System.IO.Directory.GetDirectories(@"c:\users"))
                {
                    if (!notUse.Contains(folder.Replace(@"c:\users\", "")))
                    {
                        listfolders.Add(folder);
                    }
                }

                GetFolders = listfolders;
            }
            catch (Exception)
            {

            }
        }
        public void CopyProgram(string[] arraySourceFolders, string destinationPath)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                foreach (string item in arraySourceFolders)
                {
                    using (Process process = new Process())
                    {
                        var arguments = $"/c robocopy %userprofile%\\{item} {destinationPath}\\{item} *.* /E";
                        psi.Arguments = arguments;
                        process.StartInfo = psi;
                        process.Start();
                    }
                }
            }
            catch (Exception)
            {
                
            }
            
        }
    }
}
