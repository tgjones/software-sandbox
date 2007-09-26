using System;
using System.Globalization;

namespace CalendarConverter
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(new ChineseLunisolarCalendar().ToDateTime(1980, 10, 30, 0, 0, 0, 0).ToString());
		}
	}
}
