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
    /// Логика взаимодействия для PostSettingsContent.xaml
    /// </summary>
    public partial class PostSettingsContent : TreeViewItem
    {
        public string MyDescription
        {
            get { return (string)GetValue(MyDescriptionProperty); }
            set { SetValue(MyDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDescriptionProperty =
            DependencyProperty.Register("MyDescription", typeof(string), typeof(PostSettingsContent));


        public PostSettingsContent()
        {
            InitializeComponent();
        }
        
        private void ButtonPostSettings_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"c:\Users\DSAdmin\Desktop\post_settings.bat"))
            {
                Process.Start(@"c:\Users\DSAdmin\Desktop\post_settings.bat");
            }
            else
            {
                System.Windows.MessageBox.Show(@"c:\Users\DSAdmin\Desktop\post_settings.bat не найден");
            }
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = "После настройки всех полей постнастройка копирует данные из пользователя DSAdmin в пользователя default";
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            curListBox.SelectedIndex = -1;
        }
    }
}
