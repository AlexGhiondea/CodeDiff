namespace CodeDiffWinForms.Controls
{
    partial class TextCodeDiff
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtbBefore = new System.Windows.Forms.RichTextBox();
            this.rtbAfter = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtbBefore);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbAfter);
            this.splitContainer1.Size = new System.Drawing.Size(1082, 811);
            this.splitContainer1.SplitterDistance = 490;
            this.splitContainer1.TabIndex = 2;
            // 
            // rtbBefore
            // 
            this.rtbBefore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbBefore.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbBefore.Location = new System.Drawing.Point(0, 0);
            this.rtbBefore.Name = "rtbBefore";
            this.rtbBefore.Size = new System.Drawing.Size(490, 811);
            this.rtbBefore.TabIndex = 0;
            this.rtbBefore.Text = "";
            // 
            // rtbAfter
            // 
            this.rtbAfter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAfter.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbAfter.Location = new System.Drawing.Point(0, 0);
            this.rtbAfter.Name = "rtbAfter";
            this.rtbAfter.Size = new System.Drawing.Size(588, 811);
            this.rtbAfter.TabIndex = 1;
            this.rtbAfter.Text = "";
            // 
            // TextCodeDiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TextCodeDiff";
            this.Size = new System.Drawing.Size(1082, 811);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbBefore;
        private System.Windows.Forms.RichTextBox rtbAfter;



    }
}
