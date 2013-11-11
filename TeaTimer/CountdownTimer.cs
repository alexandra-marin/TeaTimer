using System;
using System.Threading;
using MonoMac.AppKit;

namespace TeaTimer
{
	public class CountdownTimer : ICountdownTimer
	{
		public Thread countdownThread = null;
		private ICounter counter;
 
		public CountdownTimer (TimeSpan time, NSTextField countdownLabel, NSTextField infoLabel)
		{
			counter = new Countdown (time, countdownLabel, infoLabel);
		}
		 
		public void Start()
		{
			countdownThread = new Thread( new ThreadStart (counter.StartCounting) );
			countdownThread.Start ();
		}
 
		/// <summary>
		/// Requests the countdown to stop gracefully.
		/// Called from outside this thread.
		/// </summary>
		/// <author>Alexandra Marin</author>
		public void Stop()
		{
			counter.RequestStop (); 
		} 

		public bool IsRunning ()
		{ 
			return countdownThread != null & countdownThread.IsAlive; 
		}
	}
}

