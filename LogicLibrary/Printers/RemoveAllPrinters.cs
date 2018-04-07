using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Management;
using System.Diagnostics;
using System.Net;

namespace LogicLibrary.Printers
{
    /// <summary>
    /// Удаляет все принтеры из системы "Устройства и принтеры"
    /// </summary>
    public class RemoveAllPrinters
    {
        public string Status { get; private set; } = string.Empty;
        public RemoveAllPrinters()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    ManagementClass win32Printer = new ManagementClass("Win32_Printer");
                    ManagementObjectCollection printers = win32Printer.GetInstances();
                    foreach (ManagementObject printer in printers)
                    {
                        printer.Delete();
                    }
                }
                catch (Exception)
                {
                    Status = "Ошибка удаления всех принтеров";
                }
                Status = "Все принтеры удалены из \"Устройства и принтеры\"";
            });
        }
    }
}
