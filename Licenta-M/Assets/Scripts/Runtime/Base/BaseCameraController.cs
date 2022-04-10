using UnityEngine;

namespace MF
{
	public class BaseCameraController : MonoBehaviour
	{
		public Camera BaseCamera { get; private set; }
		public bool ThisIsTheMainCamera;

		private void Start()
		{
			BaseCamera = GetComponent<Camera>();
		}

		public virtual void EnterState()
		{
			ThisIsTheMainCamera = true;
			BaseCamera.enabled = true;
		}

		public virtual void ExitState()
		{
			ThisIsTheMainCamera = false;
			BaseCamera.enabled = false;
		}
	}
}
