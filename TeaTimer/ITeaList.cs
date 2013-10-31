using System;
using System.Collections.Generic;

namespace TeaTimer
{
	public interface ITeaList<Tea>
	{
		void Add(Tea tea);
		List<string> GetTeaNameList();
		TimeSpan GetDurationForTea (string teaName);
		void DefineTeaVarieties ();
	}
}

