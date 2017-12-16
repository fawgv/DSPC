using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
    public class RemouteMethods
    {
        public List<string> GetFolders { get; set; }
        public RemouteMethods()
        {

            GetFolders = new List<string>();
        }

        public RemouteMethods(string ipAddress)
        {
            try
            {
                List<string> listfolders = new List<string>();
                string[] notUse = new string[] { "All Users", "Default User", "Public", "Администратор", "Все пользователи" };
                foreach (var folder in System.IO.Directory.GetDirectories($"\\\\{ipAddress}\\c$\\users"))
                {
                    if (!notUse.Contains(folder.Replace($"\\\\{ipAddress}\\c$\\users\\","")))
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
    }
}
