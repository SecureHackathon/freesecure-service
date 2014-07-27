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
    public partial class FreeSecureMain : Form
    {
        private CameraManager cameraManager;
        private Dictionary<string, Controller> cameraControllers;
        public FreeSecureMain()
        {
            InitializeComponent();
        }

        private void FreeSecureMain_Load(object sender, EventArgs e)
        {
            cameraControllers = new Dictionary<string, Controller>();
            cameraManager = new CameraManager();
            cameraManager.LoadCameras();
            if (cameraManager.CamerasLoaded)
            {
                foreach (var camera in cameraManager.Cameras)
                {
                    cameraControllers[camera.Name] = new Controller(camera.MonikerString);
                    comboBox1.Items.Add(camera.Name);
                }
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                DisplayMessageBox("Cameras couldn't be loaded, restart the applications");
            }
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            if (CanUseCameras) {
                string cameraName = comboBox1.SelectedItem.ToString();

                if (!cameraControllers[cameraName].IsRunning())
                {
                    cameraControllers[cameraName].StartCamera();
                    cameraControllers[cameraName].MotionFrameProcessingHandler += MotionFrameProcessingHandler;
                }
                else
                {
                    DisplayMessageBox(string.Format("{0} is already running", cameraName));
                }
            }
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            if (CanUseCameras)
            {
                string cameraName = comboBox1.SelectedItem.ToString();

                if (cameraControllers[cameraName].IsRunning())
                {
                    cameraControllers[cameraName].MotionFrameProcessingHandler -= MotionFrameProcessingHandler;
                    cameraControllers[cameraName].StopCamera();
                }
                else
                {
                    DisplayMessageBox(string.Format("{0} is not running", cameraName));
                }
            }
        }

        private void btnViewCamera_Click(object sender, EventArgs e)
        {
            if (CanUseCameras)
            {
                string cameraName = comboBox1.SelectedItem.ToString();

                if (cameraControllers[cameraName].IsRunning())
                {
                    CameraView cameraView = new CameraView(cameraControllers[cameraName]);
                    cameraView.ShowDialog();
                }
                else
                {
                    DisplayMessageBox("Can't view a camera that is not running.\nStart camera to view");
                }
            } 
        }

        private void FreeSecureMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CanUseCameras)
            {
                foreach (KeyValuePair<string, Controller> cameraController in cameraControllers)
                {
                    cameraController.Value.MotionFrameProcessingHandler -= MotionFrameProcessingHandler;
                    cameraController.Value.StopCamera();
                }
            }
        }

        private bool CanUseCameras
        {
            get { return cameraManager.CamerasLoaded; }
        }

        private void DisplayMessageBox(string Message)
        {
            MessageBox.Show(Message);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MotionFrameProcessingHandler(Bitmap frame)
        {
            //
        }
    }
}
