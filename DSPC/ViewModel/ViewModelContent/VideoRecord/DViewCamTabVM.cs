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
                              Arguments = "/c robocopy \\\\dengisrazy.ru\\Distrib C:\\Users\\Public\\Distr *.* /z"
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
                              Arguments = "/c C:\\Users\\Public\\Distr\\dlink_new.ps1}"
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
