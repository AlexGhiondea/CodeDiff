namespace CodeDiffWinForms.Controls
{
    partial class DirectoryDiff
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFileAfter = new System.Windows.Forms.TextBox();
            this.btnBrowseAfter = new System.Windows.Forms.Button();
            this.txtFileBefore = new System.Windows.Forms.TextBox();
            this.btnBrowseBefore = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // txtFileAfter
            // 
            this.txtFileAfter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileAfter.Location = new System.Drawing.Point(42, 35);
            this.txtFileAfter.Name = "txtFileAfter";
            this.txtFileAfter.Size = new System.Drawing.Size(690, 20);
            this.txtFileAfter.TabIndex = 2;
            // 
            // btnBrowseAfter
            // 
            this.btnBrowseAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseAfter.Location = new System.Drawing.Point(738, 34);
            this.btnBrowseAfter.Name = "btnBrowseAfter";
            this.btnBrowseAfter.Size = new System.Drawing.Size(27, 20);
            this.btnBrowseAfter.TabIndex = 3;
            this.btnBrowseAfter.Text = "...";
            this.btnBrowseAfter.UseVisualStyleBackColor = true;
            this.btnBrowseAfter.Click += new System.EventHandler(this.selectDirectory);
            // 
            // txtFileBefore
            // 
            this.txtFileBefore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileBefore.Location = new System.Drawing.Point(42, 9);
            this.txtFileBefore.Name = "txtFileBefore";
            this.txtFileBefore.Size = new System.Drawing.Size(690, 20);
            this.txtFileBefore.TabIndex = 1;
            // 
            // btnBrowseBefore
            // 
            this.btnBrowseBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseBefore.Location = new System.Drawing.Point(738, 8);
            this.btnBrowseBefore.Name = "btnBrowseBefore";
            this.btnBrowseBefore.Size = new System.Drawing.Size(27, 20);
            this.btnBrowseBefore.TabIndex = 2;
            this.btnBrowseBefore.Text = "...";
            this.btnBrowseBefore.UseVisualStyleBackColor = true;
            this.btnBrowseBefore.Click += new System.EventHandler(this.selectDirectory);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Before";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "After";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(3, 64);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(762, 707);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.compareFile);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 294;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "State";
            // 
            // DirectoryDiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseAfter);
            this.Controls.Add(this.txtFileAfter);
            this.Controls.Add(this.btnBrowseBefore);
            this.Controls.Add(this.txtFileBefore);
            this.Name = "DirectoryDiff";
            this.Size = new System.Drawing.Size(768, 778);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFileAfter;
        private System.Windows.Forms.Button btnBrowseAfter;
        private System.Windows.Forms.TextBox txtFileBefore;
        private System.Windows.Forms.Button btnBrowseBefore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;

    }
}
