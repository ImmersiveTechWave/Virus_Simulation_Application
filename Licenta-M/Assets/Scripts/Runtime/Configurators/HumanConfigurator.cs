using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF
{
	public class HumanConfigurator : ActorConfigurator
	{
		[Header("Stats Decrease")]
		public float HungerDecreaseRate = 0.5f;
		public float MoneyDecreaseRate = 0.1f;
		public float HealthDecreaseRate = 0.05f;
		public float RestDecreaseRate = 0.5f;

		public override void Configure(ActorModel model)
		{
			base.Configure(model);
			var humanModel = (HumanModel)model;
			humanModel.HungerDecreaseRate = HungerDecreaseRate;
			humanModel.MoneyDecreaseRate = MoneyDecreaseRate;
			humanModel.HealthDecreaseRate = HealthDecreaseRate;
			humanModel.RestDecreaseRate = RestDecreaseRate;
		}
	}
}
