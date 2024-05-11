using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelDesigner
{
    public static class PictureToWhiteBlackGraphics
    {
        public static Bitmap Conversion(Bitmap bmSrc)
        {
            //以黑白方式显示图像            
            int Height = bmSrc.Height;
            int Width = bmSrc.Width;
            Bitmap resultBitmap = new Bitmap(Width, Height);

            Color pixel;
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    pixel = bmSrc.GetPixel(x, y);
                    int r, g, b, Result = 0;
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    //实例程序以加权平均值法产生黑白图像
                    int iType = 2;
                    switch (iType)
                    {
                        case 0://平均值法
                            Result = ((r + g + b) / 3);
                            break;
                        case 1://最大值法
                            Result = r > g ? r : g;
                            Result = Result > b ? Result : b;
                            break;
                        case 2://加权平均值法
                            Result = ((int)(0.7 * r) + (int)(0.2 * g) + (int)(0.1 * b));
                            break;
                    }
                    resultBitmap.SetPixel(x, y, Color.FromArgb(Result, Result, Result));
                }
            return resultBitmap;
        }
    }
}
