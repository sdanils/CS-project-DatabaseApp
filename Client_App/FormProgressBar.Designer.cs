namespace Lab_Three_WinAdd
{
    partial class FormProgressBar
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
            this.progressBarSearch = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressBarSearch
            // 
            this.progressBarSearch.Location = new System.Drawing.Point(-2, 1);
            this.progressBarSearch.Name = "progressBarSearch";
            this.progressBarSearch.Size = new System.Drawing.Size(297, 26);
            this.progressBarSearch.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarSearch.TabIndex = 0;
            // 
            // FormProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 28);
            this.ControlBox = false;
            this.Controls.Add(this.progressBarSearch);
            this.Name = "FormProgressBar";
            this.Text = "Search progress";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarSearch;
    }
}