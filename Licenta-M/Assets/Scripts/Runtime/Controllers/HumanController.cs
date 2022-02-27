using UnityEngine;

namespace MF
{
	[RequireComponent(typeof(HumanConfigurator))]
	public class HumanController : CustomActorController<HumanModel, HumanView, Movement, NervousSystem>
	{
		private const float DECREASE_TIME = 1f;
		private float lastTime;

		public override void Start()
		{
			lastTime = Time.time;
		}

		private void Update()
		{
			if (Time.time - lastTime > DECREASE_TIME)
			{
				lastTime = Time.time;

				if (Model.Health.Value < 1)
				{
					Model.Health.Value = 0;
				}
				else
				{
					Model.Health.Value -= MyModel.HealthDecreaseRate;
				}

				if (Model.Money.Value < 1)
				{
					Model.Money.Value = 0;
				}
				else
				{
					Model.Money.Value -= MyModel.MoneyDecreaseRate;
				}

				if (Model.Energy.Value < 1)
				{
					Model.Energy.Value = 0;
				}
				else
				{
					Model.Energy.Value -= MyModel.EnergyDecreaseRate;
				}

				if (Model.Hunger.Value < 1)
				{
					Model.Hunger.Value = 0;
				}
				else
				{
					Model.Hunger.Value -= MyModel.HungerDecreaseRate;
				}
			}
		}
	}
}
