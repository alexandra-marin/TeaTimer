using System;

namespace TeaTimer
{
	public interface ITimer
	{
		void Start();
		void Stop();
		bool IsRunning();
	}
}

