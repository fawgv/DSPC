using MahApps.Metro.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace appbar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Fill();
        }

        void Fill()
        {

            ResourceDictionary resDic = new ResourceDictionary();
            resDic.Source = new Uri("/Resources/Icons.xaml", UriKind.RelativeOrAbsolute);
            ScrollViewer sv = new ScrollViewer();
            
            SortedDictionary<string, Canvas> sortedDict = new SortedDictionary<string, Canvas>();

            foreach (DictionaryEntry item in resDic)
            {
                sortedDict.Add(item.Key.ToString(), (Canvas)(item.Value));
            }

            

            foreach (var item in sortedDict)
            {
                ToggleButton tb = new ToggleButton();
                tb.Width = 130;
                tb.Height = 130;

                tb.VerticalAlignment = VerticalAlignment.Center;

                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Vertical;

                Rectangle rect = new Rectangle();
                rect.VerticalAlignment = VerticalAlignment.Center;
                rect.Width = 70;
                rect.Height = 70;
                var vBrush = new VisualBrush();

                Canvas canv = (Canvas)(item.Value);
                canv.Height = 70;
                canv.Width = 70;


                vBrush.Stretch = Stretch.Fill;
                rect.OpacityMask = vBrush;

                sp.Children.Add(canv);

                TextBlock textBlock = new TextBlock();
                textBlock.Text = item.Key;

                sp.Children.Add(textBlock);

                tb.Content = sp;

                tb.ToolTip = item.Key;
                //rect.Stretch = Stretch.Fill;
                wrapPanel.Children.Add(tb);
            }


        }
    }
}
