using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
    public class UsersMethods
    {
        private string cUsers = @"c:\users";

        public List<string> FoldersUsers()
        {
            return System.IO.Directory.GetDirectories(cUsers).ToList<string>();
        }
    }
}
