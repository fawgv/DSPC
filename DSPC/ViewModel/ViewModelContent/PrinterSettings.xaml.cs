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

namespace DSPC.ViewModel.ViewModelContent
{

    public static class myPrinters
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);
    }

    public enum TypeExecuteProcess
    {
        Process,
        Folder,
        Link
    }

    public class ExecuteProcess
    {
        public TypeExecuteProcess Type { get; set; }
        public string ValueProcess { get; set; }

        public ExecuteProcess()
        {

        }

        public ExecuteProcess(TypeExecuteProcess type, string valueProcess)
        {
            Type = type;
            ValueProcess = valueProcess;
        }

        public void ExecuteProgram()
        {
            if (Type == TypeExecuteProcess.Process)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo(ValueProcess);
                    using (Process process = new Process())
                    {
                        process.StartInfo = psi;
                        process.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (Type == TypeExecuteProcess.Link)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
                    using (Process process = new Process())
                    {
                        psi.Arguments = ValueProcess;
                        process.StartInfo = psi;
                        process.Start();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (Type == TypeExecuteProcess.Folder)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo(@"explorer.exe");
                    using (Process process = new Process())
                    {
                        psi.Arguments = ValueProcess;
                        process.StartInfo = psi;
                        process.Start();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }

    /// <summary>
    /// Логика взаимодействия для PrinterSettings.xaml
    /// </summary>
    public partial class PrinterSettingsContent : TreeViewItem
    {
        Dictionary<string, ExecuteProcess> dictionaryPrinters = new Dictionary<string, ExecuteProcess>();

        void FillDictionaryPrinters()
        {

            //HP
            dictionaryPrinters.Add("m225", new ExecuteProcess(TypeExecuteProcess.Process, @"c:\_Drivers\HP 225\HP_LJ_Pro_MFP_M225-M226_Full_Solution_16078.exe"));
            dictionaryPrinters.Add("m121", new ExecuteProcess(TypeExecuteProcess.Process, @"c:\_Drivers\HP 1212-1217\LJM1130_M1210_MFP_Full_Solution.exe"));
            dictionaryPrinters.Add("m426", new ExecuteProcess(TypeExecuteProcess.Process, @"c:\_Drivers\HP 426-427\HP_LJ_Pro_MFP_M426f-M427f-PCL_6_v3_Full_Solution_17171.exe"));
            dictionaryPrinters.Add("m1536", new ExecuteProcess(TypeExecuteProcess.Link, @"https://support.hp.com/ru-ru/drivers/selfservice/hp-laserjet-pro-m1536-multifunction-printer-series/3974271/model/3974278"));
            dictionaryPrinters.Add("m127", new ExecuteProcess(TypeExecuteProcess.Process, @"C:\_Drivers\HP 126-127\LJPro_MFP_M127-M128_full_solution_15309.exe"));
            dictionaryPrinters.Add("m2727", new ExecuteProcess(TypeExecuteProcess.Link, @"https://support.hp.com/ru-ru/drivers/selfservice/hp-laserjet-m2727-multifunction-printer-series/3377075/model/3377076"));
            dictionaryPrinters.Add("3055", new ExecuteProcess(TypeExecuteProcess.Link, @"https://support.hp.com/ru-ru/drivers/selfservice/hp-laserjet-3055-all-in-one-printer/1161389"));

            //Brother
            dictionaryPrinters.Add("mfc-7860", new ExecuteProcess(TypeExecuteProcess.Process, @"c:\_Drivers\Brother 7860\MFC-7860DW-inst-C1-EEU.EXE"));
            dictionaryPrinters.Add("mfc-7360", new ExecuteProcess(TypeExecuteProcess.Link, @"http://support.brother.com/g/b/downloadlist.aspx?c=ru&lang=ru&prod=mfc7360nr_eu&os=7"));
            dictionaryPrinters.Add("dcp-7065", new ExecuteProcess(TypeExecuteProcess.Process, @"c:\_Drivers\Brother 7065\DCP-7065DN-inst-C1-EEU.EXE"));

            //Kyocera
            dictionaryPrinters.Add("m2030", new ExecuteProcess(TypeExecuteProcess.Folder, @"c:\_Drivers\Kyocera M2035dn"));
            dictionaryPrinters.Add("m2035", new ExecuteProcess(TypeExecuteProcess.Folder, @"c:\_Drivers\Kyocera M2035dn"));
            dictionaryPrinters.Add("m2530", new ExecuteProcess(TypeExecuteProcess.Folder, @"c:\_Drivers\Kyocera M2035dn"));
            dictionaryPrinters.Add("m2535", new ExecuteProcess(TypeExecuteProcess.Folder, @"c:\_Drivers\Kyocera M2035dn"));
            dictionaryPrinters.Add("m2040", new ExecuteProcess(TypeExecuteProcess.Folder, @"c:\_Drivers\Kyocera 2040 Twain"));

            //Samsung
            dictionaryPrinters.Add("scx-4x24", new ExecuteProcess(TypeExecuteProcess.Link, @"http://www.samsung.com/ru/support/model/SCX-4824FN/XEV"));
            dictionaryPrinters.Add("scx-483", new ExecuteProcess(TypeExecuteProcess.Link, @"http://www.samsung.com/ru/support/model/SCX-4833FD/XEV"));

        }

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
            
            FillDictionaryPrinters();
            InitializeComponent();
            logicalBase = new LogicalBase();
            PrinterStringCollection = PrinterSettings.InstalledPrinters;
        }

        


        private void buttonPrinterSetting(object sender, RoutedEventArgs e)
        {
            try
            {

                ProcessStartInfo psi = new ProcessStartInfo(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
                psi.Arguments = $"http:////{LogicalBase.PrinterIP}";
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
            ProcessStartInfo expl = new ProcessStartInfo("explorer.exe");
            expl.Arguments = @"C:\_Drivers";
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
                    foreach (var printerItem in dictionaryPrinters.Keys)
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
            MessageBox.Show(GetPrinterModel(LogicalBase.PrinterIP, "1.3.6.1.2.1.25.3.2.1.3.1"));
            GetPrinterModelProcessing(LogicalBase.PrinterIP, "1.3.6.1.2.1.25.3.2.1.3.1").ExecuteProgram();

        }

        private string GetPrinterModel(string IP, string oid)
        {
            string printerModel = string.Empty;
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
                    foreach (var printerItem in dictionaryPrinters.Keys)
                    {
                        if (item.Data.ToString().ToLower().Contains(printerItem))
                        {
                            var array = item.Data.ToString().Split(';');
                            foreach (var it in array)
                            {
                                if (it.ToLower().Contains(printerItem))
                                {
                                    printerModel = it;
                                    return printerModel;
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
                    foreach (var printerItem in dictionaryPrinters.Keys)
                    {
                        if (item.Data.ToString().ToLower().Contains(printerItem))
                        {
                            var array = item.Data.ToString().Split(';');
                            foreach (var it in array)
                            {
                                if (it.ToLower().Contains(printerItem))
                                {
                                    return dictionaryPrinters[printerItem];
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
