using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video.DirectShow;

namespace FreeSecureLib.Camera
{
    public class CameraManager
    {
        private FilterInfoCollection cameraInfoCollection;
        private bool camerasLoaded = false;
        
        public void LoadCameras()
        {
            cameraInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (cameraInfoCollection.Count > 0)
            {
                Cameras = new List<CameraModel>();
                foreach (FilterInfo cameraInfo in cameraInfoCollection)
                {
                    Cameras.Add(new CameraModel
                    {
                        MonikerString = cameraInfo.MonikerString,
                        CameraID = cameraInfo.Name
                    });
                }
                camerasLoaded = true;
            }
        }

        public List<CameraModel> Cameras { get; set; }

        public bool CamerasLoaded
        {
            get { return camerasLoaded; }
        }
    }
}
