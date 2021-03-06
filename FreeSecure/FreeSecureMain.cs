﻿using System;
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
            try
            {
                cameraControllers = new Dictionary<string, Controller>();
                cameraManager = new CameraManager();
                cameraManager.LoadCameras();
                foreach (var camera in cameraManager.Cameras)
                {
                    cameraControllers[camera.Name] = new Controller(camera.Name, camera.MonikerString);
                    comboBox1.Items.Add(camera.Name);
                }
                comboBox1.SelectedIndex = 0;
            }
            catch (CameraLoadException exception)
            {
                btnStartCamera.Enabled = false;
                btnStopCamera.Enabled = false;
                btnViewCamera.Enabled = false;
                DisplayMessageBox("Cameras couldn't bel loaded, restart the applications");
            }

        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            string cameraName = comboBox1.SelectedItem.ToString();

            if (!cameraControllers[cameraName].IsRunning())
            {
                cameraControllers[cameraName].StartCamera();
                cameraControllers[cameraName].MotionFrameProcessingHandler += MotionFrameProcessingHandler;
                LoadCameraStatus();
            }
            else
            {
                DisplayMessageBox(string.Format("{0} is already running", cameraName));
            }
        }

        private void btnStopCamera_Click(object sender, EventArgs e)
        {
            string cameraName = comboBox1.SelectedItem.ToString();

            if (cameraControllers[cameraName].IsRunning())
            {
                cameraControllers[cameraName].MotionFrameProcessingHandler -= MotionFrameProcessingHandler;
                cameraControllers[cameraName].StopCamera();
                LoadCameraStatus();
            }
            else
            {
                DisplayMessageBox(string.Format("{0} is not running", cameraName));
            }

        }

        private void btnViewCamera_Click(object sender, EventArgs e)
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

        private void FreeSecureMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (KeyValuePair<string, Controller> cameraController in cameraControllers)
            {
                cameraController.Value.MotionFrameProcessingHandler -= MotionFrameProcessingHandler;
                cameraController.Value.StopCamera();
            }
        }

        private void DisplayMessageBox(string Message)
        {
            MessageBox.Show(Message);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCameraStatus();
        }

        private void LoadCameraStatus()
        {
            string cameraName = comboBox1.SelectedItem.ToString();
            bool isCameraRunning = cameraControllers[cameraName].IsRunning();
            pboxStatus.Image = isCameraRunning ? Properties.Resources.on : Properties.Resources.off;
            pboxStatus.Refresh();
            
        }

        private void MotionFrameProcessingHandler(MotionModel motionModel)
        {
            FreeSecureLib.Network.HttpClient client = new FreeSecureLib.Network.HttpClient();
            client.UploadToServer(motionModel);
        }
    }
}
