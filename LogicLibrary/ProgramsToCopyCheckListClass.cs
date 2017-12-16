using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
    public class ProgramsToCopyCheckListClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Folders { get; set; }
        public bool IsChecked { get; set; }

        public ProgramsToCopyCheckListClass()
        {

        }

        public ProgramsToCopyCheckListClass(string name, string[] folders)
        {
            Name = name;
            Folders = folders;
        }
    }
}
