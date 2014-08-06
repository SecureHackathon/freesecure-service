namespace FreeSecure
{
    partial class FreeSecureMain
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnStartCamera = new System.Windows.Forms.Button();
            this.btnStopCamera = new System.Windows.Forms.Button();
            this.btnViewCamera = new System.Windows.Forms.Button();
            this.pboxStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cameras";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(118, 89);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(305, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnStartCamera
            // 
            this.btnStartCamera.Location = new System.Drawing.Point(36, 140);
            this.btnStartCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartCamera.Name = "btnStartCamera";
            this.btnStartCamera.Size = new System.Drawing.Size(387, 47);
            this.btnStartCamera.TabIndex = 2;
            this.btnStartCamera.Text = "Start Camera";
            this.btnStartCamera.UseVisualStyleBackColor = true;
            this.btnStartCamera.Click += new System.EventHandler(this.btnStartCamera_Click);
            // 
            // btnStopCamera
            // 
            this.btnStopCamera.Location = new System.Drawing.Point(36, 195);
            this.btnStopCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopCamera.Name = "btnStopCamera";
            this.btnStopCamera.Size = new System.Drawing.Size(387, 47);
            this.btnStopCamera.TabIndex = 3;
            this.btnStopCamera.Text = "Stop Camera";
            this.btnStopCamera.UseVisualStyleBackColor = true;
            this.btnStopCamera.Click += new System.EventHandler(this.btnStopCamera_Click);
            // 
            // btnViewCamera
            // 
            this.btnViewCamera.Location = new System.Drawing.Point(36, 250);
            this.btnViewCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewCamera.Name = "btnViewCamera";
            this.btnViewCamera.Size = new System.Drawing.Size(387, 47);
            this.btnViewCamera.TabIndex = 4;
            this.btnViewCamera.Text = "View Camera";
            this.btnViewCamera.UseVisualStyleBackColor = true;
            this.btnViewCamera.Click += new System.EventHandler(this.btnViewCamera_Click);
            // 
            // pboxStatus
            // 
            this.pboxStatus.Image = global::FreeSecure.Properties.Resources.off;
            this.pboxStatus.InitialImage = global::FreeSecure.Properties.Resources.on;
            this.pboxStatus.Location = new System.Drawing.Point(36, 28);
            this.pboxStatus.Name = "pboxStatus";
            this.pboxStatus.Size = new System.Drawing.Size(44, 39);
            this.pboxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxStatus.TabIndex = 0;
            this.pboxStatus.TabStop = false;
            // 
            // FreeSecureMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 321);
            this.Controls.Add(this.pboxStatus);
            this.Controls.Add(this.btnViewCamera);
            this.Controls.Add(this.btnStopCamera);
            this.Controls.Add(this.btnStartCamera);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FreeSecureMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Free Secure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FreeSecureMain_FormClosing);
            this.Load += new System.EventHandler(this.FreeSecureMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnStartCamera;
        private System.Windows.Forms.Button btnStopCamera;
        private System.Windows.Forms.Button btnViewCamera;
        private System.Windows.Forms.PictureBox pboxStatus;
    }
}

