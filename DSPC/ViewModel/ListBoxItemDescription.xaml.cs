using System;
using System.Collections.Generic;
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

namespace DSPC.ViewModel
{
    /// <summary>
    /// Логика взаимодействия для ListBoxItemDescription.xaml
    /// </summary>
    public partial class ListBoxItemDescription : ListBoxItem
    {
        public string ButtonLBI { get; set; }
        public string LabelLBI { get; set; }
        public bool CheckBoxLBI { get; set; }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(ListBoxItemDescription));


        public ListBoxItemDescription()
        {
            InitializeComponent();
            DataContext = this;
        }
        
    }
}
