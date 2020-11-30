
using System;
using System.Reflection;
using IVCAM.Tools.TestersCore.Test.Binning;

namespace IVCAM.Tools.TestersCore.Test.TestProgram
{
    //This is an auto-generated class by TestProgramClassGenerator.exe program. Do not modify !
    //The properties of this class are based on the TestProgram xml file.

    public static class TestProgramProvider
    {
		public static Boolean dummy => TestProgram.Instance.GetTestParameter("dummy").ParseValue<Boolean>();

		public static SoftBin Bin_CameraNotFound => TestProgram.Instance.GetSoftBin("Camera not found");
	}
}
