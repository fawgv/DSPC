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
    /// Логика взаимодействия для iSpyContent.xaml
    /// </summary>
    public partial class iSpyContent : TreeViewItem
    {
        public string MyDescription
        {
            get { return (string)GetValue(MyDescriptionProperty); }
            set { SetValue(MyDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDescriptionProperty =
            DependencyProperty.Register("MyDescription", typeof(string), typeof(iSpyContent));

        public iSpyContent()
        {
            InitializeComponent();
        }

        private void ButtonRunSetupiSpy_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"c:\Windows\Scripts\ispy.ps1"))
            {
                ProcessStartInfo psi = new ProcessStartInfo(@"c:\windows\system32\WindowsPowerShell\v1.0\powershell.exe");
                psi.Arguments = @"c:\Windows\Scripts\ispy.ps1";
                Process.Start(psi);
            }
            else
            {
                System.Windows.MessageBox.Show(@"c:\Windows\Scripts\ispy.ps1 не найден");
            }
        }

        private void ButtonOpenTask_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"c:\Windows\system32\taskschd.msc"))
            {
                ProcessStartInfo psi = new ProcessStartInfo(@"c:\Windows\system32\taskschd.msc");
                psi.Arguments = "/s";
                Process.Start(psi);
            }
            else
            {
                System.Windows.MessageBox.Show(@"c:\Windows\system32\taskschd.msc не найден");
            }
        }

        private void ButtonOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo("explorer.exe");
            psi.Arguments = @"c:\video";
            Process.Start(psi);
        }
        
        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            curListBox.SelectedIndex = -1;
        }
        
        private void CheckBoxScript_Click(object sender, RoutedEventArgs e)
        {
            MyDescription = "Выполнить скрипт настройки iSpy";
        }

        private void CheckBoxSCHTask_Click(object sender, RoutedEventArgs e)
        {
            MyDescription = "Установить галочку в пункте \"Выполнять по требованию\" задания CAM. Запустить задание CAM.";
        }

        private void CheckBoxVerifyVideo_Click(object sender, RoutedEventArgs e)
        {
            MyDescription = "Выполнить проверку наличия видео-записей в папке Video.";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
