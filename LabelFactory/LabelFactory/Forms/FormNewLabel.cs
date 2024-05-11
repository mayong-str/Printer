using LabelCommon;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabelDesigner
{
    public partial class FormNewLabel : Form
    {
        public LabelBasicInfoClass LabelBasic { get; private set; }

        private string labelName;
        private float labelWidht = 0f;
        private float labelHeight = 0f;
        private int dotPerMm = 8;
        private int numberPerLine = 1;
        private float gap = 0f;

        public FormNewLabel()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(labelName)) return;
            if (labelWidht == 0f) return;
            if (labelHeight == 0f) return;

            if (this.numberPerLine == 1) this.gap = 0f;

            this.LabelBasic = new LabelBasicInfoClass()
            {
                Name = this.labelName,
                Width = this.labelWidht,
                Height = this.labelHeight,
                DotPerMillimeter = this.dotPerMm,
                LabelsPerLine = this.numberPerLine,
                Gap = this.gap,
            };
            this.DialogResult = DialogResult.OK;
        }

        private void txtLabelName_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            this.labelName = tb.Text;
        }

        private void txtLabelWidth_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            float.TryParse(tb.Text, out this.labelWidht);
        }

        private void txtLabelHeight_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            float.TryParse(tb.Text, out this.labelHeight);
        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            this.dotPerMm = this.rdo8Dot.Checked ? 8 : 12;
        }

        private void FormNewLabel_Load(object sender, EventArgs e)
        {
            if (this.dotPerMm == 8)
            {
                this.rdo8Dot.Checked = true;
            }
            else
            {
                this.rdo12Dot.Checked = true;
            }
        }

        private void CobNumberPerLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            int.TryParse(cb.Text,out this.numberPerLine);
            if (this.numberPerLine == 1) this.gap = 0f;
        }

        private void TxtGap_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            float.TryParse(tb.Text, out this.gap);
        }
    }
}
