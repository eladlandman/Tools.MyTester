using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IVCAM.Tools.TestersCore.Test;
using IVCAM.Tools.TestersCore.Test.TestProgram;

namespace RealSense.Tools.MyTester.Tests
{
    public class StartupTest:TestBase<Ds5Dut>
    {
        public StartupTest() : base("Demo Tester", int.MaxValue)
        {

        }
        protected override BinningTestResult ValidateTestRunPrerequisites(Ds5Dut dut)
        {
            dut.Logger.Info("Starting StartUp Test");
            /*
            return new TesterFailureTestResult("failed recognize unit", TestProgramProvider.Bin_CameraNotFound);
            */
            return new PassTestResult();
        }

        protected override BinningTestResult InternalRun(Ds5Dut dut, CancellationToken token)
        {
            dut.Logger.Info("Starting InternalRun of StartupTest");
            //new TesterFailureTestResult()
            dut.InitCamera();
            /*
            dut.Logger.Debug("Connected device details: " + Environment.NewLine + dut.Camera.DeviceDetails);
            */
            if (dut.Camera == null)
            {
                return new TesterFailureTestResult("failed recognize Ds5 unit", TestProgramProvider.Bin_CameraNotFound);
            }

            else
            {
                dut.Logger.Info($"Camera Serial Number is:{dut.Camera.DeviceInformation.GetSerialNumber()}");
                return new PassTestResult();
            }
        }

        protected override BinningTestResult PostTestExecution(Ds5Dut dut, BinningTestResult testResult)
        {
            dut.ExpectedSerialNumber = "0000000000";
            dut.Logger.Info($"expected serial number is: {dut.ExpectedSerialNumber}");
            dut.InitOutput(ConfigurationManager.AppSettings["ManualTesterBinPath"], dut.ExpectedSerialNumber, "m");
            return testResult;
        }

       
    }
}
