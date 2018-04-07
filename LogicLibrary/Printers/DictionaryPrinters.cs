using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.Printers
{
    public class DictionaryPrinters
    {
        public Dictionary<string, ExecuteProcess> PrintersDictionary { get; private set; } = new Dictionary<string, ExecuteProcess>();

        public DictionaryPrinters()
        {
            FillDictionaryPrinters();
        }

        void FillDictionaryPrinters()
        {
            //HP
            PrintersDictionary.Add("m225", new ExecuteProcess(TypeExecuteProcess.Process, @"c:\_Drivers\HP 225\HP_LJ_Pro_MFP_M225-M226_Full_Solution_16078.exe"));
            PrintersDictionary.Add("m121", new ExecuteProcess(TypeExecuteProcess.Process, @"c:\_Drivers\HP 1212-1217\LJM1130_M1210_MFP_Full_Solution.exe"));
            PrintersDictionary.Add("m426", new ExecuteProcess(TypeExecuteProcess.Process, @"c:\_Drivers\HP 426-427\HP_LJ_Pro_MFP_M426f-M427f-PCL_6_v3_Full_Solution_17171.exe"));
            PrintersDictionary.Add("m1536", new ExecuteProcess(TypeExecuteProcess.Link, @"https://support.hp.com/ru-ru/drivers/selfservice/hp-laserjet-pro-m1536-multifunction-printer-series/3974271/model/3974278"));
            PrintersDictionary.Add("m127", new ExecuteProcess(TypeExecuteProcess.Process, @"C:\_Drivers\HP 126-127\LJPro_MFP_M127-M128_full_solution_15309.exe"));
            PrintersDictionary.Add("m2727", new ExecuteProcess(TypeExecuteProcess.Link, @"https://support.hp.com/ru-ru/drivers/selfservice/hp-laserjet-m2727-multifunction-printer-series/3377075/model/3377076"));
            PrintersDictionary.Add("3055", new ExecuteProcess(TypeExecuteProcess.Link, @"https://support.hp.com/ru-ru/drivers/selfservice/hp-laserjet-3055-all-in-one-printer/1161389"));

            //Brother
            PrintersDictionary.Add("mfc-7860", new ExecuteProcess(TypeExecuteProcess.Process, @"c:\_Drivers\Brother 7860\MFC-7860DW-inst-C1-EEU.EXE"));
            PrintersDictionary.Add("mfc-7360", new ExecuteProcess(TypeExecuteProcess.Link, @"http://support.brother.com/g/b/downloadlist.aspx?c=ru&lang=ru&prod=mfc7360nr_eu&os=7"));
            PrintersDictionary.Add("dcp-7065", new ExecuteProcess(TypeExecuteProcess.Process, @"c:\_Drivers\Brother 7065\DCP-7065DN-inst-C1-EEU.EXE"));

            //Kyocera
            PrintersDictionary.Add("m2030", new ExecuteProcess(TypeExecuteProcess.Folder, @"c:\_Drivers\Kyocera M2035dn"));
            PrintersDictionary.Add("m2035", new ExecuteProcess(TypeExecuteProcess.Folder, @"c:\_Drivers\Kyocera M2035dn"));
            PrintersDictionary.Add("m2530", new ExecuteProcess(TypeExecuteProcess.Folder, @"c:\_Drivers\Kyocera M2035dn"));
            PrintersDictionary.Add("m2535", new ExecuteProcess(TypeExecuteProcess.Folder, @"c:\_Drivers\Kyocera M2035dn"));
            PrintersDictionary.Add("m2040", new ExecuteProcess(TypeExecuteProcess.Folder, @"c:\_Drivers\Kyocera 2040 Twain"));

            //Samsung
            PrintersDictionary.Add("scx-4x24", new ExecuteProcess(TypeExecuteProcess.Link, @"http://www.samsung.com/ru/support/model/SCX-4824FN/XEV"));
            PrintersDictionary.Add("scx-483", new ExecuteProcess(TypeExecuteProcess.Link, @"http://www.samsung.com/ru/support/model/SCX-4833FD/XEV"));

        }
    }
}
