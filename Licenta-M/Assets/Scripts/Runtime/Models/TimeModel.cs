using UnityEngine;

namespace MF
{
	public class TimeModel
	{
		public int Hours { get; set; } = 0;
		public int Minutes { get; set; } = 0;
		public int Seconds { get; set; } = 0;

		public TimeModel(int hour, int minute, int second)
		{
			Hours = hour;
			Minutes = minute;
			Seconds = second;
		}

		public override string ToString()
		{
			return Hours + ":" + Minutes + ":" + Seconds;
		}
	}
}
