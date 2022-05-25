using UnityEngine;

namespace MF
{
	public class App : MonoBehaviour
	{
		public static TimeManager TimeManager { get; private set; }
		public static bool IsTimeStopped { get; set; }
		public static HumanController SelectedHumanController { get; set; }
		public static VirusModel CurrentVirus { get; set; } = new VirusModel();

		private void Awake()
		{
			TimeManager = FindObjectOfType<TimeManager>();
		}

		private void Start()
		{
			IsTimeStopped = true;
		}
	}
}
