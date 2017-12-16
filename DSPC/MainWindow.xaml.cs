using LogicLibrary;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
//using System.Threading;
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

//using IWshRuntimeLibrary;  

namespace DSPC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public bool Test { get; set; }


        #region Свойства



        public bool CheckTopmost
        {
            get { return (bool)GetValue(CheckTopmostProperty); }
            set { SetValue(CheckTopmostProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckTopmost.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckTopmostProperty =
            DependencyProperty.Register("CheckTopmost", typeof(bool), typeof(MainWindow));




        public bool ProjectVisible
        {
            get { return (bool)GetValue(ProjectVisibleProperty); }
            set { SetValue(ProjectVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProjectVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProjectVisibleProperty =
            DependencyProperty.Register("ProjectVisible", typeof(bool), typeof(MainWindow));




        public bool VisibleTest
        {
            get { return (bool)GetValue(VisibleTestProperty); }
            set { SetValue(VisibleTestProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VisibleTest.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibleTestProperty =
            DependencyProperty.Register("VisibleTest", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));



        public double arhHeight
        {
            get { return (double)GetValue(arhHeightProperty); }
            set { SetValue(arhHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for arhHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty arhHeightProperty =
            DependencyProperty.Register("arhHeight", typeof(double), typeof(MainWindow));



        public string DescriptionTest
        {
            get { return (string)GetValue(DescriptionTestProperty); }
            set { SetValue(DescriptionTestProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DescriptionTest.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionTestProperty =
            DependencyProperty.Register("DescriptionTest", typeof(string), typeof(MainWindow));




        public ContentControl UIDescription
        {
            get { return (ContentControl)GetValue(UIDescriptionProperty); }
            set { SetValue(UIDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UIDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UIDescriptionProperty =
            DependencyProperty.Register("UIDescription", typeof(ContentControl), typeof(MainWindow));




        LogicalBase logicBase = new LogicalBase();

        //public string MyIP { get { return logicBase.MyIP; } set { } }
        //public string MyIP
        //{
        //    get
        //    {
        //        if (cbIPArray.SelectedValue!=null)
        //        {
        //            return cbIPArray.SelectedValue.ToString();
        //        }
        //        return string.Empty;
        //    }
        //    set { }
        //}
        public List<System.Net.IPAddress> MyIPArray { get { return logicBase.MyIPArray; } set { } }
        public string MyHost { get { return LogicalBase.MyHost; } set { } }


        #endregion
        
        #region Реализация интерфейса InotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public MainWindow()
        {
            Test = false;

            InitializeComponent();
            DataContext = this;
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DescriptionTest = "test";
            //toggleButtonTest.
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = new StackPanel();

            RichTextBox rtb = new RichTextBox();
            FlowDocument myFlowDoc = new FlowDocument();
            
            // Add paragraphs to the FlowDocument.
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 1")));
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 2")));
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 3")));

            rtb.Document = myFlowDoc;

            stackPanel.Children.Add(rtb);



            // Add initial content to the RichTextBox.
            BitmapImage bmp;
            //bmp.StreamSource = stream;
            using (MemoryStream memory = new MemoryStream())
            {
                Properties.Resources.Image1.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = memory;
                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.EndInit();
            }
            Image image = new Image();
            image.Stretch = Stretch.None;

            image.Source = bmp;

            stackPanel.Children.Add(image);

            myFlowDoc = new FlowDocument();
            rtb = new RichTextBox();
            // Add paragraphs to the FlowDocument.
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 1")));
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 2")));
            myFlowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 3")));

            rtb.Document = myFlowDoc;

            stackPanel.Children.Add(rtb);

            
            //stackPanel.Children.Add(image);
            UIDescription = new ContentControl();
            UIDescription.Content = stackPanel;

            //rtbTest.Document = myFlowDoc;
            //rtbTest.BeginChange();
            //TextPointer tp = rtbTest.CaretPosition.GetPositionAtOffset(0, LogicalDirection.Forward);
            //InlineUIContainer imageContainer = new InlineUIContainer(image, tp);
            //rtbTest.CaretPosition = imageContainer.ElementEnd;
            //rtbTest.EndChange();

        }

        private void RibbonElement_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DevMen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainRibbon.DevMen_Executed(sender, e);
        }
    }
}
