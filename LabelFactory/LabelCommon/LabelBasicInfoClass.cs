using System.Drawing;

namespace LabelCommon
{
    /// <summary>标签基本信息
    /// 
    /// </summary>
    public class LabelBasicInfoClass
    {
        /// <summary>标签的名字
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>标签的宽度，以毫米为单位。
        /// 
        /// </summary>
        public float Width
        {
            get => this._width;
            set
            {
                this._width = value;
                this._x = GetDot(this._width);
            }
        }

        /// <summary>标签的高度，以毫米为单位。
        /// 
        /// </summary>
        public float Height
        {
            get => this._height;
            set
            {
                this._height = value;
                this._y = GetDot(this._height);
            }
        }

        /// <summary>设置和获取单行多标签时，每行标签个数。
        /// 
        /// </summary>
        public int LabelsPerLine { get; set; } = 1;

        /// <summary>设置和获取单行多标签时，标签之间的间隙，以毫米为单位。
        /// 
        /// </summary>
        public float Gap
        {
            get => this._gap_mm;
            set
            {
                this._gap_mm = value;
                this._gapDot = GetDot(this._gap_mm);
            }
        }

        /// <summary>打印头每毫米的点数
        /// 
        /// </summary>
        public int DotPerMillimeter
        {
            get => this._dotPerMm;
            set
            {
                this._dotPerMm = value;
                if (this._width > 0f) this._x = GetDot(this._width);
                if (this._height > 0f) this._y = GetDot(this._height);
                this._gapDot = GetDot(this._gap_mm);
            }
        }

        /// <summary>获取标签的宽度，以点数为单位。
        /// 
        /// </summary>
        public int LabelDotX => this._x;

        /// <summary>获取标签的高度，以点数为单位。
        /// 
        /// </summary>
        public int LabelDotY => this._y;

        /// <summary>获取单行多标签时，标签之间的间隙，以点数为单位。
        /// 
        /// </summary>
        public int GapDot => this._gapDot;

        public LabelBasicInfoClass()
        {

        }

      

        /// <summary>毫米到点单位的转换
        /// 
        /// </summary>
        /// <param name="var">(float)毫米</param>
        /// <returns>(int)点数</returns>
        private int GetDot(float var) => (int)(var * ((float)this.DotPerMillimeter));

        private float _width;
        private float _height;
        private float _gap_mm;
        private int _dotPerMm;
        private int _x;
        private int _y;
        private int _gapDot;
    }
}
