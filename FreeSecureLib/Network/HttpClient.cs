using FreeSecureLib.Camera;
using System;
using System.Collections.Generic;
using System.IO;
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
            UploadImage(motionModel);
        }

        public void UploadImage(object model)
        {
            var motionModel = (Camera.MotionModel)model;
            string imageFileName = string.Format("{0}_{1}.jpg", motionModel.CameraName, Guid.NewGuid().ToString("N"));
            File.WriteAllBytes(imageFileName, ConvertImageToByteArray(motionModel.Image));
            _webClient.UploadFile("http://localhost/SecureWeb/api/detection", "POST", imageFileName);
        }

        private byte[] ConvertImageToByteArray(System.Drawing.Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
