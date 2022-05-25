using UnityEngine;

namespace MF
{
	public class InputManager : MonoBehaviour
	{
		private void Update()
		{
			SelectHuman();
		}

		private void SelectHuman()
		{
			if (Input.GetMouseButtonDown(0))
			{
				var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out var rayHit, Mathf.Infinity, LayerMask.GetMask(LayersName.HUMAN)))
				{
					var selectable = rayHit.collider.gameObject.GetComponentInParent<ISelectable>();
					if (selectable != null)
					{
						var human = rayHit.collider.gameObject.GetComponentInParent<HumanController>();
						if (human != null)
						{
							App.SelectedHumanController?.Deselect();
							App.SelectedHumanController = human;
							App.SelectedHumanController.Select();
						}
					}
				}
			}
		}
	}
}
