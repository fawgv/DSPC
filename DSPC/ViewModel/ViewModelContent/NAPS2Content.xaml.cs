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
    /// Логика взаимодействия для NAPS2Content.xaml
    /// </summary>
    public partial class NAPS2Content : TreeViewItem
    {
        public string MyDescription
        {
            get { return (string)GetValue(MyDescriptionProperty); }
            set { SetValue(MyDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDescriptionProperty =
            DependencyProperty.Register("MyDescription", typeof(string), typeof(NAPS2Content));

        public NAPS2Content()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"C:\Program Files (x86)\NAPS2\NAPS2.exe"))
            {
                Process.Start(@"C:\Program Files (x86)\NAPS2\NAPS2.exe");
            }
            else
            {
                System.Windows.MessageBox.Show(@"C:\Program Files (x86)\NAPS2\NAPS2.exe не найден");
            }
        }
        
        private void ButtonKillNaps2_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
            psi.Arguments = "/c taskkill /F /IM naps2*";
            Process.Start(psi);
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = Properties.Resources.naps2;
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            curListBox.SelectedIndex = -1;
        }
    }
}
