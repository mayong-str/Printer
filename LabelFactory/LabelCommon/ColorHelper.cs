using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelCommon
{
    public class ColorHelper
    {
        public static string ToHexString(Color color) => color.ToArgb().ToString("X");
        public static string ToWin32String(Color color) => "#" + ToHexString(color);

        public static Color FormWin32String(string Win32String)=> ColorTranslator.FromHtml(Win32String);

        public static uint ToUint32(Color color) => (uint)color.ToArgb();

       // public static string ToHtmlColorString(Color color) => "#";

       // public static Color FormHtmlColorString(string htmlColorString) => ColorTranslator.FromHtml(htmlColorString);
    }
}
