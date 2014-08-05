using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeSecureLib.Camera
{
    public class CameraLoadException : Exception
    {
        public CameraLoadException(string message) 
            :base(message)
        {

        }
    }
}
