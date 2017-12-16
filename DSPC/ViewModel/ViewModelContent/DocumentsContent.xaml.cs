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

namespace DSPC.ViewModel.ViewModelContent
{
    /// <summary>
    /// Логика взаимодействия для DocumentsContent.xaml
    /// </summary>
    public partial class DocumentsContent : TreeViewItem
    {
        public string MyDescription
        {
            get { return (string)GetValue(MyDescriptionProperty); }
            set { SetValue(MyDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDescriptionProperty =
            DependencyProperty.Register("MyDescription", typeof(string), typeof(DocumentsContent));


        public DocumentsContent()
        {
            InitializeComponent();
        }

        private void ButtonOpenFlash_Click(object sender, RoutedEventArgs e)
        {
            DriveInfo[] D = DriveInfo.GetDrives();
            string flashDrive = string.Empty;
            foreach (DriveInfo DI in D)
            {
                if (DI.DriveType == DriveType.Removable&& DI.Name!=@"A:\" && DI.Name!=@"B:\")
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

        private void ButtonOpenС_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo expl = new ProcessStartInfo("explorer.exe");
            expl.Arguments = @"c:\UserData\Documents";
            Process.Start(expl);
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = "Необходимо скопировать сохраненные ранее документы в папку C:\\ProgramData\\Documents";
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            curListBox.SelectedIndex = -1;
        }
    }
}
