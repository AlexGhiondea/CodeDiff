namespace CodeDiffWinForms
{
    partial class CodeDiffForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareTextToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.compareTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleFileDiff = new CodeDiffWinForms.Controls.SingleFileDiff();
            this.directoryDiff = new CodeDiffWinForms.Controls.DirectoryDiff();
            this.textDiff = new CodeDiffWinForms.Controls.TextCodeDiff();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareToolStripMenuItem,
            this.compareTextToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(938, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareFileToolStripMenuItem,
            this.compareDirectoryToolStripMenuItem,
            this.compareTextToolStripMenuItem1});
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.compareToolStripMenuItem.Text = "Compare";
            // 
            // compareFileToolStripMenuItem
            // 
            this.compareFileToolStripMenuItem.Name = "compareFileToolStripMenuItem";
            this.compareFileToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.compareFileToolStripMenuItem.Text = "Compare file";
            this.compareFileToolStripMenuItem.Click += new System.EventHandler(this.compareFileToolStripMenuItem_Click);
            // 
            // compareDirectoryToolStripMenuItem
            // 
            this.compareDirectoryToolStripMenuItem.Name = "compareDirectoryToolStripMenuItem";
            this.compareDirectoryToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.compareDirectoryToolStripMenuItem.Text = "Compare directory";
            this.compareDirectoryToolStripMenuItem.Click += new System.EventHandler(this.compareDirectoryToolStripMenuItem_Click);
            // 
            // compareTextToolStripMenuItem1
            // 
            this.compareTextToolStripMenuItem1.Name = "compareTextToolStripMenuItem1";
            this.compareTextToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.compareTextToolStripMenuItem1.Text = "Compare text";
            this.compareTextToolStripMenuItem1.Click += new System.EventHandler(this.compareTextToolStripMenuItem1_Click);
            // 
            // compareTextToolStripMenuItem
            // 
            this.compareTextToolStripMenuItem.Name = "compareTextToolStripMenuItem";
            this.compareTextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.compareTextToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.compareTextToolStripMenuItem.Text = "Update diff (F5)";
            this.compareTextToolStripMenuItem.Click += new System.EventHandler(this.compareTextToolStripMenuItem_Click);
            // 
            // singleFileDiff
            // 
            this.singleFileDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.singleFileDiff.Location = new System.Drawing.Point(12, 27);
            this.singleFileDiff.Name = "singleFileDiff";
            this.singleFileDiff.Size = new System.Drawing.Size(914, 585);
            this.singleFileDiff.TabIndex = 7;
            this.singleFileDiff.Visible = false;
            // 
            // directoryDiff
            // 
            this.directoryDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryDiff.Location = new System.Drawing.Point(12, 27);
            this.directoryDiff.Name = "directoryDiff";
            this.directoryDiff.Size = new System.Drawing.Size(914, 585);
            this.directoryDiff.TabIndex = 6;
            this.directoryDiff.Visible = false;
            // 
            // textDiff
            // 
            this.textDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDiff.Location = new System.Drawing.Point(12, 27);
            this.textDiff.Name = "textDiff";
            this.textDiff.ReadOnly = false;
            this.textDiff.Size = new System.Drawing.Size(914, 585);
            this.textDiff.TabIndex = 5;
            // 
            // CodeDiffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 624);
            this.Controls.Add(this.singleFileDiff);
            this.Controls.Add(this.directoryDiff);
            this.Controls.Add(this.textDiff);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CodeDiffForm";
            this.Text = "Code diff";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareTextToolStripMenuItem;
        private Controls.TextCodeDiff textDiff;
        private Controls.DirectoryDiff directoryDiff;
        private System.Windows.Forms.ToolStripMenuItem compareTextToolStripMenuItem1;
        private Controls.SingleFileDiff singleFileDiff;
    }
}

