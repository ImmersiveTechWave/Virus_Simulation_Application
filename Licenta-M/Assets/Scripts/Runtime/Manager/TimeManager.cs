using UnityEngine;
using TMPro;

namespace MF
{
	public class TimeManager : MonoBehaviour
	{
		[Range(0f, 24f)] public int StartHour = 8;
		[Range(0.1f, 5000f)] public float TimeMultipilcator = 500f;

		public TimeModel TimeModel { get; set; }
		public TMP_Text TimeText;

		private float startTime;

		private void Awake()
		{
			TimeModel = new TimeModel(StartHour, 0, 0);
		}

		private void Start()
		{
			startTime = Time.time;
		}

		void Update()
		{
			var currentTime = (Time.time - startTime) * TimeMultipilcator;

			TimeModel.Seconds = (int)(currentTime % 60);
			TimeModel.Minutes = (int)(currentTime / 60) % 60;
			TimeModel.Hours = ((int)(currentTime / 3600) + StartHour) % 24;

			var newTime = string.Format("{0:0}:{1:00}:{2:00}", TimeModel.Hours, TimeModel.Minutes, TimeModel.Seconds);
			if (TimeText != null)
			{
				TimeText.text = newTime;
			}
		}
	}
}
