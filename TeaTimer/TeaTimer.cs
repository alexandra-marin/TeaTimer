using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Threading;

namespace TeaTimer
{
	public partial class TeaTimerWindowController : MonoMac.AppKit.NSWindowController
	{ 
		ITeaList teaOptions;
		ICountdownTimer timer = null;

		#region Constructors

		// Called when created from unmanaged code
		public TeaTimerWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public TeaTimerWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		// Call to load from the XIB/NIB file
		public TeaTimerWindowController () : base ("MainWindow")
		{
			Initialize ();
		}
		// Shared initialization code
		void Initialize ()
		{ 
		}

		#endregion

		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}

		public override void AwakeFromNib ()
		{ 
			teaOptions = new TeaList();
			teaOptions.DefineTeaVarieties ();

			InitComboBox ();

			//Set the Start Button behaviour
			StartButton.Activated += (object sender, EventArgs e) => {
				// Reset labels
				InfoLabel.StringValue = "";
				CountdownLabel.StringValue = "";

				//If another countdown is running, stop it before starting a new one
				StopPreviousTimer (); 
				StartNewTimer ();
			};
		}

		/// <summary>
		/// Init the combo box that holdes the tea varieties
		/// and selects the first item
		/// </summary>
		/// <author>Alexandra Marin</author>
		void InitComboBox ()
		{
			TeaChoicesCombo.UsesDataSource = true;
			TeaChoicesCombo.DataSource = teaOptions.CreateDataSourceFromTeaNameList ();
			TeaChoicesCombo.SelectItem (0);
			TeaChoicesCombo.Editable = false;
		}

		/// <summary>
		/// Checks for previous counters and closes any running threads
		/// </summary>
		/// <author>Alexandra Marin</author>
		void StopPreviousTimer ()
		{ 
			if (timer != null && timer.IsRunning()) {
				timer.Stop ();
			}
		}

		/// <summary>
		/// Starts the count down.
		/// Gets the time interval corresponding to the selected option in the combo
		/// </summary>
		/// <author>Alexandra Marin</author>
		private void StartNewTimer ()
		{  
			//Get the time 
			string varietyName = TeaChoicesCombo.DataSource.ObjectValueForItem (TeaChoicesCombo, TeaChoicesCombo.SelectedIndex).ToString(); //"Green tea"
			TimeSpan time = teaOptions.GetDurationForTea(varietyName);

			//Init a new counter
			timer = new CountdownTimer (time, CountdownLabel, InfoLabel);
			timer.Start ();
		}
	}
}

