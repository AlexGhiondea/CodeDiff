using CodeDiffLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeDiffWinForms
{
    public partial class CompareFile : Form
    {
        private string _beforeText;
        private string _afterText;

        public CompareFile(string beforeText, string afterText)
        {
            InitializeComponent();

            _beforeText = beforeText;
            _afterText = afterText;
        }

        private void CompareFile_Load(object sender, EventArgs e)
        {
            textCodeDiff1.Compare(_beforeText, _afterText);
        }
    }
}
