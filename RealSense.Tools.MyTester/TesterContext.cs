using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using IVCAM.Tools.TestersCore.Device;
using IVCAM.Tools.TestersCore.Test;
using IVCAM.Tools.TestersCore.Utils;
using PercHW.Tools.TesterUI.Common.Utilities;
using PercHW.Tools.TesterUI.Main;
using RealSense.Tools.MyTester.Tests;

namespace RealSense.Tools.TesterUI.Nuget
{
    public sealed class TesterContext : BaseTesterContext<Ds5Dut>
    {
        public TesterContext() : base("MyFirstTester", new StickerInfo(StickerInfoType.NoSticker))
        {
        }

     

        public override IEnumerable<Ds5Dut> BuildDuts()
        {
            
            
            return new List<Ds5Dut> { new Ds5Dut(0) };
            
            /*
            return new List<DeviceUnderTest> { new DeviceUnderTest("Dut") };
            */
            
            
        }

        public override List<ITestsGroup<Ds5Dut>> CreateTestsGroups()
        {
            /*
            throw new NotImplementedException("Please provide at least one test");
            */
            return new List<ITestsGroup<Ds5Dut>> { new SingleDutTestsGroup<Ds5Dut>(
                new StartupTest(),new SecondTest()) };
        }
    }
}