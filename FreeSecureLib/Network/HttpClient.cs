using FreeSecureLib.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FreeSecureLib.Network
{
    public class HttpClient
    {
        private WebClient _webClient;

        public HttpClient()
        {
            _webClient = new System.Net.WebClient();
        }

        public void UploadToServer(MotionModel motionModel)
        {
            Thread thread = new Thread(UploadImage);
            thread.Start(motionModel);
        }

        public void UploadImage(object model)
        {
            var motionModel = (Camera.MotionModel)model;
            string imageFileName = string.Format("{0}_{1}.jpg", motionModel.CameraName, Guid.NewGuid());
            motionModel.Image.Save(imageFileName);
            System.Threading.Thread.Sleep(2000);
            _webClient.UploadFile("http://localhost/SecureWeb/api/image", "POST",imageFileName);
        }
    }
}
