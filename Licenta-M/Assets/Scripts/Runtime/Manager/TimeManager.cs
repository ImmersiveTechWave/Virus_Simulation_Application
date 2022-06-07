using UnityEngine;
using TMPro;

namespace MF
{
	public class TimeManager : MonoBehaviour
	{
		private const float HOURS = 24f;
		private const float HALF_HOURS = 12f;
		private const float MINUTES = 60f;
		private const float SECONDS = 60f;

		[Range(0f, 24f)] public int StartHour = 8;
		[Range(0.1f, 5000f)] public float TimeMultipilcator = 500f;

		public TimeModel TimeModel { get; set; }

		private float startTime;
		private SkyboxBlender skyboxBlender;
		private bool lastStateValue;
		private float whenTimeWasStopped = 0f;
		private float lastHour = 0;

		private void Awake()
		{
			TimeModel = new TimeModel(StartHour, 0, 0);
			skyboxBlender = GetComponent<SkyboxBlender>();
		}

		private void Start()
		{
			startTime = Time.time;
			lastStateValue = App.IsTimeStopped;
		}

		public void SetTime()
		{
			TimeModel = new TimeModel(StartHour, 0, 0);
			startTime = Time.time;
			lastStateValue = App.IsTimeStopped;
			whenTimeWasStopped = Time.time;
		}

		void Update()
		{
			if (lastStateValue != App.IsTimeStopped)
			{
				if (App.IsTimeStopped)
				{
					whenTimeWasStopped = Time.time;
				}
				else
				{
					startTime = startTime + Time.time - whenTimeWasStopped;
				}
				lastStateValue = App.IsTimeStopped;
			}

			if (!App.IsTimeStopped)
			{
				var currentTime = (Time.time - startTime) * TimeMultipilcator;

				TimeModel.Seconds = (int)(currentTime % SECONDS);
				TimeModel.Minutes = (int)(currentTime / SECONDS % MINUTES);
				lastHour = TimeModel.Hours;
				TimeModel.Hours = (int)(((currentTime / (SECONDS * MINUTES)) + StartHour) % HOURS);

				if (lastHour > TimeModel.Hours)
				{
					TimeModel.Day += 1;
				}

				var skyBoxBlendValue = 0f;
				if (TimeModel.Hours >= 0 && TimeModel.Hours <= HALF_HOURS)
				{
					skyBoxBlendValue = 1 - (TimeModel.Hours * MINUTES + TimeModel.Minutes) / (HALF_HOURS * MINUTES);
				}
				if (TimeModel.Hours > HALF_HOURS && TimeModel.Hours <= HOURS)
				{
					skyBoxBlendValue = (TimeModel.Hours * MINUTES + TimeModel.Minutes - (HALF_HOURS * MINUTES)) / (HALF_HOURS * MINUTES);
				}

				skyboxBlender.blend = skyBoxBlendValue;
			}
		}
	}
}
