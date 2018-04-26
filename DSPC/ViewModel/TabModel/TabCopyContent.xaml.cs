using LogicLibrary;
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

namespace DSPC.ViewModel.TabModel
{
    /// <summary>
    /// Логика взаимодействия для TabCopyContent.xaml
    /// </summary>
    public partial class TabCopyContent : UserControl
    {

        public List<FolderCheckListClass> UsersList
        {
            get { return (List<FolderCheckListClass>)GetValue(UsersDictionariesProperty); }
            set { SetValue(UsersDictionariesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UsersDictionaries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UsersDictionariesProperty =
            DependencyProperty.Register("UsersDictionaries", typeof(List<FolderCheckListClass>), typeof(TabCopyContent));

        
        public List<ProgramsToCopyCheckListClass> ProgramsList
        {
            get { return (List<ProgramsToCopyCheckListClass>)GetValue(ProgramsListProperty); }
            set { SetValue(ProgramsListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProgramsList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProgramsListProperty =
            DependencyProperty.Register("ProgramsList", typeof(List<ProgramsToCopyCheckListClass>), typeof(TabCopyContent));



        public TabCopyContent()
        {
            InitializeComponent();
            DataContext = this;
            CreateListFolders();
            CreateListPrograms();
        }

        private void ButtonVerifyCheckedFolders_Click(object sender, RoutedEventArgs e)
        {

            StringBuilder sb = new StringBuilder();

            foreach (var item in UsersList)
            {
                if (((FolderCheckListClass)item).IsChecked)
                {
                    sb.AppendLine((item as FolderCheckListClass).Name);
                }
            }
            MessageBox.Show(sb.ToString());
        }

        private void ButtonRefreshFoldersList_Click(object sender, RoutedEventArgs e)
        {
            CreateListFolders();
        }

        private void CreateListFolders()
        {
            UsersMethods usersMethods = new UsersMethods();
            //testListBox.ItemsSource = usersMethods.FoldersUsers();
            List<FolderCheckListClass> listFCL = new List<FolderCheckListClass>();

            foreach (var item in usersMethods.FoldersUsers())
            {
                listFCL.Add(new FolderCheckListClass() { Name = item });
            }
            UsersList = listFCL;
        }

        private void CreateListPrograms()
        {
            ProgramsList = new List<ProgramsToCopyCheckListClass>();
            ProgramsList.Add(new ProgramsToCopyCheckListClass("NAPS2", new string[] { @"AppData\Roaming\NAPS2", @"AppData\Roaming\Kyocera", @"AppData\Local\HP" }));
            ProgramsList.Add(new ProgramsToCopyCheckListClass("Kyocera", new string[] { @"AppData\Roaming\Kyocera" }));
            ProgramsList.Add(new ProgramsToCopyCheckListClass("Mozilla Thunderbird", new string[] { @"AppData\Local\Thunderbird", @"AppData\Roaming\Thunderbird" }));
            ProgramsList.Add(new ProgramsToCopyCheckListClass("LiveWebCam", new string[] { @"AppData\Local\VirtualStore" }));
            ProgramsList.Add(new ProgramsToCopyCheckListClass("MicroSip", new string[] { @"AppData\Roaming\MicroSIP" }));
            ProgramsList.Add(new ProgramsToCopyCheckListClass("iSpy", new string[] { @"AppData\Roaming\iSpy" }));
            ProgramsList.Add(new ProgramsToCopyCheckListClass("Google Chrome", new string[] { @"AppData\Local\Google\Chrome" }));
        }

        private void ButtonCopyData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CopyMethods copyMethods = new CopyMethods(LogicalBase.MyHost);

                foreach (ProgramsToCopyCheckListClass program in ProgramsList)
                {
                    if (program.IsChecked)
                    {

                        foreach (var folder in copyMethods.GetFolders)
                        {
                            copyMethods.CopyProgram(program.Folders, folder);
                        }
                        
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
