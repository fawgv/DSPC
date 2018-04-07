using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogicLibrary;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using Lextm.SharpSnmpLib.Messaging;
using Lextm.SharpSnmpLib;
using System.Net;
using Lextm.SharpSnmpLib.Security;
using LogicLibrary.Printers;

namespace DSPC.ViewModel.ViewModelContent
{

    public static class myPrinters
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);
    }



    /// <summary>
    /// Логика взаимодействия для PrinterSettings.xaml
    /// </summary>
    public partial class PrinterSettingsContent : TreeViewItem
    {
        public string MyDescription
        {
            get { return (string)GetValue(MyDescriptionProperty); }
            set { SetValue(MyDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDescriptionProperty =
            DependencyProperty.Register("MyDescription", typeof(string), typeof(PrinterSettingsContent));


        #region Реализация интерфейса InotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        LogicalBase logicalBase;

        private PrinterSettings.StringCollection printerStringCollection;
        public PrinterSettings.StringCollection PrinterStringCollection
        {
            get { return printerStringCollection; }
            set
            {
                printerStringCollection = value;
                NotifyPropertyChanged("PrinterStringCollection");
            }
        }

        public ObservableCollection<string> Printers { get; set; }


        public PrinterSettingsContent()
        {
            InitializeComponent();
            logicalBase = new LogicalBase();
            PrinterStringCollection = PrinterSettings.InstalledPrinters;
        }




        private void buttonPrinterSetting(object sender, RoutedEventArgs e)
        {
            try
            {

                ProcessStartInfo psi = new ProcessStartInfo(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe")
                {
                    Arguments = $"http:////{LogicalBase.PrinterIP}"
                };
                Process.Start(psi);

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }


        }

        private void ButtonSetDefaultPrinter_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxPrinters.Text != null)
            {
                myPrinters.SetDefaultPrinter(comboBoxPrinters.Text);
                //SetPrinterToDefault(comboBoxPrinters.Text);
            }

            //WshNetwork network = new WshNetwork();

            //// получить список принтеров
            //IWshCollection Printers = network.EnumPrinterConnections();
            //if (Printers.Count() > 0)
            //{
            //    // индекс устанавливаемого принтера в списке принтеров
            //    object index = (object)"1";
            //    // установка принтера с выбранным индексом
            //    // как принтера по умолчанию
            //    network.SetDefaultPrinter((string)Printers.Item(ref index));
            //}

        }


        /// 

        /// method to set a specified printer as the system's default printer
        /// 

        /// name of the printer we want to be default/// Returns true if successfull
        /// Throws exception if printer not installed
        public bool SetPrinterToDefault(string printer)
        {
            //path we need for WMI
            string queryPath = "win32_printer.DeviceId='" + printer + "'";

            try
            {
                //ManagementObject for doing the retrieval
                ManagementObject managementObj = new ManagementObject(queryPath);

                //ManagementBaseObject which will hold the results of InvokeMethod
                ManagementBaseObject obj = managementObj.InvokeMethod("SetDefaultPrinter", null, null);

                //if we're null the something went wrong
                if (obj == null)
                    throw new Exception("Unable to set default printer.");

                //now get the return value and make our decision based on that
                int result = (int)obj.Properties["ReturnValue"].Value;

                if (result == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void ButtonRefreshPrinters_Click(object sender, RoutedEventArgs e)
        {

            //comboBoxPrinters.ItemsSource = printerStringCollection;
            PrinterStringCollection = null;
            PrinterStringCollection = PrinterSettings.InstalledPrinters;
            comboBoxPrinters.ItemsSource = PrinterStringCollection;
        }


        private void ButtonOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo expl = new ProcessStartInfo("explorer.exe")
            {
                Arguments = @"C:\_Drivers"
            };
            Process.Start(expl);
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = Properties.Resources.printerSettings;
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            curListBox.SelectedIndex = -1;
        }

        private void ButtonVerifySNMPOID_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = Messenger.Get(VersionCode.V1,
                           new IPEndPoint(IPAddress.Parse(tbIPPrinter.Text), 161),
                           new OctetString("public"),
                           new List<Variable> { new Variable(new ObjectIdentifier(tbOID.Text)) },
                           2000);
                string oidresult = string.Empty;
                foreach (var item in result)
                {
                    oidresult += item.ToString();
                }
                MyDescription = oidresult;

                foreach (var item in result)
                {
                    foreach (var printerItem in new DictionaryPrinters().PrintersDictionary.Keys)
                    {
                        if (item.Data.ToString().ToLower().Contains(printerItem))
                        {
                            var array = item.Data.ToString().Split(';');
                            foreach (var it in array)
                            {
                                if (it.ToLower().Contains(printerItem))
                                {
                                    tbVerSNMPOID.Text = it;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void ButtonVerifySNMPOIDAllRetail_Click(object sender, RoutedEventArgs e)
        {
            #region Перебор по ip адресам
            List<string> allpr = new List<string>();
            StringBuilder allprinters = new StringBuilder();
            for (int y = 8; y < 10; y++)
            {
                for (int i = 0; i < 255; i++)
                {
                    try
                    {
                        var result = Messenger.Get(VersionCode.V1,
                                   new IPEndPoint(IPAddress.Parse($"10.{y}.{i}.250"), 161),
                                   new OctetString("public"),
                                   new List<Variable> { new Variable(new ObjectIdentifier(tbOID.Text)) },
                                   50);
                        var ie = result[0].ToString();
                        var iee = ie.Split(':');
                        if (!allpr.Contains(iee[3]))
                        {
                            allpr.Add($"10.{y}.{i}.250 {iee[3]}");
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }


            foreach (var item in allpr)
            {
                allprinters.AppendLine(item);
            }

            MyDescription = allprinters.ToString();

            #endregion
        }

        private void ButtonVerifySNMPOIDAllLeningradskaya_Click(object sender, RoutedEventArgs e)
        {
            #region Перебор по ip адресам
            List<string> allpr = new List<string>();
            StringBuilder allprinters = new StringBuilder();
            for (int y = 8; y < 12; y++)
            {
                for (int i = 1; i < 255; i++)
                {
                    try
                    {
                        var result = Messenger.Get(VersionCode.V1,
                                   new IPEndPoint(IPAddress.Parse($"172.16.{y}.{i}"), 161),
                                   new OctetString("public"),
                                   new List<Variable> { new Variable(new ObjectIdentifier(tbOID.Text)) },
                                   50);
                        var ie = result[0].ToString();
                        var iee = ie.Split(':');
                        if (!allpr.Contains(iee[3]))
                        {
                            allpr.Add($"172.16.{y}.{i} {iee[3]}");
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }


            foreach (var item in allpr)
            {
                allprinters.AppendLine(item);
            }

            MyDescription = allprinters.ToString();

            #endregion
        }

        private void ButtonSetupPrinterDriver_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(new LogicLibrary.OID.PrinterModel(LogicalBase.PrinterIP, "1.3.6.1.2.1.25.3.2.1.3.1").GetPrinterModelFromIPAndOID());
            GetPrinterModelProcessing(LogicalBase.PrinterIP, "1.3.6.1.2.1.25.3.2.1.3.1").ExecuteProgram();

        }



        private ExecuteProcess GetPrinterModelProcessing(string IP, string oid)
        {
            ExecuteProcess printerModel = new ExecuteProcess();
            try
            {
                var result = Messenger.Get(VersionCode.V1,
                           new IPEndPoint(IPAddress.Parse(IP), 161),
                           new OctetString("public"),
                           new List<Variable> { new Variable(new ObjectIdentifier(oid)) },
                           2000);
                string oidresult = string.Empty;
                foreach (var item in result)
                {
                    oidresult += item.ToString();
                }
                MyDescription = oidresult;

                foreach (var item in result)
                {
                    foreach (var printerItem in new DictionaryPrinters().PrintersDictionary.Keys)
                    {
                        if (item.Data.ToString().ToLower().Contains(printerItem))
                        {
                            var array = item.Data.ToString().Split(';');
                            foreach (var it in array)
                            {
                                if (it.ToLower().Contains(printerItem))
                                {
                                    return new DictionaryPrinters().PrintersDictionary[printerItem];
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return printerModel;
        }
    }
}
