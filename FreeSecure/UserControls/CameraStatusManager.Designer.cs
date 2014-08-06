namespace FreeSecure.UserControls
{
    partial class CameraStatusManager
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
            this.pboxStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxStatus
            // 
            this.pboxStatus.Location = new System.Drawing.Point(17, 15);
            this.pboxStatus.Name = "pboxStatus";
            this.pboxStatus.Size = new System.Drawing.Size(115, 116);
            this.pboxStatus.TabIndex = 0;
            this.pboxStatus.TabStop = false;
            // 
            // CameraStatusManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pboxStatus);
            this.Name = "CameraStatusManager";
            this.Size = new System.Drawing.Size(464, 150);
            this.Load += new System.EventHandler(this.CameraStatusManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxStatus;
    }
}
