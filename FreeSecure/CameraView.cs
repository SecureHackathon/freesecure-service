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
            cameraController.FrameProcessingHandler += CameraController_FrameProcessingHandler;
            cameraController.MotionFrameProcessingHandler += CameraController_MotionFrameProcessingHandler;
            cameraController.FrameProcessingErrorHandler += CameraController_FrameProcessingErrorHandler;
            cameraController.CameraClosingHandler += CameraController_CameraClosingHandler;
        }

        private void btnCloseCameraView_Click(object sender, EventArgs e)
        {
            cameraController.FrameProcessingHandler -= CameraController_FrameProcessingHandler;
            cameraController.MotionFrameProcessingHandler -= CameraController_MotionFrameProcessingHandler;
            cameraController.FrameProcessingErrorHandler -= CameraController_FrameProcessingErrorHandler;
            cameraController.CameraClosingHandler -= CameraController_CameraClosingHandler;
            this.Close();
        }

        private void CameraController_FrameProcessingHandler(Bitmap image)
        {
            RenderImage(pboxLiveCamera, image);
        }

        private void CameraController_MotionFrameProcessingHandler(Bitmap image)
        {
            RenderImage(pboxMotionCamera, image);
        }

        private void CameraController_CameraClosingHandler(CameraState cameraState)
        {
            
        }

        private void CameraController_FrameProcessingErrorHandler(string errorMessage)
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
