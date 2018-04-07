using LogicLibrary;
using LogicLibrary.Commands;
using LogicLibrary.Printers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPC.ViewModel.RibbonModel
{
    public class PrinterRibbonTabVM
    {
        public string PrinterModel { get; set; } = string.Empty;

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

        private RelayCommand refreshPrinter;
        /// <summary>
        /// Комманда 
        /// </summary>
        public RelayCommand RefreshPrinter
        {
            get
            {
                return refreshPrinter ??
                  (refreshPrinter = new RelayCommand(obj =>
                  {
                      try
                      {
                          var printmod = new LogicLibrary.OID.PrinterModel(LogicalBase.PrinterIP, "1.3.6.1.2.1.25.3.2.1.3.1");
                          var temp = printmod.GetPrinterModelFromIPAndOID();
                          PrinterModel = temp;
                      }
                      catch (Exception ex)
                      {
                          
                      }
                      

                  }//,
                  //(e) => { return Bindings.SelectedIP != null; }
                  ));
            }
        }

        private RelayCommand devPrinters_Executed;
        /// <summary>
        /// Комманда 
        /// </summary>
        public RelayCommand DevPrinters_Executed
        {
            get
            {
                return devPrinters_Executed ??
                  (devPrinters_Executed = new RelayCommand(obj =>
                  {
                      try
                      {
                          ProcessStartInfo expl = new ProcessStartInfo("control.exe")
                          {
                              Arguments = "printers"
                          };
                          Process.Start(expl);
                      }
                      catch (Exception)
                      {
                      }

                  }//,
                  //(e) => { return Bindings.SelectedIP != null; }
                  ));
            }
        }
        

        private RelayCommand killPrinters;
        /// <summary>
        /// Комманда 
        /// </summary>
        public RelayCommand KillPrinters
        {
            get
            {
                return killPrinters ??
                  (killPrinters = new RelayCommand(obj =>
                  {
                      new RemoveAllPrinters();
                  }//,
                  //(e) => { return Bindings.SelectedIP != null; }
                  ));
            }
        }

        private RelayCommand printerManagement;
        /// <summary>
        /// Комманда 
        /// </summary>
        public RelayCommand PrinterManagement
        {
            get
            {
                return printerManagement ??
                  (printerManagement = new RelayCommand(obj =>
                  {
                      try
                      {
                          Process process = new Process();
                          ProcessStartInfo psi = new ProcessStartInfo("cmd.exe");
                          psi.Arguments = "/c mmc.exe printmanagement.msc";
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
