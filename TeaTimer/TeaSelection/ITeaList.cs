using System;
using System.Collections.Generic;
using MonoMac.AppKit;

namespace TeaTimer
{
	public interface ITeaList
	{ 
		void DefineTeaVarieties ();
		NSComboBoxDataSource CreateDataSourceFromTeaNameList ();
		TimeSpan GetDurationForTea (string teaName);
	}
}

