using Fluent;
using LogicLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

namespace DSPC.ViewModel.RibbonModel
{
    /// <summary>
    /// Логика взаимодействия для RibbonPanel.xaml
    /// </summary>
    public partial class RibbonPanel : Ribbon
    {
        LogicalBase logicBase = new LogicalBase();

        #region Свойства

        public bool ProjectVisible
        {
            get { return (bool)GetValue(ProjectVisibleProperty); }
            set { SetValue(ProjectVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectVisibleProperty =
            DependencyProperty.Register("ProjectVisible", typeof(bool), typeof(RibbonPanel));

        public bool VisibleTest
        {
            get { return (bool)GetValue(VisibleTestProperty); }
            set { SetValue(VisibleTestProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VisibleTest.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibleTestProperty =
            DependencyProperty.Register("VisibleTest", typeof(bool), typeof(RibbonPanel));

        #endregion

        public RibbonPanel()
        {
            InitializeComponent();
            //DataContext = this;
            #region Выбор IP адреса в comboBox
            for (int curIP = 0; curIP < logicBase.MyIPArray.Count; curIP++)
            {
                try
                {
                    var txtIP = logicBase.MyIPArray[curIP].ToString();
                    var tmpPer = txtIP.Split('.');
                    if (tmpPer.Count() == 4)
                    {
                        cbIPArray.SelectedIndex = curIP;
                        return;
                    }

                }
                catch (Exception)
                {
                }
            }


            #endregion
        }

        private void SetIPPrinter()
        {
            try
            {
                string[] temp = LogicalBase.MyIP.Split('.');
                temp[3] = "250";
                var ipTemp = String.Join(".", temp
                              .Select(s => s.ToString())
                              .ToArray());
                LogicalBase.PrinterIP = ipTemp;
            }
            catch (Exception)
            {

            }
        }

        private void tbMyIP_TextChanged(object sender, TextChangedEventArgs e)
        {
            LogicalBase.MyIP = tbMyIP.Text;
            SetIPPrinter();
        }

        private void ButtonProjectVisible_Click(object sender, RoutedEventArgs e)
        {
            if (tbProject.Password == "89094047282")
            {
                //tbProject.Text = "";
                ProjectVisible = true;
            }
        }

        private void RibbonElement_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        protected internal void DevMen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                Process proc;
                using (proc = new Process())
                {
                    ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                    psi.Arguments = "/c devmgmt.msc";
                    proc.StartInfo = psi;
                    proc.Start();
                }
            }
            catch (Exception)
            {
            }
        }

        private void Ncpa_cpl_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo psi = new ProcessStartInfo("ncpa.cpl");
                process.StartInfo = psi;
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DrvFR_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(@"C:\Program Files (x86)\SHTRIH-M\DrvFR 4.13\Bin\DrvFRTst.exe"))
                {
                    Process.Start(@"C:\Program Files (x86)\SHTRIH-M\DrvFR 4.13\Bin\DrvFRTst.exe");
                }
                else
                {
                    System.Windows.MessageBox.Show("DrvFRTst.exe не существует");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DriveFlash_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                DriveInfo[] D = DriveInfo.GetDrives();
                string flashDrive = string.Empty;
                foreach (DriveInfo DI in D)
                {
                    if (DI.DriveType == DriveType.Removable && DI.Name != @"A:\" && DI.Name != @"B:\")
                    {
                        //MessageBox.Show("Буква флешки: " + Convert.ToString(DI.Name));
                        flashDrive = Convert.ToString(DI.Name);
                        break;
                    }
                }
                ProcessStartInfo expl = new ProcessStartInfo("explorer.exe");
                expl.Arguments = flashDrive;
                Process.Start(expl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenFolder_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                ProcessStartInfo expl = new ProcessStartInfo("explorer.exe");
                expl.Arguments = (e.OriginalSource as Fluent.Button).Tag.ToString();
                Process.Start(expl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Console_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                ProcessStartInfo expl = new ProcessStartInfo("Cmd.exe");
                Process.Start(expl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DevPrinters_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                ProcessStartInfo expl = new ProcessStartInfo("control.exe");
                expl.Arguments = "printers";
                Process.Start(expl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
