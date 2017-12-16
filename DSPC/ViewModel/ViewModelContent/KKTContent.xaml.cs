using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DSPC.ViewModel.ViewModelContent
{
    /// <summary>
    /// Логика взаимодействия для KKTContent.xaml
    /// </summary>
    public partial class KKTContent : TreeViewItem
    {
        public string MyDescription
        {
            get { return (string)GetValue(MyDescriptionProperty); }
            set { SetValue(MyDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDescriptionProperty =
            DependencyProperty.Register("MyDescription", typeof(string), typeof(KKTContent));

        public KKTContent()
        {
            InitializeComponent();
        }

        private void ButtonDrvFRTst_Click(object sender, RoutedEventArgs e)
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

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = "Настройка ККТ";
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            curListBox.SelectedIndex = -1;
        }

        private void StackPanelNew_MouseLeave(object sender, MouseEventArgs e)
        {
            curListBoxNew.SelectedIndex = -1;
        }

        private void StackPanelOld_MouseLeave(object sender, MouseEventArgs e)
        {
            curListBoxOld.SelectedIndex = -1;
        }

        private void ListBoxItemOpenTDrv_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = "Открыть тест драйвера";
        }

        private void ButtonNCPA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process process = new Process();
                ProcessStartInfo psi = new ProcessStartInfo("ncpa.cpl");
                process.StartInfo = psi;
                process.Start();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
