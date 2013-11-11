using System;
using System.Threading;
using MonoMac.AppKit;

namespace TeaTimer
{
	public class CountdownTimer : ITimer
	{
		public Thread countdownThread = null;
		private ICounter counter;
 
		public CountdownTimer (TimeSpan time, NSTextField countdownLabel, NSTextField infoLabel)
		{
			counter = new Countdown (time, countdownLabel, infoLabel);
		}
		 
		/// <summary>
		/// Starts the countdown.
		/// </summary>
		/// <author> Alexandra Marin </author>
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

		/// <summary> Checks if the counter thread is active </summary>
		/// <returns> Thread state </returns>
		/// <author> Alexandra Marin </author>
		public bool IsRunning ()
		{ 
			return countdownThread != null & countdownThread.IsAlive; 
		}
	}
}

