using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using LogicLibrary.Printers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.OID
{
    public class PrinterModel
    {
        private string ip = string.Empty;
        private string oid = string.Empty;

        public PrinterModel(string ip, string oid)
        {
            this.ip = ip;
            this.oid = oid;
        }

        public string GetPrinterModelFromIPAndOID()
        {
            string printerModel = string.Empty;
            try
            {
                var result = Messenger.Get(VersionCode.V1,
                           new IPEndPoint(IPAddress.Parse(ip), 161),
                           new OctetString("public"),
                           new List<Variable> { new Variable(new ObjectIdentifier(oid)) },
                           2000);
                string oidresult = string.Empty;
                foreach (var item in result)
                {
                    oidresult += item.ToString();
                }
                //MyDescription = oidresult;

                foreach (var item in result)
                {
                    foreach (var printerItem in new DictionaryPrinters().PrintersDictionary.Keys)
                    {
                        if (item.Data.ToString().ToLower().Contains(printerItem))
                        {
                            var array = item.Data.ToString().Split(';');
                            foreach (var it in array)
                            {
                                if (it.ToLower().Contains(printerItem))
                                {
                                    printerModel = it;
                                    return printerModel;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return printerModel;
        }
    }
}
