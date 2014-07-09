using AForge.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeSecureLib.Camera
{
    class CameraStateManager
    {
        public static CameraState ConvertState(ReasonToFinishPlaying reason)
        {
            switch (reason)
            {
                case ReasonToFinishPlaying.EndOfStreamReached:
                    return CameraState.EndOfStream;
                case ReasonToFinishPlaying.StoppedByUser:
                    return CameraState.CameraStopped;
                case ReasonToFinishPlaying.DeviceLost:
                    return CameraState.CameraLost;
                default:
                    return CameraState.CameraError;
            }
        }
    }
}
