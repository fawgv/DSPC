﻿using System;
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
    /// Логика взаимодействия для ThunderbirdContent.xaml
    /// </summary>
    public partial class ThunderbirdContent : TreeViewItem
    {
        public string MyDescription
        {
            get { return (string)GetValue(MyDescriptionProperty); }
            set { SetValue(MyDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyDescriptionProperty =
            DependencyProperty.Register("MyDescription", typeof(string), typeof(ThunderbirdContent));


        public ThunderbirdContent()
        {
            InitializeComponent();
        }

        

        private void ButtonStartThunderbird_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists(@"C:\Program Files (x86)\Mozilla Thunderbird\thunderbird.exe"))
            {
                Process.Start(@"C:\Program Files (x86)\Mozilla Thunderbird\thunderbird.exe");
            }
            else
            {
                System.Windows.MessageBox.Show(@"C:\Program Files (x86)\Mozilla Thunderbird\thunderbird.exe не существует");
            }
        }
        
        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = "Запустить Thunderbird";
        }

        private void StackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            curListBox.SelectedIndex = -1;
        }

        private void ListBoxItemAddress_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = Properties.Resources.post_addr;
        }

        private void ListBoxItemServ_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = Properties.Resources.post_servers;
        }

        private void ListBoxItemSign_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = Properties.Resources.post_signature;
        }

        private void ListBoxItemTestMessage_Selected(object sender, RoutedEventArgs e)
        {
            MyDescription = Properties.Resources.post_test_message;
        }
    }
}
