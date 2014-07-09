using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeSecureLib.Camera
{
    public enum CameraState
    {
        EndOfStream = 0,
        CameraStopped = 1,
        CameraLost = 2,
        CameraError = 4
    }
}
