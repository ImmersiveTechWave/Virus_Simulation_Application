using UnityEngine;

namespace MF.UI
{
    public class MFScreen : MonoBehaviour
	{
		public ScreenManager ScreenManager { get; set; }

		virtual public void Awake()
		{
			ScreenManager = FindObjectOfType<ScreenManager>();
		}
	}
}
