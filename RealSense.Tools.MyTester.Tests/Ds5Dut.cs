using System;
using System.Threading;
using IVCam.Tools.CamerasSdk.Cameras;
using IVCam.Tools.CamerasSdk.Cameras.Camera;
using IVCam.Tools.CamerasSdk.Cameras.Generic.DS5.Devices;
using IVCam.Tools.CamerasSdk.Cameras.Managers;
using IVCAM.Tools.TestersCore.Device;
using IVCAM.Tools.TestersCore.Test;
using IVCAM.Tools.TestersCore.Test.TestProgram;
using PerCHW.Tools.CameraHW.DeviceInfo;
using Moq;
using System.IO;




namespace RealSense.Tools.MyTester.Tests
{
    
    public class Ds5Dut: DeviceUnderTest
    {
        private DeviceManager<IDS5DeviceDetails> _ds5DeviceManager;
        private readonly AutoResetEvent _cameraConnectedResetEvent = new AutoResetEvent(false);
        private IDS5DeviceDetails _deviceDetails;
        private string _usbPortLocationSuffix;
        private IRealSenseCam _camera;
      
        public IDeviceInfoService DeviceInfoService { get; set; }

       

       

        public IRealSenseCam Camera
        {
            get
            {
                if (_camera == null)
                {
                    throw new BinException(new TesterFailureTestResult("Camera is not initialized or disconnected!",
                        TestProgramProvider.Bin_CameraNotFound));
                }
                return _camera;
            }
        }

        public Ds5Dut(int index) : base("DS5 Camera", index)
        {
            _ds5DeviceManager = new DeviceManager<IDS5DeviceDetails>();
        }


        /*
        public override void ClearDut()
        {
            base.ClearDut();
            DeviceInfoService = null;
            _camera = null;
        }

        public bool ResetCamera()
        {
            Logger.Info("Reset camera");
            _cameraConnectedResetEvent.Reset();
            Camera.HwFacade.CommandsService.Send("rst");
            _camera = null;
            if (!WaitForCamera())
                return false;
            InitCamera();
            return true;
        }

        public bool WaitForCamera()
        {
            Logger.Info("Wait for camera to connect ...");
            return _cameraConnectedResetEvent.WaitOne((int)TestProgramProvider.CameraConnectionTimeout);
        }
        */
        public void InitCamera()
        {
            /*if (!TestProgramProvider.UsePowerHub && TestProgramProvider.SingleUnitMode)*/
            {
                
                if (_ds5DeviceManager.CameraFactory.GetNumberOfConnectedDevices() == 0)
                {
                    throw new BinException(new TesterFailureTestResult("Camera is not connected", TestProgramProvider.Bin_CameraNotFound));
                }
                
               
                _camera = _ds5DeviceManager.CameraFactory.CreateFirstAvailableCamera();
                DeviceInfoService = Camera.HwFacade.ServiceProvider.GetService<IDeviceInfoService>();
                
              
            }
        }


      
       
    }
}

