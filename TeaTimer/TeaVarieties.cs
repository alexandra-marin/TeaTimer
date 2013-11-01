using System;
using MonoMac.AppKit;
using System.Collections.Generic;
using MonoMac.Foundation;

namespace TeaTimer
{
	/// <summary>
	/// This class represents the data source for the combo box.
	/// Each entry in the varieties list is an option in the dropdown.
	/// </summary>
	/// <author>Alexandra Marin</author>
	public class TeaVarieties : NSComboBoxDataSource
	{ 
		List<string> varieties;

		public TeaVarieties(List<string> varieties) 
		{ 
			this.varieties = varieties;
		}

		public override int ItemCount (NSComboBox comboBox)
		{
			return varieties.Count;
		}

		public override NSObject ObjectValueForItem (NSComboBox comboBox, int index)
		{
			if (index == -1)
				index = 0;
			return NSObject.FromObject (varieties [index]);
		}
	}
}

