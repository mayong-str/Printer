using LabelCommon;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabelDesigner
{
    public partial class LabelPreviewPanel : UserControl
    {
        public Bitmap Bitmap { get; private set; }

        public LabelPreviewPanel()
        {
            InitializeComponent();
            ShowImage();

        }

        private void Init()
        {
            //this.PicImage.BackColor = Color.LightYellow;
            int x = GetWidth(Global.WorkLabel.BasicInfo);
            int y = Global.WorkLabel.BasicInfo.LabelDotY;
            this.PicImage.ClientSize = new Size(x, y);

            this.ClientSize = this.PicImage.Size;
            this.PicImage.Dock = DockStyle.Fill;
        }

        private int GetWidth(LabelBasicInfoClass lbic)
        {
            int x = lbic.LabelDotX * lbic.LabelsPerLine;
            x += (lbic.LabelsPerLine - 1) * lbic.GapDot;
            return x;
        }

        private void ShowImage()
        {
            Init();
            Global.WorkLabel.GetLabelBitmap();
            Bitmap bitmap = new(this.PicImage.ClientSize.Width, this.PicImage.ClientSize.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.LightYellow);
            for (int i = 0; i < Global.WorkLabel.BasicInfo.LabelsPerLine; i++)
            {
                int j = Global.WorkLabel.BasicInfo.LabelDotX * i + Global.WorkLabel.BasicInfo.GapDot * i;
                g.DrawImage(Global.WorkLabel.LabelBitmap, j, 0);
            }
            //g.DrawImage(Global.WorkLabel.LabelBitmap, 0, 0);
            this.PicImage.Image = bitmap;
            this.Bitmap = bitmap;
        }

        private void LabelPreviewPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
