using System.Windows;
using GalaSoft.MvvmLight.Threading;
using PercHW.Tools.TesterUI.Main;
using RealSense.Tools.TesterUI.Nuget;

namespace RealSense.Tools_MyTester
{
    public partial class App
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            this.InitializeTesterUI(new TesterContext());

            base.OnStartup(e);
        }
    }
}