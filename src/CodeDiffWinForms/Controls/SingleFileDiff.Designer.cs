namespace CodeDiffWinForms.Controls
{
    partial class SingleFileDiff
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
            this.textCodeDiff1 = new CodeDiffWinForms.Controls.TextCodeDiff();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseAfter = new System.Windows.Forms.Button();
            this.txtFileAfter = new System.Windows.Forms.TextBox();
            this.btnBrowseBefore = new System.Windows.Forms.Button();
            this.txtFileBefore = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textCodeDiff1
            // 
            this.textCodeDiff1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textCodeDiff1.Location = new System.Drawing.Point(3, 92);
            this.textCodeDiff1.Name = "textCodeDiff1";
            this.textCodeDiff1.ReadOnly = true;
            this.textCodeDiff1.Size = new System.Drawing.Size(1000, 673);
            this.textCodeDiff1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "After";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Before";
            // 
            // btnBrowseAfter
            // 
            this.btnBrowseAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseAfter.Location = new System.Drawing.Point(976, 34);
            this.btnBrowseAfter.Name = "btnBrowseAfter";
            this.btnBrowseAfter.Size = new System.Drawing.Size(27, 20);
            this.btnBrowseAfter.TabIndex = 10;
            this.btnBrowseAfter.Text = "...";
            this.btnBrowseAfter.UseVisualStyleBackColor = true;
            this.btnBrowseAfter.Click += new System.EventHandler(this.selectFile);
            // 
            // txtFileAfter
            // 
            this.txtFileAfter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileAfter.Location = new System.Drawing.Point(42, 35);
            this.txtFileAfter.Name = "txtFileAfter";
            this.txtFileAfter.Size = new System.Drawing.Size(928, 20);
            this.txtFileAfter.TabIndex = 8;
            // 
            // btnBrowseBefore
            // 
            this.btnBrowseBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseBefore.Location = new System.Drawing.Point(976, 8);
            this.btnBrowseBefore.Name = "btnBrowseBefore";
            this.btnBrowseBefore.Size = new System.Drawing.Size(27, 20);
            this.btnBrowseBefore.TabIndex = 9;
            this.btnBrowseBefore.Text = "...";
            this.btnBrowseBefore.UseVisualStyleBackColor = true;
            this.btnBrowseBefore.Click += new System.EventHandler(this.selectFile);
            // 
            // txtFileBefore
            // 
            this.txtFileBefore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileBefore.Location = new System.Drawing.Point(42, 9);
            this.txtFileBefore.Name = "txtFileBefore";
            this.txtFileBefore.Size = new System.Drawing.Size(928, 20);
            this.txtFileBefore.TabIndex = 7;
            // 
            // SingleFileDiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseAfter);
            this.Controls.Add(this.txtFileAfter);
            this.Controls.Add(this.btnBrowseBefore);
            this.Controls.Add(this.txtFileBefore);
            this.Controls.Add(this.textCodeDiff1);
            this.Name = "SingleFileDiff";
            this.Size = new System.Drawing.Size(1006, 737);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextCodeDiff textCodeDiff1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseAfter;
        private System.Windows.Forms.TextBox txtFileAfter;
        private System.Windows.Forms.Button btnBrowseBefore;
        private System.Windows.Forms.TextBox txtFileBefore;
    }
}
