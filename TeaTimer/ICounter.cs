using System;
using System.Threading; 

namespace TeaTimer
{
	public interface ICounter
	{ 
		void StartCounting (); 
		void RequestStop ();
	}
}

