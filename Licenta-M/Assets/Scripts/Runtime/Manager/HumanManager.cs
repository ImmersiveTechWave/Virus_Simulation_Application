using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MF
{
	public class HumanManager : MonoBehaviour
	{
		private List<HumanController> humans = new List<HumanController>();
		private BuildingManager buildingManager;

		private void Start()
		{
			var random = new System.Random();
			buildingManager = FindObjectOfType<BuildingManager>();
			humans = gameObject.GetComponentsInChildren<HumanController>().ToList();
			humans[random.Next(humans.Count)].MyModel.IsInfected = true;
			foreach (var human in humans)
			{
				human.Model.HospitalPosition = buildingManager.HospitalBuilding;
				human.Model.HomePosition = buildingManager.HomeBuildings[random.Next(buildingManager.HomeBuildings.Count)];
				human.Model.ShopPosition = buildingManager.ShopBuildings[random.Next(buildingManager.ShopBuildings.Count)];
				human.Model.JobPosition = buildingManager.JobBuildings[random.Next(buildingManager.JobBuildings.Count)];
			}
		}
	}
}
