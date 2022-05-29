using MF.UI;
using UnityEngine;

namespace MF
{
	[RequireComponent(typeof(HumanConfigurator))]
	public class HumanController : CustomActorController<HumanModel, HumanView, Movement, NervousSystem>, ISelectable
	{
		private const float DECREASE_TIME = 1f;

		private float lastTime;
		private UIMainScreenScreenController mainScreen;
		private bool lastStateValue;
		private float whenTimeWasStopped = 0f;
		private TimeManager timeManager;

		public override void Start()
		{
			mainScreen = FindObjectOfType<UIMainScreenScreenController>(true);
			timeManager = FindObjectOfType<TimeManager>();
			lastTime = Time.time;

			var random = new System.Random();
			var name = "Default";
			if (Model.Sex == Sex.M)
			{
				int index = random.Next(UtilsNames.MNames.Count);
				name = UtilsNames.MNames[index];
			}

			if (Model.Sex == Sex.F)
			{
				int index = random.Next(UtilsNames.FNames.Count);
				name = UtilsNames.FNames[index];
			}

			Model.Name = name;
			Model.Age = random.Next(18, 50);
			lastStateValue = App.IsTimeStopped;
		}

		private void Update()
		{
			if (lastStateValue != App.IsTimeStopped)
			{
				if (App.IsTimeStopped)
				{
					whenTimeWasStopped = Time.time;
				}
				else
				{
					lastTime = lastTime + Time.time - whenTimeWasStopped;
				}
				lastStateValue = App.IsTimeStopped;
			}

			if (!App.IsTimeStopped && Time.time - lastTime > DECREASE_TIME)
			{
				lastTime = Time.time;

				Model.Health.Value = Model.Health.Value < 1 ? 0 : DecreseHealth(Model.Health.Value);
				Model.Money.Value = Model.Money.Value < 1 ? 0 : DecreseMoney(Model.Money.Value);
				Model.Energy.Value = Model.Energy.Value < 1 ? 0 : DecreseEnergy(Model.Energy.Value);
				Model.Hunger.Value = Model.Hunger.Value < 1 ? 0 : DecreseHunger(Model.Hunger.Value);
			}
		}

		public float DecreseEnergy(float modelEnergyValue)
		{
			var decreseEnergyValue = 1f;

			switch (Model.CurrentActivity)
			{
				case Activities.Working:
					decreseEnergyValue *= 3f;   // because human spends more time for doing work
					break;
				case Activities.Eating:
					decreseEnergyValue *= 0.5f;      // because human eats
					break;
				case Activities.Slepping:
					decreseEnergyValue *= 0f;      // because human does`t lose energy when he sleeps
					break;
				case Activities.Moving:
					decreseEnergyValue *= 2f;      // because human moves
					break;
				default:
					decreseEnergyValue *= 1f;
					break;
			}

			modelEnergyValue = modelEnergyValue - decreseEnergyValue;
			return Mathf.Clamp(modelEnergyValue, 0, 100);
		}

		public float DecreseHunger(float modelHungerValue)
		{
			var decreseHungerValue = 1f;

			switch (Model.CurrentActivity)
			{
				case Activities.Working:
					decreseHungerValue *= 4f;      // because human spends more time for doing something and lose more calories
					break;
				case Activities.Eating:
					decreseHungerValue *= 0f;      // because human eats
					break;
				case Activities.Slepping:
					decreseHungerValue *= 0.5f;      // because human sleeps and he consumes some calories
					break;
				case Activities.Moving:
					decreseHungerValue *= 1.5f;      // because human moves  he consume calories
					break;
				default:
					decreseHungerValue *= 1f;
					break;
			}

			modelHungerValue = modelHungerValue - decreseHungerValue;
			return Mathf.Clamp(modelHungerValue, 0, 100);
		}

		public float DecreseMoney(float modelMoneyValue)
		{
			var decreseMoneyValue = 1f;

			switch (Model.CurrentActivity)
			{
				case Activities.Working:
					decreseMoneyValue *= 0f;      // because human earns money, doesn`t lose
					break;
				case Activities.Eating:
					decreseMoneyValue *= 5f;      // because human eats
					break;
				case Activities.Slepping:
					decreseMoneyValue *= 0f;      // because human sleeps
					break;
				case Activities.Moving:
					decreseMoneyValue *= 0.5f;      // because human moves 
					break;
				default:
					decreseMoneyValue *= 1f;
					break;
			}

			modelMoneyValue = modelMoneyValue - decreseMoneyValue;
			return Mathf.Clamp(modelMoneyValue, 0, 100);
		}

		public float DecreseHealth(float modelHealthValue)
		{
			var decreseHealthValue = 0f;

			modelHealthValue = modelHealthValue - decreseHealthValue;
			return modelHealthValue;
		}

		public void Select()
		{
			mainScreen.HumanWasSelected();
		}

		public void Deselect()
		{
			mainScreen.CloseHumanInfoPanel();
		}

		private void OnTriggerEnter(Collider other)
		{
			var human = other.GetComponent<HumanController>();
			if (human != null)
			{
				if (MyModel.IsInfected && !human.MyModel.IsInfected)
				{
					human.MyModel.IsInfected = true;
					human.MyModel.InfectedDay = timeManager.TimeModel.Day;
					App.CurrentVirus.TotalCases += 1f;
				}
			}
		}
	}
}
