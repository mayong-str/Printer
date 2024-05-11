using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace LabelCommon
{
    public static class PrinterClassAndXml
    {
        public static ArrayList Xml2Printers(string path)
        {
            ArrayList al = new ArrayList();
            XDocument xdoc = XDocument.Load(path);
            XElement xroot = xdoc.Root;
            return xml2Printers(xroot);
        }

        private static ArrayList xml2Printers(XElement xe)
        {
            ArrayList al = new ArrayList();
            IEnumerable<XElement> elements = xe.Elements();
            foreach (XElement item in elements)
            {
                al.Add(xml2Printer(xe));
            }
            return al;
        }

        private static ZebraPrinterClass xml2Printer(XElement xe)
        {
            ZebraPrinterClass pc = new ZebraPrinterClass("");
           // pc.Name = xe.Attribute("Name").Value;
            pc.DotPerMillimeter = int.Parse(xe.Element("DotPerMillimeter").Value);
           // pc.IP = xe.Element("IP").Value;
           // pc.Port = int.Parse(xe.Element("Port").Value);
            return pc;
        }
    }
}
