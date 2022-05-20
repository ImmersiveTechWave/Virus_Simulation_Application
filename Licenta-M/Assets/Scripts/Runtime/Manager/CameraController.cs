using UnityEngine;

namespace MF
{
	public class CameraController : MonoBehaviour
	{
		private const float CAMERA_MOVEMENT = 20f;
		private const float CAMERA_ROTATION = 100f;

		private bool mouseIsDown;
		private Vector3 startMousePosition = Vector3.zero;

		private void Update()
		{
			ConsumeUserMovementInput();
			ConsumeUserRotationInput();
		}

		private void ConsumeUserMovementInput()
		{
			if (Input.GetKey(KeyCode.W))
			{
				transform.position += transform.forward * CAMERA_MOVEMENT * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.S))
			{
				transform.position += -transform.forward * CAMERA_MOVEMENT * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.D))
			{
				transform.position += transform.right * CAMERA_MOVEMENT * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.A))
			{
				transform.position += -transform.right * CAMERA_MOVEMENT * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.Q))
			{
				transform.position += Vector3.up * CAMERA_MOVEMENT * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.E))
			{
				transform.position += -Vector3.up * CAMERA_MOVEMENT * Time.deltaTime;
			}
		}

		private void ConsumeUserRotationInput()
		{
			if (Input.GetMouseButtonDown(1))
			{
				mouseIsDown = true;
				startMousePosition = Input.mousePosition;
			}

			if (Input.GetMouseButton(1) && mouseIsDown)
			{
				var difference = Input.mousePosition - startMousePosition;
				var offset = new Vector2(difference.x / Screen.width, difference.y / Screen.height) * CAMERA_ROTATION * Time.deltaTime;
				transform.Rotate(0.0f, offset.x, 0.0f, Space.World);
				transform.Rotate(offset.y, 0.0f, 0.0f, Space.Self);
			}

			if (Input.GetMouseButtonUp(1))
			{
				mouseIsDown = false;
			}
		}
	}
}

