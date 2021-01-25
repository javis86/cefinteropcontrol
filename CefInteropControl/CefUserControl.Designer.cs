namespace CefInteropControl
{
    partial class CefUserControl
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
            this.loadingControl1 = new CefInteropControl.LoadingControl();
            this.SuspendLayout();
            // 
            // loadingControl1
            // 
            this.loadingControl1.BackColor = System.Drawing.Color.White;
            this.loadingControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadingControl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loadingControl1.Location = new System.Drawing.Point(0, 126);
            this.loadingControl1.Margin = new System.Windows.Forms.Padding(2);
            this.loadingControl1.Name = "loadingControl1";
            this.loadingControl1.Size = new System.Drawing.Size(150, 24);
            this.loadingControl1.TabIndex = 0;
            // 
            // CefUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadingControl1);
            this.Name = "CefUserControl";
            this.Load += new System.EventHandler(this.CefUserControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LoadingControl loadingControl1;
    }
}

