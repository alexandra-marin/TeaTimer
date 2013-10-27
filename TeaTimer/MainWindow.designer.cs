// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace TeaTimer
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSTextField CountdownLabel { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField InfoLabel { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton StartButton { get; set; }

		[Outlet]
		MonoMac.AppKit.NSComboBox TeaChoicesCombo { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CountdownLabel != null) {
				CountdownLabel.Dispose ();
				CountdownLabel = null;
			}

			if (InfoLabel != null) {
				InfoLabel.Dispose ();
				InfoLabel = null;
			}

			if (StartButton != null) {
				StartButton.Dispose ();
				StartButton = null;
			}

			if (TeaChoicesCombo != null) {
				TeaChoicesCombo.Dispose ();
				TeaChoicesCombo = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
