using CodeDiffLib;
using CodeDiffWinForms.Controls;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeDiffWinForms
{
    public partial class CodeDiffForm : Form
    {
        ICompare currentControl;

        public CodeDiffForm()
        {
            InitializeComponent();
            currentControl = textDiff;
        }

        private void GetFilePath(TextBox txtBox)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBox.Text = ofd.FileName;
            }
        }

        private string GetTextFromFile(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch
            {
                return null;
            }
        }

        private void compareTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentControl != null)
                currentControl.Compare();
        }

        private void compareDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentControl = directoryDiff;

            directoryDiff.Visible = true;
            textDiff.Visible = false;
            singleFileDiff.Visible = false;
        }

        private void compareTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            currentControl = textDiff;

            singleFileDiff.Visible = false;
            directoryDiff.Visible = false;
            textDiff.Visible = true;
        }

        private void compareFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentControl = singleFileDiff;

            singleFileDiff.Visible = true;
            directoryDiff.Visible = false;
            textDiff.Visible = false;
        }
    }
}
