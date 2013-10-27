using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Threading;

namespace TeaTimer
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		Dictionary<string, TimeSpan> teaOptions;
		Thread countDownThread = null;

		#region Constructors

		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
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
			DefineTeaVarieties ();

			InitComboBox ();

			//Set the Start Button behaviour
			StartButton.Activated += (object sender, EventArgs e) => {
				StartCountDown ();
			};
		}

		/// <summary>
		/// Defines the tea varieties and their durations
		/// </summary>
		/// <author>Alexandra Marin</author>
		void DefineTeaVarieties ()
		{
			teaOptions = new Dictionary<string, TimeSpan>();
			teaOptions.Add ( 
			                "Green Tea", 
			                new TimeSpan (0, 0, 10) 
			);
			teaOptions.Add ( 
			                "Black Tea", 
			                new TimeSpan (0, 0, 5) 
			);
		}

		/// <summary>
		/// Init the combo box that holdes the tea varieties
		/// and selects the first item
		/// </summary>
		/// <author>Alexandra Marin</author>
		void InitComboBox ()
		{
			TeaChoicesCombo.UsesDataSource = true;
			TeaChoicesCombo.DataSource = new TeaVarietiesDataSource (teaOptions.Keys.ToList ());
			TeaChoicesCombo.SelectItem (0);
			TeaChoicesCombo.Editable = false;
		}

		/// <summary>
		/// Starts the count down.
		/// If another countdown is running, it stops it and starts a new one
		/// </summary>
		/// <author>Alexandra Marin</author>
		private void StartCountDown ()
		{ 
			InfoLabel.StringValue = "";

			//Get the time
			string variety = TeaChoicesCombo.DataSource.ObjectValueForItem (TeaChoicesCombo, TeaChoicesCombo.SelectedIndex).ToString();
			TimeSpan time = teaOptions[variety];

			//Init a new counter
			CountDown cd = new CountDown (time, CountdownLabel, InfoLabel);

			//Close any running threads
			if (countDownThread != null && countDownThread.IsAlive)
				countDownThread.Abort ();

			//Start the countdown
			countDownThread = new Thread( new ThreadStart (cd.Start) );
			countDownThread.Start ();
		}
	}

	/// <summary>
	/// This class represents the data source for the combo box.
	/// Each entry in the varieties list is an option in the dropdown.
	/// </summary>
	/// <author>Alexandra Marin</author>
	class TeaVarietiesDataSource : NSComboBoxDataSource
	{ 
		List<string> varieties;

		public TeaVarietiesDataSource(List<string> varieties) 
		{ 
			this.varieties = varieties;
		}

		public override int ItemCount (NSComboBox comboBox)
		{
			return varieties.Count;
		}

		public override NSObject ObjectValueForItem (NSComboBox comboBox, int index)
		{
			if (index == -1)
				index = 0;
			return NSObject.FromObject (varieties [index]);
		}
	}

	/// <summary>
	/// This class holds the countdown logic.
	/// It will run on a separate thread.
	/// </summary>
	/// <author>Alexandra Marin</author>
	public class CountDown
	{
		TimeSpan time;
		NSTextField countdownLabel;
		NSTextField infoLabel;

		public CountDown(TimeSpan time, NSTextField countdownLabel, NSTextField infoLabel)
		{
			this.time = time;
			this.countdownLabel = countdownLabel;
			this.infoLabel = infoLabel;
		}

		/// <summary>
		/// This method that will be called when the thread is started.
		/// Counts down from the provided time and displays the current time in a label.
		/// </summary>
		/// <author>Alexandra Marin</author>
		public void Start()
		{
			while (time.Seconds > 0) 
			{
				countdownLabel.InvokeOnMainThread( () => {
					countdownLabel.StringValue = time.ToString();
				});

				Thread.Sleep (1000);
				time = time.Subtract (new TimeSpan (0, 0, 1));
			} 

			infoLabel.InvokeOnMainThread (() => {
				countdownLabel.StringValue = "";
				infoLabel.StringValue = "Tea is ready!";
			});
		} 
	};
}

