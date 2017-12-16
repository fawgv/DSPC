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
    /// Логика взаимодействия для LiveWebCamContent.xaml
    /// </summary>
    public partial class LiveWebCamContent : TreeViewItem
    {
        public string MyDescriptionLVC
        {
            get { return (string)GetValue(MyDescriptionProperty); }
            set { SetValue(MyDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDescriptionProperty =
            DependencyProperty.Register("MyDescriptionLVC", typeof(string), typeof(LiveWebCamContent));

        public LiveWebCamContent()
        {
            InitializeComponent();
        }

        private void ButtonRunLiveWebCam_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"c:\Program Files (x86)\LiveWebCam\LiveWebCam.exe"))
            {
                Process.Start(@"c:\Program Files (x86)\LiveWebCam\LiveWebCam.exe");
            }
            else
            {
                System.Windows.MessageBox.Show(@"c:\Program Files (x86)\LiveWebCam\LiveWebCam.exe не найден" );
            }
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MyDescriptionLVC = "Необходимо проверить работу LiveWebCam, проверить сохранение фото.";
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            curListBox.SelectedIndex = -1;
        }
    }
}
