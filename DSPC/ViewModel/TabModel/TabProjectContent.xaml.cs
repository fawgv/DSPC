using LogicLibrary;
using System;
using System.Collections.Generic;
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

namespace DSPC.ViewModel.TabModel
{
    /// <summary>
    /// Логика взаимодействия для TabProjectContent.xaml
    /// </summary>
    public partial class TabProjectContent : UserControl
    {
        public TabProjectContent()
        {
            InitializeComponent();
        }

        private void ButtonPrintFoldersUsers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RemouteMethods remMeth = new RemouteMethods(tbIP.Text);
                StringBuilder folders = new StringBuilder();

                foreach (var item in remMeth.GetFolders)
                {
                    folders.AppendLine(item);
                }
                MessageBox.Show(folders.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ButtonVerifyFileExist_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RemouteMethods remMeth = new RemouteMethods(tbIP.Text);
                foreach (var folder in remMeth.GetFolders)
                {
                    var path = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip.ini");
                    if (System.IO.File.Exists(path))
                    {
                        MessageBox.Show($"Найден файл {path}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ButtonDisplayFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RemouteMethods remMeth = new RemouteMethods(tbIP.Text);
                foreach (var folder in remMeth.GetFolders)
                {
                    var path = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip.ini");
                    if (System.IO.File.Exists(path))
                    {
                        using (StreamReader fileRead = new StreamReader(path))
                        {
                            while (!fileRead.EndOfStream)
                            {
                                var tempLine = fileRead.ReadLine();
                                if (tempLine.Contains("audioCodecs"))
                                {
                                    MessageBox.Show(tempLine);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void ButtonCreateBackUpFileSettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RemouteMethods remMeth = new RemouteMethods(tbIP.Text);
                foreach (var folder in remMeth.GetFolders)
                {
                    var path = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip.ini");
                    var pathDest = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip_arch.ini");
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Copy(path, pathDest);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ButtonReplaseCodecsInFileSettings_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RemouteMethods remMeth = new RemouteMethods(tbIP.Text);
                foreach (var folder in remMeth.GetFolders)
                {
                    var path = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip.ini");
                    var pathNew = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip_new.ini");
                    if (System.IO.File.Exists(path))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(pathNew, false, Encoding.Default) /*File.Create(pathNew)*/)
                        {
                            using (StreamReader fileRead = new StreamReader(path, Encoding.Default))
                            {
                                while (!fileRead.EndOfStream)
                                {
                                    var tempLine = fileRead.ReadLine();
                                    if (tempLine.Contains("audioCodecs"))
                                    {
                                        tempLine = "audioCodecs=G729/8000/1 GSM/8000/1 speex/8000/1 iLBC/8000/1 PCMA/8000/1";
                                    }
                                    if (tempLine.Contains("crashReport"))
                                    {
                                        tempLine = "crashReport=0";
                                    }
                                    streamWriter.WriteLine(tempLine);
                                }

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonReplaceSettingsFileOnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RemouteMethods remMeth = new RemouteMethods(tbIP.Text);
                foreach (var folder in remMeth.GetFolders)
                {
                    var path = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip.ini");
                    var pathNew = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip_new.ini");
                    var pathArch = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip_arch.ini");
                    if (System.IO.File.Exists(path) && (System.IO.File.Exists(pathNew)))
                    {
                        System.IO.File.Replace(pathNew, path, pathArch);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonComplexSetting_Click(object sender, RoutedEventArgs e)
        {
            ButtonReplaseCodecsInFileSettings_Click(sender, e);
            ButtonReplaceSettingsFileOnNew_Click(sender, e);
        }

        private void ButtonComplexSettingDiapasone_Click(object sender, RoutedEventArgs e)
        {
            for (int cvz_numb = 2; cvz_numb < 391; cvz_numb++)
            {

                for (int i = 1; i < 3; i++)
                {
                    string cvz = string.Format("{0:d3}", cvz_numb) + i;
                    string cvzPCName = $"cvzr-{cvz}";

                    try
                    {
                        
                        RemouteMethods remMeth = new RemouteMethods(cvzPCName);
                        foreach (var folder in remMeth.GetFolders)
                        {
                            var path = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip.ini");
                            var pathNew = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip_new.ini");
                            if (System.IO.File.Exists(path))
                            {
                                using (StreamWriter streamWriter = new StreamWriter(pathNew, false, Encoding.Default) /*File.Create(pathNew)*/)
                                {
                                    using (StreamReader fileRead = new StreamReader(path, Encoding.Default))
                                    {
                                        while (!fileRead.EndOfStream)
                                        {
                                            var tempLine = fileRead.ReadLine();
                                            if (tempLine.Contains("audioCodecs"))
                                            {
                                                tempLine = "audioCodecs=G729/8000/1 GSM/8000/1 speex/8000/1 iLBC/8000/1 PCMA/8000/1";
                                            }
                                            if (tempLine.Contains("crashReport"))
                                            {
                                                tempLine = "crashReport=0";
                                            }
                                            streamWriter.WriteLine(tempLine);
                                        }

                                    }
                                }

                            }
                        }
                        foreach (var folder in remMeth.GetFolders)
                        {
                            var path = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip.ini");
                            var pathNew = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip_new.ini");
                            var pathArch = System.IO.Path.Combine(folder, @"AppData\Roaming\MicroSIP", "microsip_arch.ini");
                            if (System.IO.File.Exists(path) && (System.IO.File.Exists(pathNew)))
                            {
                                System.IO.File.Replace(pathNew, path, pathArch);
                            }
                        }
                    }

                    catch (Exception)
                    {
                        try
                        {
                            using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\afedorenko\Desktop\CVZ_microsip.txt", true, Encoding.Default) /*File.Create(pathNew)*/)
                            {
                                streamWriter.WriteLine($"{cvzPCName} не настроен");
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }

                }

            }

        }
    }
}
