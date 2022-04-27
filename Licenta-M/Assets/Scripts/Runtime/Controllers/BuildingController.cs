using System.Collections.Generic;
using UnityEngine;

namespace MF
{
	public class BuildingController : MonoBehaviour
	{
		public Activities ActivityType;

		private List<Vector3> Positions = new List<Vector3>();

		private void Awake()
		{
			GetAllPositions();
		}

		private void GetAllPositions()
		{
			var positions = transform.Find("Positions");
			foreach (Transform position in positions)
			{
				Positions.Add(position.position);
			}
		}

		public Vector3 GetRandomPosition()
		{
			var count = Positions.Count;
			if (count != 0)
			{
				var random = new System.Random();
				return Positions[random.Next(count)];
			}
			return transform.position;
		}

		private void OnTriggerEnter(Collider other)
		{
			var actor = other.GetComponent<ActorController>();

			if (actor != null)
			{
				actor.CurrentBuilding = this;
			}
		}
	}
}
