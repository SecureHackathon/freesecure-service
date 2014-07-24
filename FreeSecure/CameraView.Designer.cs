namespace FreeSecure
{
    partial class CameraView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pboxLiveCamera = new System.Windows.Forms.PictureBox();
            this.pboxMotionCamera = new System.Windows.Forms.PictureBox();
            this.btnCloseCameraView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pboxLiveCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMotionCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Live Camera View";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Motion Camera View";
            // 
            // pboxLiveCamera
            // 
            this.pboxLiveCamera.Location = new System.Drawing.Point(37, 52);
            this.pboxLiveCamera.Name = "pboxLiveCamera";
            this.pboxLiveCamera.Size = new System.Drawing.Size(223, 282);
            this.pboxLiveCamera.TabIndex = 2;
            this.pboxLiveCamera.TabStop = false;
            // 
            // pboxMotionCamera
            // 
            this.pboxMotionCamera.Location = new System.Drawing.Point(330, 52);
            this.pboxMotionCamera.Name = "pboxMotionCamera";
            this.pboxMotionCamera.Size = new System.Drawing.Size(223, 282);
            this.pboxMotionCamera.TabIndex = 3;
            this.pboxMotionCamera.TabStop = false;
            // 
            // btnCloseCameraView
            // 
            this.btnCloseCameraView.Location = new System.Drawing.Point(37, 357);
            this.btnCloseCameraView.Name = "btnCloseCameraView";
            this.btnCloseCameraView.Size = new System.Drawing.Size(223, 37);
            this.btnCloseCameraView.TabIndex = 4;
            this.btnCloseCameraView.Text = "Close Camera View";
            this.btnCloseCameraView.UseVisualStyleBackColor = true;
            this.btnCloseCameraView.Click += new System.EventHandler(this.btnCloseCameraView_Click);
            // 
            // CameraView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 406);
            this.Controls.Add(this.btnCloseCameraView);
            this.Controls.Add(this.pboxMotionCamera);
            this.Controls.Add(this.pboxLiveCamera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CameraView";
            this.Text = "Camera View";
            this.Load += new System.EventHandler(this.CameraView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxLiveCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxMotionCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pboxLiveCamera;
        private System.Windows.Forms.PictureBox pboxMotionCamera;
        private System.Windows.Forms.Button btnCloseCameraView;
    }
}