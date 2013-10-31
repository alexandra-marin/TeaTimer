using System;
using System.Collections.Generic;
using System.Linq;

namespace TeaTimer
{
	public class TeaList : ITeaList<Tea>
	{
		private List<Tea> teaOptions;

		public TeaList ()
		{
			teaOptions = new List<Tea> ();
		}

		public void Add(Tea tea)
		{
			teaOptions.Add (tea);
		}

		public List<string> GetTeaNameList()
		{
			return teaOptions.Select (tea => tea.Name).ToList ();
		}

		public TimeSpan GetDurationForTea(string teaName)
		{
			return teaOptions.First (tea => tea.Name == teaName).Duration;
		}
	}
}

