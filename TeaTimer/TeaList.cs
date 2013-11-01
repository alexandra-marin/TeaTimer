using System;
using System.Collections.Generic;
using System.Linq;

namespace TeaTimer
{
	public class TeaList : ITeaList
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

		public List<string> GetTeaNamesList()
		{
			return teaOptions.Select (tea => tea.Name).ToList ();
		}

		public TimeSpan GetDurationForTea(string teaName)
		{
			return teaOptions.First (tea => tea.Name == teaName).Duration;
		}
 
		/// <summary>
		/// Defines the tea varieties and their durations
		/// </summary>
		/// <author>Alexandra Marin</author>
		public void DefineTeaVarieties ()
		{
			teaOptions.Add ( new Tea() {
				Name = "Green Tea", 
				Duration = new TimeSpan (0, 0, 10) 
			});
			teaOptions.Add ( new Tea() {
				Name = "Black Tea", 
				Duration =  new TimeSpan (0, 0, 5) 
			});
		}
	}
}

