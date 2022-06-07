using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MF
{
	public class HumanManager : MonoBehaviour
	{
		public static readonly float NUMBER_INFECTED_PEOPLE = 6;

		private List<HumanController> humans = new List<HumanController>();
		private BuildingManager buildingManager;

		private void Start()
		{
			var random = new System.Random();
			buildingManager = FindObjectOfType<BuildingManager>();
			humans = gameObject.GetComponentsInChildren<HumanController>().ToList();
			for (int i = 0; i < NUMBER_INFECTED_PEOPLE; i++)
			{
				var randomHuman = random.Next(humans.Count);
				humans[randomHuman].MyModel.IsInfected = true;
				humans[randomHuman].MyView.VirusSprite.gameObject.SetActive(true);
			}
			foreach (var human in humans)
			{
				human.Model.HospitalPosition = buildingManager.HospitalBuilding;
				human.Model.HomePosition = buildingManager.HomeBuildings[random.Next(buildingManager.HomeBuildings.Count)];
				human.Model.ShopPosition = buildingManager.ShopBuildings[random.Next(buildingManager.ShopBuildings.Count)];
				human.Model.JobPosition = buildingManager.JobBuildings[random.Next(buildingManager.JobBuildings.Count)];
			}
		}

		public void SetHumansQuarantine(bool state)
		{
			var numberOfPeople = (int)(humans.Count * 0.85);
			for (int i = 0; i < numberOfPeople; i++)
			{
				humans[i].MyModel.IsInQuarantine = state;
			}
		}
	}
}
