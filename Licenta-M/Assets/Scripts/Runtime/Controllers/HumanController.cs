using UnityEngine;

namespace MF
{
	[RequireComponent(typeof(HumanConfigurator))]
	public class HumanController : CustomActorController<HumanModel, HumanView, Movement, NervousSystem>
	{
		private const float DECREASE_TIME = 2f;
		private float lastTime;

		private void Start()
		{
			lastTime = Time.time;
		}

		private void Update()
		{
			if (Time.time - lastTime > DECREASE_TIME)
			{
				lastTime = Time.time;
				Model.Health.Value -= MyModel.HealthDecreaseRate;
				Model.Money.Value -= MyModel.MoneyDecreaseRate;
				Model.Energy.Value -= MyModel.RestDecreaseRate;
				Model.Hunger.Value -= MyModel.HungerDecreaseRate;
			}

		}
	}
}
