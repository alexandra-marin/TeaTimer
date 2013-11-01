using System;
using System.Collections.Generic;

namespace TeaTimer
{
	public interface ITeaList
	{
		void Add(Tea tea);
		List<string> GetTeaNamesList();
		TimeSpan GetDurationForTea (string teaName);
		void DefineTeaVarieties ();
	}
}

