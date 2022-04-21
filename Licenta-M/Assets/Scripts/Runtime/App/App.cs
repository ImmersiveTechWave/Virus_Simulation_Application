using UnityEngine;

namespace MF
{
	public class App : MonoBehaviour
	{
		public static TimeManager TimeManager { get; private set; }

		private void Awake()
		{
			TimeManager = FindObjectOfType<TimeManager>();
		}
	}
}
