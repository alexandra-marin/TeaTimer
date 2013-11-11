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
	public class Countdown : ICounter
	{
		private TimeSpan time;
		private TimeSpan timeUnit;
		private NSTextField countdownLabel;
		private NSTextField infoLabel;  
		private volatile bool pleaseStop; //This member will be modified by multiple threads
	   
		public Countdown(TimeSpan time, NSTextField countdownLabel, NSTextField infoLabel)
		{
			this.time = time;
			this.timeUnit = new TimeSpan (0, 0, 1); // Define basic time unit as one second
			this.countdownLabel = countdownLabel;
			this.infoLabel = infoLabel; 
		} 

		/// <summary>
		/// This method that will be called when the thread is started.
		/// Counts down from the provided time and displays the current time in a label.
		/// </summary>
		/// <author>Alexandra Marin</author>
		public void StartCounting()
		{ 
			while (time.Seconds > 0) 
			{
				//Break the loop if the stop command was given
				if (pleaseStop) 
					return;

				UpdateCountdownLabel (); 
				UpdateCounter ();
			} 

			ShowDoneMessage ();
		}  

		/// <summary>
		/// This method that will be called when the thread
		/// needs to be stopped before it has completed its work.
		/// </summary>
		/// <author>Alexandra Marin</author>
		public void RequestStop()
		{
			pleaseStop = true;
		} 
 
		/// <summary>
		/// Updates the UI countdown label from a background thread
		/// </summary>
		private void UpdateCountdownLabel ()
		{
			countdownLabel.InvokeOnMainThread (() =>  {
				countdownLabel.StringValue = time.ToString ();
			});
		}

		/// <summary>
		/// Substract a second.
		/// </summary>
		private void UpdateCounter ()
		{
			Thread.Sleep (timeUnit);
			time = time.Subtract (timeUnit);
		}

		/// <summary>
		/// If the thread naturally finished, update the display with a "done" message
		/// and clear the countdown label.
		/// Will be called from background thread.
		/// </summary>
		void ShowDoneMessage ()
		{ 
			infoLabel.InvokeOnMainThread (() =>  {
				infoLabel.StringValue = "Tea is ready!";
				countdownLabel.StringValue = "";
			});
   		} 
	};
}

