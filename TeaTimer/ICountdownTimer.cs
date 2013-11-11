using System;

namespace TeaTimer
{
	public interface ICountdownTimer
	{
		void Start();
		void Stop();
		bool IsRunning();
	}
}

