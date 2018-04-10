using LogicLibrary.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPC.ViewModel.ViewModelContent.VideoRecord
{
    public class DViewCamTabVM
    {
        private RelayCommand runCommand;
        /// <summary>
        /// Комманда 
        /// </summary>
        public RelayCommand RunCommand
        {
            get
            {
                return runCommand ??
                  (runCommand = new RelayCommand(obj =>
                  {

                  }//,
                  //(e) => { return Bindings.SelectedIP != null; }
                  ));
            }
        }

        private RelayCommand copyDViewCam;
        /// <summary>
        /// Комманда 
        /// </summary>
        public RelayCommand CopyDViewCam
        {
            get
            {
                return copyDViewCam ??
                  (copyDViewCam = new RelayCommand(obj =>
                  {
                      try
                      {
                          Process process = new Process();
                          ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
                          {
                              Arguments = "/k robocopy \\\\dengisrazy.ru\\SYSVOL\\dengisrazy.ru\\Distrib\\DLink C:\\Users\\Public\\Distr\\DLink *.* /z"
                          };
                          process.StartInfo = psi;
                          process.Start();
                      }
                      catch (Exception)
                      {
                      }
                  }//,
                  //(e) => { return Bindings.SelectedIP != null; }
                  ));
            }
        }

        private RelayCommand openRepos;
        /// <summary>
        /// Комманда 
        /// </summary>
        public RelayCommand OpenRepos
        {
            get
            {
                return openRepos ??
                  (openRepos = new RelayCommand(obj =>
                  {
                      try
                      {
                          Process process = new Process();
                          ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
                          {
                              Arguments = "/k explorer.exe \\\\dengisrazy.ru\\sysvol\\dengisrazy.ru\\Distrib\\DLink"
                          };
                          process.StartInfo = psi;
                          process.Start();
                      }
                      catch (Exception)
                      {
                      }
                  }//,
                  //(e) => { return Bindings.SelectedIP != null; }
                  ));
            }
        }


        private RelayCommand install;
        /// <summary>
        /// Комманда 
        /// </summary>
        public RelayCommand Install
        {
            get
            {
                return install ??
                  (install = new RelayCommand(obj =>
                  {
                      try
                      {
                          Process process = new Process();
                          ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
                          {

                              Arguments = "/k powershell.exe C:\\Users\\Public\\Distr\\DLink\\dlink_new.ps1"
                              //cmd.exe /c    powershell.exe c:\\users\\public\\distr\\dlink\\dlink_new.ps1
                          };
                          process.StartInfo = psi;
                          process.Start();
                      }
                      catch (Exception)
                      {
                      }
                      

                  }//,
                  //(e) => { return Bindings.SelectedIP != null; }
                  ));
            }
        }
    }
}
