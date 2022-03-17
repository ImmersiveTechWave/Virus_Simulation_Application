using UnityEngine;
using UnityEngine.UI;

namespace MF
{
	public class TimeManager : MonoBehaviour
	{
		public float StartTime { get; set; }
		public int Hours { get; set; }
		public int Minutes { get; set; }
		public int Seconds { get; set; }

		private void Start()
		{
			StartTime = Time.time - 10000;
		}

		void Update()
		{
			Seconds = (int)((Time.time - StartTime) % 60);
			Minutes = (int)((Time.time - StartTime) / 60) % 60;
			Hours = (int)((Time.time - StartTime) / 3600) % 60;
			string newTime = string.Format("{0:0}:{1:00}:{2:00}", Hours, Minutes, Seconds);
		}
	}
}
