using CodeDiffLib;
using CodeDiffLib.Changes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeDiffWinForms.Controls
{
    public partial class TextCodeDiff : UserControl, ICompare
    {
        private Changes<SyntaxNodeOrToken> _codeDiff;

        private bool _readOnly = false;
        [Description("Allow editing of the text contents"), Category("Appearance")]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                rtbAfter.ReadOnly = _readOnly;
                rtbBefore.ReadOnly = ReadOnly;
            }
        }

        public void SetBeforeText(string text)
        {
            rtbBefore.Text = text;
        }

        public void SetAfterText(string text)
        {
            rtbAfter.Text = text;
        }

        public void Compare()
        {
            _codeDiff = TreeDiff.Compare(rtbBefore.Text, rtbAfter.Text);
            //PopulateDiffList();
            PaintTheTextBoxes();
        }

        public void Compare(string beforeText, string afterText)
        {
            rtbBefore.Text = beforeText;
            rtbAfter.Text = afterText;

            Compare();
        }

        public TextCodeDiff()
        {
            rtbBefore = new SynchronizedRichTextBox();
            rtbAfter = new SynchronizedRichTextBox();
            (rtbAfter as SynchronizedRichTextBox).AddRTB(rtbBefore as SynchronizedRichTextBox);
            (rtbBefore as SynchronizedRichTextBox).AddRTB(rtbAfter as SynchronizedRichTextBox);
            InitializeComponent();
        }

        #region Event handlers

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //private void lstDifferences_Click(object sender, EventArgs e)
        //{
        //    var selected = lstDifferences.SelectedItem as ChangeLocation;

        //    if (selected == null)
        //        return;

        //    EnsureVisible(rtbBefore, selected.Before);
        //    EnsureVisible(rtbAfter, selected.After);
        //}

        #endregion

        #region Helpers
        private void ColorSection(RichTextBox text, int start, int length, Color color)
        {
            text.SelectionStart = start;
            text.SelectionLength = length;
            text.SelectionBackColor = color;
        }
        private void PaintTheTextBoxes()
        {
            var prevBefore = rtbBefore.SelectionStart;
            var prevAfter = rtbAfter.SelectionStart;

            rtbBefore.SuspendLayout();
            rtbAfter.SuspendLayout();

            ResetColor(rtbBefore);
            ResetColor(rtbAfter);

            foreach (var added in _codeDiff.GetAdded())
            {
                ColorSection(rtbAfter, added.After.Span.Start, added.After.Span.Length, Color.LightGreen);
            }

            foreach (var added in _codeDiff.GetRemoved())
            {
                ColorSection(rtbBefore, added.Before.Span.Start, added.Before.Span.Length, Color.LightSalmon);
            }

            foreach (var added in _codeDiff.GetModified())
            {
                ColorSection(rtbAfter, added.After.Span.Start, added.After.Span.Length, Color.LightGreen);
                ColorSection(rtbBefore, added.Before.Span.Start, added.Before.Span.Length, Color.LightSalmon);
            }
            rtbBefore.ResumeLayout();
            rtbAfter.ResumeLayout();

            rtbBefore.SelectionStart = prevBefore;
            rtbBefore.SelectionLength = 0;
            rtbAfter.SelectionStart = prevAfter;
            rtbAfter.SelectionLength = 0;
        }

        private void ResetColor(RichTextBox textBox)
        {
            textBox.SelectionStart = 0;
            textBox.SelectionLength = textBox.TextLength;
            textBox.SelectionBackColor = textBox.BackColor;
        }

        //private void PopulateDiffList()
        //{
        //    List<ChangeLocation> locations = new List<ChangeLocation>();
        //    foreach (var added in _codeDiff.AddedNodes)
        //    {
        //        locations.Add(new ChangeLocation(default(TextSpan), added.Span, "Addition"));
        //    }

        //    foreach (var deleted in _codeDiff.DeletedNodes)
        //    {
        //        locations.Add(new ChangeLocation(deleted.Span, default(TextSpan), "Deletion"));
        //    }

        //    foreach (var edited in _codeDiff.EditedNodes)
        //    {
        //        locations.Add(new ChangeLocation(edited.Before.Span, edited.After.Span, "Edit"));
        //    }
        //    lstDifferences.DataSource = locations;
        //}

        private void EnsureVisible(RichTextBox textBox, TextSpan position)
        {
            if (position != default(TextSpan))
            {
                textBox.SelectionStart = position.Start;
                textBox.SelectionLength = position.Length;
                textBox.ScrollToCaret();
            }
        }
        #endregion
    }
}
