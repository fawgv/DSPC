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
    /// Логика взаимодействия для PreSettings.xaml
    /// </summary>
    public partial class PreSettings : TreeViewItem
    {

        public string MyDescription
        {
            get { return (string)GetValue(MyDescriptionProperty); }
            set { SetValue(MyDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDescriptionProperty =
            DependencyProperty.Register("MyDescription", typeof(string), typeof(PreSettings));



        public PreSettings()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pre_settings.exe")))
            {
                Process.Start(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pre_settings.exe"));
            }
            else
            {
                string file = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pre_settings.exe");
                System.Windows.MessageBox.Show($"{file} не найден");
            }
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = "lnkCameraIN";
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            curListBox.SelectedIndex = -1;
        }

        private void StackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            MyDescription = Properties.Resources.presettings;
        }
    }
}
