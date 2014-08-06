using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeSecure.UserControls
{
    public partial class CameraStatusManager : UserControl
    {
        private bool isCameraRunning = false;
        private Action<bool> cameraDelegate;
        private string imageAddress = "../resources/images/{0}.png";

        public CameraStatusManager()
        {
            InitializeComponent();
        }

        private void CameraStatusManager_Load(object sender, EventArgs e)
        {

        }

        public bool IsCameraRunning {
            get
            {
                return isCameraRunning;
            }
            set
            {
                isCameraRunning = value;
                ShowCameraStatus(IsCameraRunning);
            }
        }

        private void ShowCameraStatus(bool isRunning)
        {
            pboxStatus.Image = Image.FromFile(string.Format(imageAddress, isCameraRunning ? "on" : "off"));
        }

    }
}
