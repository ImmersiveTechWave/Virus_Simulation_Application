using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF
{
	public class CameraManager : MonoBehaviour
	{
		private const string CAMERA_NAME = "Camera";

		public CameraController Camera { get; private set; }

		private void Awake()
		{
			Camera = transform.Find(CAMERA_NAME).GetComponent<CameraController>();
		}

		private void Start()
		{
			ChangeToTopViewCamera();
		}

		public void ChangeToTopViewCamera()
		{ 
			Camera.EnterState();
		}

		public void ChangeToFreeRoamCamera()
		{
			Camera.ExitState();
		}
	}
}
