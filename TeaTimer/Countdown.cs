using System;
using System.Threading;
using MonoMac.AppKit;

namespace TeaTimer
{
	/// <summary>
	/// This class holds the countdown logic.
	/// It will run on a separate thread.
	/// </summary>
	/// <author>Alexandra Marin</author>
	public class CountDown : ICounter
	{
		TimeSpan time;
		NSTextField countdownLabel;
		NSTextField infoLabel; 

		//Volatile means that this member can be modified by multiple threads
		private volatile bool pleaseStop; 

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
				//Break the loop if the stop command was given
				if (pleaseStop) 
					return;

				//Update display
				countdownLabel.InvokeOnMainThread (() => {
					countdownLabel.StringValue = time.ToString ();
				});

				//Substract a second
				Thread.Sleep (1000);
				time = time.Subtract (new TimeSpan (0, 0, 1));
			} 

			//If the thread naturally finished, update the display with a "done" message
			infoLabel.InvokeOnMainThread (() => {
				infoLabel.StringValue = "Tea is ready!";
				countdownLabel.StringValue = "";
			}); 
		} 

		/// <summary>
		/// Requests the countdown to stop gracefully.
		/// Called from outside this thread.
		/// </summary>
		/// <author>Alexandra Marin</author>
		public void RequestStop()
		{
			pleaseStop = true;
		} 
	};
}

