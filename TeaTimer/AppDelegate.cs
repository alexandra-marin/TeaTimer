using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace TeaTimer
{
	public partial class AppDelegate : NSApplicationDelegate
	{
		TeaTimerWindowController teaTimerWindowController;

		public AppDelegate ()
		{
		}

		public override void FinishedLaunching (NSObject notification)
		{
			teaTimerWindowController = new TeaTimerWindowController ();
			teaTimerWindowController.Window.MakeKeyAndOrderFront (this);
		}
	}
}

