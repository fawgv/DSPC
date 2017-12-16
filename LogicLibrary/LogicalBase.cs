using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary
{
    public class LogicalBase
    {

        #region Реализация интерфейса InotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private static string description;
        public static string Description
        {
            get { return description; }
            set
            {
                description = value;
                //NotifyPropertyChanged("Description");
            }

        }

        // получаем хост
        private static string myHost = System.Net.Dns.GetHostName();
        public static string MyHost
        {
            get { return myHost; }
            set { myHost = value; }
        }

        
        //public string MyIP { get { return myIP; } set { myIP = value; } }
        public static string MyIP { get; set; }

        public static string PrinterIP { get; set; }

        public List<System.Net.IPAddress> MyIPArray { get { return System.Net.Dns.GetHostEntry(MyHost).AddressList.ToList(); } set { } }

        //public LogicalBase()
        //{
        //    MyIP = System.Net.Dns.GetHostEntry(MyHost).AddressList[0].ToString();
        //}

        private string pathApplication = AppDomain.CurrentDomain.BaseDirectory;
        public string PathApplication
        {
            get { return pathApplication; }
            set { pathApplication = value; }
        }


    }
}
