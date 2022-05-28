using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MF
{
	public class BuildingManager : MonoBehaviour
	{
		public List<BuildingController> JobBuildings { get; private set; } = new List<BuildingController>();
		public List<BuildingController> ShopBuildings { get; private set; } = new List<BuildingController>();
		public List<BuildingController> HomeBuildings { get; private set; } = new List<BuildingController>();
		public BuildingController HospitalBuilding { get; private set; }

		private List<BuildingController> buildings = new List<BuildingController>();

		private void Awake()
		{
			buildings = gameObject.GetComponentsInChildren<BuildingController>().ToList();
			foreach (var building in buildings)
			{
				switch (building.ActivityType)
				{
					case Activities.Slepping:
						HomeBuildings.Add(building);
						break;
					case Activities.Eating:
						ShopBuildings.Add(building);
						break;
					case Activities.Working:
						JobBuildings.Add(building);
						break;
					case Activities.Healing:
						HospitalBuilding = building;
						break;
				}
			}
		}
	}
}

