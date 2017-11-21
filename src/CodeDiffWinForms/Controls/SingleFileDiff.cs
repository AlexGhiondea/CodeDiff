using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CodeDiffWinForms.Controls
{
    public partial class SingleFileDiff : UserControl, ICompare
    {
        public SingleFileDiff()
        {
            InitializeComponent();
        }

        public void Compare()
        {
            if (File.Exists(txtFileBefore.Text) && File.Exists(txtFileAfter.Text))
            {
                textCodeDiff1.Compare(File.ReadAllText(txtFileBefore.Text), File.ReadAllText(txtFileAfter.Text));
            }
        }

        private void selectFile(object sender, EventArgs e)
        {
            if (sender == btnBrowseBefore)
                SelectFile(txtFileBefore);
            else
                SelectFile(txtFileAfter);
        }

        private void SelectFile(TextBox text)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    text.Text = ofd.FileName;
                }
            }
        }
    }
}
