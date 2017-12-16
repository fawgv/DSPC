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
    /// Логика взаимодействия для VideoDriverContent.xaml
    /// </summary>
    public partial class VideoDriverContent : TreeViewItem
    {
        public string MyDescription
        {
            get { return (string)GetValue(MyDescriptionProperty); }
            set { SetValue(MyDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDescriptionProperty =
            DependencyProperty.Register("MyDescription", typeof(string), typeof(VideoDriverContent));


        public VideoDriverContent()
        {
            InitializeComponent();
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = Properties.Resources.videodriver;
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            curListBox.SelectedIndex = -1;
        }

        private void ButtonStartServ_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process proc;
                using (proc = new Process())
                {
                    ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                    psi.Arguments = "/c sc config wuauserv start= demand";
                    proc.StartInfo = psi;
                    proc.Start();
                }

                using (proc = new Process())
                {
                    ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                    psi.Arguments = "/c net start wuauserv";
                    proc.StartInfo = psi;
                    proc.Start();
                }
            }
            catch (Exception)
            {
            }
        }

        private void ButtonStopServ_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process proc;
                

                using (proc = new Process())
                {
                    ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                    psi.Arguments = "/c net stop wuauserv";
                    proc.StartInfo = psi;
                    proc.Start();
                }

                using (proc = new Process())
                {
                    ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                    psi.Arguments = "/c sc config wuauserv start= disabled";
                    proc.StartInfo = psi;
                    proc.Start();
                }
            }
            catch (Exception)
            {
            }
        }

        private void ButtonDevMgmt_Click(object sender, RoutedEventArgs e)
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
    }
}
