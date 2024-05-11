using System;
using System.Collections;
using System.Drawing;
using System.Xml.Linq;

namespace LabelCommon
{
    /// <summary>处理LabelFormatClass和XML文件的类
    /// 
    /// </summary>
    public static class LabelFormatAndXml
    {
        #region 将LabelFormatClass生成XML文件
        /// <summary>将LabelFormatClass生成XML文件
        /// 
        /// </summary>
        /// <param name="lfc"></param>
        public static void LabelFormat2Xml(LabelBasicInfoClass lbic, ArrayList elements, string path)
        {
            XDocument xdoc = new();
            XElement xroot = new("Label");
            xroot.Add(BasicInfo2Xml(lbic));
            xroot.Add(Elements2Xml(elements));
            xdoc.Add(xroot);
            xdoc.Save(path);
        }

        /// <summary>LabelBasicInfoClass转换为xml
        /// 
        /// </summary>
        /// <param name="lbi">LabelBasicInfoClass</param>
        /// <returns>XElement</returns>
        private static XElement BasicInfo2Xml(LabelBasicInfoClass lbi)
        {
            XElement xbasic = new("BasicInfo");
            xbasic.SetElementValue("Name", lbi.Name);
            xbasic.SetElementValue("Width_mm", lbi.Width);
            xbasic.SetElementValue("Height_mm", lbi.Height);
            xbasic.SetElementValue("LabelsPerLine", lbi.LabelsPerLine);
            xbasic.SetElementValue("Gap_mm", lbi.Gap);
            xbasic.SetElementValue("DotPerMillimeter", lbi.DotPerMillimeter);
            xbasic.SetElementValue("Width_Dot", lbi.LabelDotX);
            xbasic.SetElementValue("Height_Dot", lbi.LabelDotY);
            xbasic.SetElementValue("Gap_Dot", lbi.GapDot);
            return xbasic;
        }

        /// <summary>标签元素集合转换为xml
        /// 
        /// </summary>
        /// <param name="al">标签元素集合</param>
        /// <returns>XElement</returns>
        private static XElement Elements2Xml(ArrayList al)
        {
            XElement xelement = new XElement("Elements");
            foreach (var item in al)
            {
                if (item.GetType() == typeof(BarcodeElementClass))
                {
                    xelement.Add(BarcodeElement2Xml((BarcodeElementClass)item));
                }
                else if (item.GetType() == typeof(TextElementClass))
                {
                    xelement.Add(TextElement2Xml((TextElementClass)item));
                }
                else if (item.GetType() == typeof(QrCodeElementClass))
                {
                    xelement.Add(QrCodeElement2Xml((QrCodeElementClass)item));
                }
                else if (item.GetType() == typeof(LineElementClass))
                {
                    xelement.Add(LineElement2Xml((LineElementClass)item));
                }
                else if (item.GetType() == typeof(ImageElementClass))
                {
                    xelement.Add(ImageElement2Xml((ImageElementClass)item));
                }
            }
            return xelement;
        }

        /// <summary>BarcodeElementClass转换为xml
        /// 
        /// </summary>
        /// <param name="be">BarcodeElementClass</param>
        /// <returns>XElement</returns>
        private static XElement BarcodeElement2Xml(BarcodeElementClass be)
        {
            XElement xelement = new XElement("Barcode");
            xelement.SetAttributeValue("ID", be.ID);
            xelement.SetAttributeValue("X", be.X);
            xelement.SetAttributeValue("Y", be.Y);
            xelement.SetAttributeValue("ForeColor", ColorHelper.ToWin32String(be.ForeColor));
            xelement.SetAttributeValue("BackColor", ColorHelper.ToWin32String(be.BackColor));

            xelement.SetElementValue("Context", be.Context);
            xelement.SetElementValue("Height", be.Height);
            // xelement.SetElementValue("GS1", be.GS1);
            // xelement.SetElementValue("Pure", be.Pure);
            xelement.SetElementValue("RotateFlip", be.RotateFlip);
            xelement.SetElementValue("Magnify", be.Magnify);
            xelement.SetElementValue("Type", be.Type.ToString());
            xelement.SetElementValue("TextPosition", be.TextPosition.ToString());
            xelement.Add(Font2Xml(be.ViewTextFont));
            xelement.SetElementValue("Mapping", be.Mapping);
            return xelement;
        }

        /// <summary>TextElementClass转换为xml
        /// 
        /// </summary>
        /// <param name="te">TextElementClass</param>
        /// <returns>XElement</returns>
        private static XElement TextElement2Xml(TextElementClass te)
        {
            XElement xelement = new XElement("Text");
            xelement.SetAttributeValue("ID", te.ID);
            xelement.SetAttributeValue("X", te.X);
            xelement.SetAttributeValue("Y", te.Y);
            xelement.SetAttributeValue("ForeColor", ColorHelper.ToWin32String(te.ForeColor));
            xelement.SetAttributeValue("BackColor", ColorHelper.ToWin32String(te.BackColor));

            xelement.SetElementValue("Context", te.Context);
            xelement.SetElementValue("Width", te.Width);
            xelement.SetElementValue("Height", te.Height);
            xelement.SetElementValue("RotateFlip", te.RotateFlip);
            xelement.Add(Font2Xml(te.TextFont));
            xelement.SetElementValue("Inversion", te.Inversion);
            xelement.SetElementValue("TextAlign", te.TextAlign);
            xelement.SetElementValue("Mapping", te.Mapping);
            return xelement;
        }

        /// <summary>QrCodeElementClass转换为xml
        /// 
        /// </summary>
        /// <param name="qrec">QrCodeElementClass</param>
        /// <returns>XElement</returns>
        private static XElement QrCodeElement2Xml(QrCodeElementClass qrec)
        {
            XElement xelement = new XElement("QrCode");
            xelement.SetAttributeValue("ID", qrec.ID);
            xelement.SetAttributeValue("X", qrec.X);
            xelement.SetAttributeValue("Y", qrec.Y);
            xelement.SetAttributeValue("ForeColor", ColorHelper.ToWin32String(qrec.ForeColor));
            xelement.SetAttributeValue("BackColor", ColorHelper.ToWin32String(qrec.BackColor));

            xelement.SetElementValue("Context", qrec.Context);
            xelement.SetElementValue("ErrorCorrectionLevel", qrec.ErrorCorrectionLevel);
            xelement.SetElementValue("RotateFlip", qrec.RotateFlip);
            xelement.SetElementValue("Magnify", qrec.Magnify);
            xelement.SetElementValue("Mapping", qrec.Mapping);
            return xelement;
        }

        /// <summary>LineElementClass转换为xml
        /// 
        /// </summary>
        /// <param name="lec">LineElementClass</param>
        /// <returns>XElement</returns>
        private static XElement LineElement2Xml(LineElementClass lec)
        {
            XElement xelement = new XElement("Line");
            xelement.SetAttributeValue("ID", lec.ID);
            xelement.SetAttributeValue("X", lec.X);
            xelement.SetAttributeValue("Y", lec.Y);
            xelement.SetAttributeValue("ForeColor", ColorHelper.ToWin32String(lec.ForeColor));

            xelement.SetElementValue("Length", lec.Length);
            xelement.SetElementValue("Thickness", lec.Thickness);
            xelement.SetElementValue("RotateFlip", lec.RotateFlip);
            return xelement;
        }

        /// <summary>ImageElementClass转换为xml
        /// 
        /// </summary>
        /// <param name="iec">ImageElementClass</param>
        /// <returns>XElement</returns>
        private static XElement ImageElement2Xml(ImageElementClass iec)
        {
            XElement xelement = new XElement("Image");
            xelement.SetAttributeValue("ID", iec.ID);
            xelement.SetElementValue("FileFullPath", iec.FileFullPath);
            xelement.SetAttributeValue("X", iec.X);
            xelement.SetAttributeValue("Y", iec.Y);
            xelement.SetElementValue("RotateFlip", iec.RotateFlip);
            return xelement;
        }

        /// <summary>Font转换为xml
        /// 
        /// </summary>
        /// <param name="font">Font</param>
        /// <returns>XElement</returns>
        private static XElement Font2Xml(Font font)
        {
            XElement xelement = new XElement("Font");
            if (font == null)
            {
                xelement.SetValue("null");
            }
            else
            {
                xelement.SetValue(font.FontFamily.Name);
                xelement.SetAttributeValue("Size", font.Size);
                xelement.SetAttributeValue("Style", font.Style);
            }
            return xelement;
        }
        #endregion

        #region 从XML文件恢复LabelFormatClass
        /// <summary>从XML文件恢复LabelFormatClass
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void Xml2LabelFormat(string path, out LabelBasicInfoClass lbic, out ArrayList elements)
        {
            XDocument xdoc = XDocument.Load(path);
            XElement xroot = xdoc.Root;
            lbic = Xml2BasicInfo(xroot.Element("BasicInfo"));
            elements = Xml2Elements(xroot.Element("Elements"));
        }

        private static LabelBasicInfoClass Xml2BasicInfo(XElement xe) => new()
        {
            Name = xe.Element("Name").Value,
            Width = float.Parse(xe.Element("Width_mm").Value),
            Height = float.Parse(xe.Element("Height_mm").Value),
            DotPerMillimeter = int.Parse(xe.Element("DotPerMillimeter").Value),
            LabelsPerLine = int.Parse(xe.Element("LabelsPerLine").Value),
            Gap = float.Parse(xe.Element("Gap_mm").Value)
        };

        private static ArrayList Xml2Elements(XElement xe)
        {
            ArrayList resultArrayList = new();
            foreach (XElement item in xe.Elements())
            {
                switch (item.Name.LocalName)
                {
                    case "Text":
                        resultArrayList.Add(Xml2TextElement(item));
                        break;
                    case "Barcode":
                        resultArrayList.Add(Xml2BarcodeElement(item));
                        break;
                    case "QrCode":
                        resultArrayList.Add(Xml2QrCodeElement(item));
                        break;
                    case "Line":
                        resultArrayList.Add(Xml2LineElement(item));
                        break;
                    case "Image":
                        resultArrayList.Add(Xml2ImageElement(item));
                        break;
                }
            }
            return resultArrayList;
        }

        private static BarcodeElementClass Xml2BarcodeElement(XElement xe) => new()
        {
            ID = xe.Attribute("ID").Value,
            X = int.Parse(xe.Attribute("X").Value),
            Y = int.Parse(xe.Attribute("Y").Value),
            ForeColor = ColorHelper.FormWin32String(xe.Attribute("ForeColor").Value),
            BackColor = ColorHelper.FormWin32String(xe.Attribute("BackColor").Value),

            Context = xe.Element("Context").Value,  
            Height = int.Parse(xe.Element("Height").Value),
            // bec.GS1 = bool.Parse(xe.Element("GS1").Value);
            // bec.Pure = bool.Parse(xe.Element("Pure").Value);
            RotateFlip = xe.Element("RotateFlip").Value,  
            Magnify = byte.Parse(xe.Element("Magnify").Value),
            Type = (Barcode.Type)Enum.Parse(typeof(Barcode.Type), xe.Element("Type").Value),
            TextPosition = (Barcode.TextPosition)Enum.Parse(typeof(Barcode.TextPosition), xe.Element("TextPosition").Value),
            ViewTextFont = Xml2Font(xe.Element("Font")),
            Mapping = xe.Element("Mapping") != null ? xe.Element("Mapping").Value : "",
        };

        private static TextElementClass Xml2TextElement(XElement xe) => new()
        {
            ID = xe.Attribute("ID").Value,
            X = int.Parse(xe.Attribute("X").Value),
            Y = int.Parse(xe.Attribute("Y").Value),
            ForeColor = ColorHelper.FormWin32String(xe.Attribute("ForeColor").Value),
            BackColor = ColorHelper.FormWin32String(xe.Attribute("BackColor").Value),

            Context = xe.Element("Context").Value,
            Width = int.Parse(xe.Element("Width").Value),
            Height = int.Parse(xe.Element("Height").Value),
            RotateFlip = xe.Element("RotateFlip").Value,
            Inversion = bool.Parse(xe.Element("Inversion").Value),
            TextAlign = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), xe.Element("TextAlign").Value),
            TextFont = Xml2Font(xe.Element("Font")),
            Mapping = xe.Element("Mapping") != null ? xe.Element("Mapping").Value : "",
        };

        private static QrCodeElementClass Xml2QrCodeElement(XElement xe) => new()
        {
            ID = xe.Attribute("ID").Value,
            X = int.Parse(xe.Attribute("X").Value),
            Y = int.Parse(xe.Attribute("Y").Value),
            ForeColor = ColorHelper.FormWin32String(xe.Attribute("ForeColor").Value),
            BackColor = ColorHelper.FormWin32String(xe.Attribute("BackColor").Value),

            Context = xe.Element("Context").Value,
            ErrorCorrectionLevel = xe.Element("ErrorCorrectionLevel").Value,
            RotateFlip = xe.Element("RotateFlip").Value,
            Magnify = byte.Parse(xe.Element("Magnify").Value),
            Mapping = xe.Element("Mapping") != null ? xe.Element("Mapping").Value : "",
        };

        private static LineElementClass Xml2LineElement(XElement xe) => new()
        {
            ID = xe.Attribute("ID").Value,
            X = int.Parse(xe.Attribute("X").Value),
            Y = int.Parse(xe.Attribute("Y").Value),
            ForeColor = ColorHelper.FormWin32String(xe.Attribute("ForeColor").Value),

            Length = uint.Parse(xe.Element("Length").Value),
            Thickness = uint.Parse(xe.Element("Thickness").Value),
            RotateFlip = xe.Element("RotateFlip").Value
        };

        private static ImageElementClass Xml2ImageElement(XElement xe) => new()
        {
            ID = xe.Attribute("ID").Value,
            X = int.Parse(xe.Attribute("X").Value),
            Y = int.Parse(xe.Attribute("Y").Value),

            FileFullPath = xe.Element("FileFullPath").Value,
            RotateFlip = xe.Element("RotateFlip").Value
        };

        private static Font Xml2Font(XElement xe)
        {
            if (xe.Value == "null") return null;
            float emSize = float.Parse(xe.Attribute("Size").Value);
            FontStyle fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), xe.Attribute("Style").Value);
            Font font = new(xe.Value, emSize, fontStyle);
            return font;
        }
        #endregion
    }

}
