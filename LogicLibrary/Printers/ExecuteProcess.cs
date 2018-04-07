using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LogicLibrary.Printers
{

    public class ExecuteProcess
    {
        public TypeExecuteProcess Type { get; set; }
        public string ValueProcess { get; set; }

        public ExecuteProcess()
        {

        }

        public ExecuteProcess(TypeExecuteProcess type, string valueProcess)
        {
            Type = type;
            ValueProcess = valueProcess;
        }

        public void ExecuteProgram()
        {
            if (Type == TypeExecuteProcess.Process)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo(ValueProcess);
                    using (Process process = new Process())
                    {
                        process.StartInfo = psi;
                        process.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (Type == TypeExecuteProcess.Link)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
                    using (Process process = new Process())
                    {
                        psi.Arguments = ValueProcess;
                        process.StartInfo = psi;
                        process.Start();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (Type == TypeExecuteProcess.Folder)
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo(@"explorer.exe");
                    using (Process process = new Process())
                    {
                        psi.Arguments = ValueProcess;
                        process.StartInfo = psi;
                        process.Start();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }

}
