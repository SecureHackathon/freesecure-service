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
                        Name = cameraInfo.Name
                    });
                }
            }
            else
            {
                throw new CameraLoadException("No Cameras where detected on the computer");
            }
        }

        public List<CameraModel> Cameras { get; private set; }

    }
}
