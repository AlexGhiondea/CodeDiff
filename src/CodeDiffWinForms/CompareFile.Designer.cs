namespace CodeDiffWinForms
{
    partial class CompareFile
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
            this.textCodeDiff1 = new CodeDiffWinForms.Controls.TextCodeDiff();
            this.SuspendLayout();
            // 
            // textCodeDiff1
            // 
            this.textCodeDiff1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textCodeDiff1.Location = new System.Drawing.Point(12, 12);
            this.textCodeDiff1.Name = "textCodeDiff1";
            this.textCodeDiff1.ReadOnly = true;
            this.textCodeDiff1.Size = new System.Drawing.Size(1001, 429);
            this.textCodeDiff1.TabIndex = 0;
            // 
            // CompareFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 453);
            this.Controls.Add(this.textCodeDiff1);
            this.Name = "CompareFile";
            this.Text = "Compare file";
            this.Load += new System.EventHandler(this.CompareFile_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TextCodeDiff textCodeDiff1;

    }
}