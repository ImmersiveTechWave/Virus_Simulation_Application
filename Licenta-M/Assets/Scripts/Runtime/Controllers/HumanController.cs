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
					Model.Health.Value = DecreseHealth(Model.Health.Value);
				}

				if (Model.Money.Value < 1)
				{
					Model.Money.Value = 0;
				}
				else
				{
					Model.Money.Value = DecreseMoney(Model.Money.Value);
				}

				if (Model.Energy.Value < 1)
				{
					Model.Energy.Value = 0;
				}
				else
				{
					Model.Energy.Value = DecreseEnergy(Model.Energy.Value);
				}

				if (Model.Hunger.Value < 1)
				{
					Model.Hunger.Value = 0;
				}
				else
				{
					Model.Hunger.Value = DecreseHunger(Model.Hunger.Value);
				}
			}
		}

		public float DecreseEnergy(float modelEnergyValue)
		{
			var decreseEnergy = 1f;

			if (Model.CurrentActivity == Activities.IsWorking)
			{
				decreseEnergy *= 3f;      // because human spends more time for doing work
			}

			if (Model.CurrentActivity == Activities.IsEating)
			{
				decreseEnergy *= 0.5f;      // because human eats
			}

			if (Model.CurrentActivity == Activities.IsSlepping)
			{
				decreseEnergy *= 0f;      // because human does`t lose energy when he sleeps
			}

			if (Model.CurrentActivity == Activities.IsMoving)
			{
				decreseEnergy *= 2f;      // because human moves
			}

			Debug.Log("Decrese energy ----------" + decreseEnergy);
			modelEnergyValue = modelEnergyValue - decreseEnergy;
			return modelEnergyValue;
		}

		public float DecreseHunger(float modelHungerValue)
		{
			var decreseHunger = 1f;

			if (Model.CurrentActivity == Activities.IsWorking)
			{
				decreseHunger *= 4f;      // because human spends more time for doing something and lose more calories
			}

			if (Model.CurrentActivity == Activities.IsEating)
			{
				decreseHunger *= 0f;      // because human eats
			}

			if (Model.CurrentActivity == Activities.IsSlepping)
			{
				decreseHunger *= 0.5f;      // because human sleeps and he consumes some calories
			}

			if (Model.CurrentActivity == Activities.IsMoving)
			{
				decreseHunger *= 1.5f;      // because human moves  he consume calories
			}

			Debug.Log("Decrese hunger ----------" + decreseHunger);
			modelHungerValue = modelHungerValue - decreseHunger;
			return modelHungerValue;
		}

		public float DecreseMoney(float modelMoneyValue)
		{
			var decreseMoney = 1f;

			if (Model.CurrentActivity == Activities.IsWorking)
			{
				decreseMoney *= 0f;      // because human earns money, doesn`t lose
			}

			if (Model.CurrentActivity == Activities.IsEating)
			{
				decreseMoney *= 5f;      // because human eats
			}

			if (Model.CurrentActivity == Activities.IsSlepping)
			{
				decreseMoney *= 0f;      // because human sleeps
			}

			if (Model.CurrentActivity == Activities.IsMoving)
			{
				decreseMoney *= 0.5f;      // because human moves 
			}

			Debug.Log("Decrese money ----------" + decreseMoney);
			modelMoneyValue = modelMoneyValue - decreseMoney;
			return modelMoneyValue;
		}

		public float DecreseHealth(float modelHealthValue)
		{
			var decreseHealth = 0f;

			modelHealthValue = modelHealthValue - decreseHealth;
			return modelHealthValue;
		}
	}
}
