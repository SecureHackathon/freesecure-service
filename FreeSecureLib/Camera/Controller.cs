using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.VFW;
using AForge.Video.DirectShow;
using AForge.Vision.Motion;

namespace FreeSecureLib.Camera
{
    public class Controller
    {

        public event Action<System.Drawing.Bitmap> FrameProcessingHandler;

        public event Action<System.Drawing.Bitmap> MotionFrameProcessingHandler;

        public event Action<CameraState> CameraClosingHandler;

        public event Action<string> FrameProcessingErrorHandler;

        private IVideoSource videoSource;

        private VideoCaptureDevice videoDevice;

        private MotionDetector motionDetector;

        private static object frameLock = new object();

        public Controller(string monikerString) {
            videoDevice = new VideoCaptureDevice(monikerString);
            videoSource = new AsyncVideoSource(videoDevice, true);
            motionDetector = new MotionDetector(new SimpleBackgroundModelingDetector());
        }

        public bool IsRunning()
        {
            return videoSource.IsRunning;
        }

        public void StartCamera()
        {
            if (!IsRunning())
            {
                videoSource.Start();
                videoSource.NewFrame += videoSource_NewFrame;
                videoSource.PlayingFinished += videoSource_PlayingFinished;
                videoSource.VideoSourceError += videoSource_VideoSourceError;
            }

        }

        public void StopCamera()
        {
            if (IsRunning()) {
                videoSource.SignalToStop();
                videoSource.Stop();

                videoSource.NewFrame -= videoSource_NewFrame;
                videoSource.PlayingFinished -= videoSource_PlayingFinished;
                videoSource.VideoSourceError -= videoSource_VideoSourceError;
            }
        }

        private void videoSource_VideoSourceError(object sender, VideoSourceErrorEventArgs eventArgs)
        {
            if (FrameProcessingErrorHandler != null)
                FrameProcessingErrorHandler(eventArgs.Description);
        }

        private void videoSource_PlayingFinished(object sender, ReasonToFinishPlaying reason)
        {
            if (CameraClosingHandler != null)
                CameraClosingHandler(CameraStateManager.ConvertState(reason));
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            lock (frameLock)
            {
                System.Drawing.Bitmap frame = eventArgs.Frame;

                if (FrameProcessingHandler != null)
                    FrameProcessingHandler(frame);

                if (MotionFrameProcessingHandler != null && motionDetector.ProcessFrame(eventArgs.Frame) > 0.10F)
                {
                    MotionFrameProcessingHandler(frame);
                }
            }
        }
    }
}
