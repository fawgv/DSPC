using DSPC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DSPC.ViewModel.ViewModelContent
{
    /// <summary>
    /// Логика взаимодействия для CyberPlatContent.xaml
    /// </summary>
    public partial class CyberPlatContent : TreeViewItem
    {
        public string MyDescription
        {
            get { return (string)GetValue(MyDescriptionProperty); }
            set { SetValue(MyDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDescriptionProperty =
            DependencyProperty.Register("MyDescription", typeof(string), typeof(CyberPlatContent));


        public CyberPlatContent()
        {
            InitializeComponent();
        }

        private void ButtonOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo("explorer.exe");
            psi.Arguments = @"c:\cyberplat_module";
            Process.Start(psi);
        }



        private void ButtonCyberPlat_Click(object sender, RoutedEventArgs e)
        {
            DriveInfo[] D = DriveInfo.GetDrives();
            string flashDrive = string.Empty;
            foreach (DriveInfo DI in D)
            {
                if (DI.DriveType == DriveType.Removable)
                {
                    //MessageBox.Show("Буква флешки: " + Convert.ToString(DI.Name));
                    flashDrive = Convert.ToString(DI.Name);
                    break;
                }
            }
            ProcessStartInfo copyCyberKeys = new ProcessStartInfo("cmd.exe");
            copyCyberKeys.Arguments = $"/c robocopy {System.IO.Path.Combine(flashDrive, "cyberplat_module")} c:\\cyberplat_module *.* /E";
            Process.Start(copyCyberKeys);
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = "Скопировать ключи киберплат на диск С:";
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            curListBox.SelectedIndex = -1;
        }

        private void ListBoxItemVerify_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = "Выполнить проверку наличия ключей киберплат";
        }
    }
}
