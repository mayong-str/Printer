using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelCommon
{
    interface IPrinter
    {
        string Alias { get; }
        int PrintingSpeed_inch { get; }
        /// <summary>打印浓度
        /// 
        /// </summary>
        int PrintDarkness { get; }

        // int PrintheadDot { get; }

        // int PrintheadDotPerMm { get; }

    }
}
