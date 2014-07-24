using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FreeSecureLib.Camera;

namespace FreeSecure
{
    public partial class CameraView : Form
    {
        private Controller cameraController;

        public CameraView(Controller camerViewController)
        {
            InitializeComponent();
            cameraController = camerViewController;
        }

        private void CameraView_Load(object sender, EventArgs e)
        {
            cameraController.FrameProcessingHandler += cameraController_FrameProcessingHandler;
            cameraController.MotionFrameProcessingHandler += cameraController_MotionFrameProcessingHandler;
            cameraController.FrameProcessingErrorHandler += cameraController_FrameProcessingErrorHandler;
            cameraController.CameraClosingHandler += cameraController_CameraClosingHandler;
        }

        private void btnCloseCameraView_Click(object sender, EventArgs e)
        {
            cameraController.FrameProcessingHandler -= cameraController_FrameProcessingHandler;
            cameraController.MotionFrameProcessingHandler -= cameraController_MotionFrameProcessingHandler;
            cameraController.FrameProcessingErrorHandler -= cameraController_FrameProcessingErrorHandler;
            cameraController.CameraClosingHandler -= cameraController_CameraClosingHandler;
            this.Close();
        }

        private void cameraController_FrameProcessingHandler(Bitmap image)
        {
            RenderImage(pboxLiveCamera, image);
        }

        private void cameraController_MotionFrameProcessingHandler(Bitmap image)
        {
            RenderImage(pboxMotionCamera, image);
        }

        private void cameraController_CameraClosingHandler(CameraState obj)
        {
            
        }

        private void cameraController_FrameProcessingErrorHandler(string obj)
        {
            
        }

        private void RenderImage(PictureBox pictureBox, Image image)
        {
            if (pictureBox.InvokeRequired)
            {
                Action<Image> imageDelegate = (param) =>
                {
                    UpdatePictureBox(pictureBox, image);
                };

                pictureBox.Invoke(imageDelegate, image);
            }
            else
            {
                UpdatePictureBox(pictureBox, image);
            }
        }

        private void UpdatePictureBox(PictureBox pictureBox, Image image)
        {
            pictureBox.Image = image;
            pictureBox.Refresh();
        }
    }
}
