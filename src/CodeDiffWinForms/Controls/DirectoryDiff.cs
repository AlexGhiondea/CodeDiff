using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CodeDiffLib;

namespace CodeDiffWinForms.Controls
{
    public partial class DirectoryDiff : UserControl, ICompare
    {
        public DirectoryDiff()
        {
            InitializeComponent();
        }

        public void SelectDirectory(TextBox text)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    text.Text = fbd.SelectedPath;
                }
            }
        }

        private void selectDirectory(object sender, EventArgs e)
        {
            if (sender == btnBrowseBefore)
                SelectDirectory(txtFileBefore);
            else
                SelectDirectory(txtFileAfter);
        }

        private enum EntryStateEnum
        {
            Added,
            Removed,
            NoChange,
            Modified
        }

        private class FileEntry
        {
            public string FileName { get; set; }
            public EntryStateEnum Status { get; set; }

            public static FileEntry Empty = new FileEntry() { FileName = string.Empty };
            public override string ToString()
            {
                return FileName + " " + Status;
            }
        }

        private void CompareDirectoryFiles(string beforePath, string afterPath)
        {
            listView1.Items.Clear();

            if (!Directory.Exists(beforePath) )
            {
                MessageBox.Show("The before path is incorrect");
                return;
            }
            if (!Directory.Exists(afterPath))
            {
                MessageBox.Show("The after path is incorrect");
                return;
            }

            // we normalize the paths so that we remove the leading part (which will not be common anyway)
            var beforeFiles = Directory.GetFiles(beforePath, "*.*", SearchOption.AllDirectories).Select(file => file.Replace(beforePath, "")).ToArray();
            var afterFiles = Directory.GetFiles(afterPath, "*.*", SearchOption.AllDirectories).Select(file => file.Replace(afterPath, "")).ToArray();

            // the changes are going to come in already sorted.
            foreach (var change in StringListDiff.Compare(beforeFiles, afterFiles))
            {
                var fileEntry = new FileEntry();

                switch (change.ChangeType)
                {
                    case CodeDiffLib.Changes.ChangeType.Added:
                        {
                            fileEntry.FileName = change.After.Substring(1);
                            fileEntry.Status = EntryStateEnum.Added;
                            break;
                        }
                    case CodeDiffLib.Changes.ChangeType.Removed:
                        {
                            fileEntry.FileName = change.Before.Substring(1);
                            fileEntry.Status = EntryStateEnum.Removed;
                            break;
                        }
                    case CodeDiffLib.Changes.ChangeType.NoChange:
                        {
                            // here we should actually do the file diff.
                            var beforeFilePath = beforePath + change.Before;
                            var afterFilePath = afterPath + change.After;

                            fileEntry.FileName = change.Before.Substring(1);
                            fileEntry.Status = EntryStateEnum.Modified;
                            fileEntry.Status = TreeDiff.Compare(File.ReadAllText(beforeFilePath), File.ReadAllText(afterFilePath)).Any() ? EntryStateEnum.Modified : EntryStateEnum.NoChange;
                            break;
                        }
                }

                listView1.Items.Add(new ListViewItem(new string[2] { fileEntry.FileName, fileEntry.Status.ToString() }) { Tag = fileEntry, BackColor = GetBackColorFromState(fileEntry.Status) });
                Application.DoEvents();
            }
        }

        private Color GetBackColorFromState(EntryStateEnum entryStateEnum)
        {
            switch (entryStateEnum)
            {
                case EntryStateEnum.Added:
                    return Color.LightGreen;
                case EntryStateEnum.Removed:
                    return Color.LightSalmon;
                case EntryStateEnum.Modified:
                    return Color.LightGoldenrodYellow;
                default:
                    return listView1.BackColor;
            }
        }

        private void ChangeSelectedItem(ListBox list, int position)
        {
            if (position < list.Items.Count)
            {
                list.SelectedIndex = position;
            }
        }

        public void Compare()
        {
            CompareDirectoryFiles(txtFileBefore.Text, txtFileAfter.Text);
        }

        private void compareFile(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.Items[listView1.SelectedItems[0].Index].Tag as FileEntry;
                if (item.Status == EntryStateEnum.Modified)
                {
                    string beforeFilePath = Path.Combine(txtFileBefore.Text, item.FileName);
                    string afterFilePath = Path.Combine(txtFileAfter.Text, item.FileName);

                    CompareFile form = new CompareFile(File.ReadAllText(beforeFilePath), File.ReadAllText(afterFilePath));
                    form.Text = string.Format("Compare {0} with {1}", beforeFilePath, afterFilePath);
                    form.Show();
                }
            }
        }
    }
}
