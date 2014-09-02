using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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

        public void UploadDetection(string cameraName)
        {
            string uploadString = "{\"CameraName\": \"" + cameraName + "\"}";
            _webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            _webClient.UploadStringAsync(
                new Uri("http://localhost/SecureWeb/api/detection"), 
                "POST",
                uploadString);
        }
    }
}
