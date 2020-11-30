using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IVCAM.Tools.TestersCore.Test;
using IVCAM.Tools.TestersCore.Test.TestProgram;
using System.IO;



namespace RealSense.Tools.MyTester.Tests
{
    
    public class SecondTest : TestBase<Ds5Dut>
    {
        public SecondTest() : base("Second Test", int.MaxValue)
        {
        }



        protected override BinningTestResult ValidateTestRunPrerequisites(Ds5Dut dut)
        {
            dut.Logger.Info("Starting Second Test");
            return new PassTestResult();

        }
        
        protected override BinningTestResult InternalRun(Ds5Dut dut, CancellationToken token)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), ".logprofile.txt");
            path = Path.ChangeExtension(dut.OutputFolder, ".logprofile.txt");
            dut.Logger.Info("Starting InternalRun of SecondTest");
            dut.InitCamera();
            if(dut.Camera == null)
            {
                dut.InitCamera();
            }
            dut.Logger.Debug("Connected device details: " + Environment.NewLine + dut.Camera.DeviceDetails);
            if (dut.Camera == null)
            {
                return new TesterFailureTestResult("failed recognize Ds5 unit", TestProgramProvider.Bin_CameraNotFound);
            }

            else
            {
                dut.Logger.Info($"Camera Serial Number is:{dut.Camera.DeviceInformation.GetSerialNumber()}");
                dut.Camera.HwFacade.CommandsService.Send($"RunLogProfiler 1 { path}");
                Thread.Sleep(5000);
                dut.Camera.HwFacade.CommandsService.Send($"RunLogProfiler 0 { path}");
                return new PassTestResult();
            }
        }
      

        protected override BinningTestResult PostTestExecution(Ds5Dut dut, BinningTestResult testResult)
        {
            
            return testResult;
        }

        
    }

}

