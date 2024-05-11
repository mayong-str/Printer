using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelCommon
{
    /// <summary>Line元素类，
    /// LabelElementCommonClass类的子类。
    /// </summary>
    public class LineElementClass : LabelElementCommonClass
    {
        /// <summary>线条长度
        /// 
        /// </summary>
        public uint Length { get; set; }
        /// <summary>线条粗度
        /// 
        /// </summary>
        public uint Thickness { get; set; }

        /// <summary>旋转和翻转
        /// 
        /// </summary>
        public string RotateFlip { get; set; }
    }
}
