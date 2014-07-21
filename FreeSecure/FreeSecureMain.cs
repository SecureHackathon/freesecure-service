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
                MessageBox.Show("Cameras couldn't bel loaded, restart the applications");
            }
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            if (cameraManager.CamerasLoaded) {
                string cameraName = comboBox1.SelectedItem.ToString();

                if (!cameraControllers[cameraName].IsRunning())
                {
                    cameraControllers[cameraName].StartCamera();
                    cameraControllers[cameraName].MotionFrameProcessingHandler += MotionFrameProcessingHandler;
                }
                else
                {
                    MessageBox.Show(string.Format("{0} is already running", cameraName));
                }
            }
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            if (cameraManager.CamerasLoaded)
            {
                string cameraName = comboBox1.SelectedItem.ToString();

                if (cameraControllers[cameraName].IsRunning())
                {
                    cameraControllers[cameraName].MotionFrameProcessingHandler -= MotionFrameProcessingHandler;
                    cameraControllers[cameraName].StopCamera();
                }
                else
                {
                    MessageBox.Show(string.Format("{0} is not running", cameraName));
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MotionFrameProcessingHandler(Bitmap frame)
        {
            MessageBox.Show("Motion detected");
        }
    }
}
