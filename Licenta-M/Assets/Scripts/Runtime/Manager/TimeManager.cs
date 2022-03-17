using UnityEngine;
using TMPro;

namespace MF
{
	public class TimeManager : MonoBehaviour
	{
		public TimeModel TimeModel { get; set; }
		public TMP_Text TimeText;

		private float startTime;

		private void Awake()
		{
			TimeModel = new TimeModel();
		}

		private void Start()
		{
			startTime = Time.time - 10000;
		}

		void Update()
		{
			TimeModel.Seconds = (int)((Time.time - startTime) % 60);
			TimeModel.Minutes = (int)((Time.time - startTime) / 60) % 60;
			TimeModel.Hours = (int)((Time.time - startTime) / 3600) % 60;
			var newTime = string.Format("{0:0}:{1:00}:{2:00}", TimeModel.Hours, TimeModel.Minutes, TimeModel.Seconds);
			TimeText.text = newTime;
		}
	}
}
