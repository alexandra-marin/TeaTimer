using System;
using System.Threading; 

namespace TeaTimer
{
	public interface ICounter
	{
		Thread GetCountdownThread();
		void Start ();
		void Stop();
	}
}

