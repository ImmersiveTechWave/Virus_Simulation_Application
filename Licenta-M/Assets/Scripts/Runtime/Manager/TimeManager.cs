using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MF
{

	public class TimeManager : MonoBehaviour
	{
		public float StartTime { get; set; }
		public TimeModel TimeModel { get; set; }

		public TMP_Text TimeText;

		private void Awake()
		{
			TimeModel = new TimeModel();
		}

		private void Start()
		{
			StartTime = Time.time - 10000;
		}

		void Update()
		{
			TimeModel.Seconds = (int)((Time.time - StartTime) % 60);
			TimeModel.Minutes = (int)((Time.time - StartTime) / 60) % 60;
			TimeModel.Hours = (int)((Time.time - StartTime) / 3600) % 60;
			string newTime = string.Format("{0:0}:{1:00}:{2:00}", TimeModel.Hours, TimeModel.Minutes, TimeModel.Seconds);
			TimeText.text = newTime;
		}
	}
}
