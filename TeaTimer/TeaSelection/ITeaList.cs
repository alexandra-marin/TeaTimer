using System;
using System.Collections.Generic;
using MonoMac.AppKit;

namespace TeaTimer
{
	public interface ITeaList
	{
		void Add(Tea tea);
		NSComboBoxDataSource CreateDataSourceFromTeaNameList ();
		TimeSpan GetDurationForTea (string teaName);
		void DefineTeaVarieties ();
	}
}

