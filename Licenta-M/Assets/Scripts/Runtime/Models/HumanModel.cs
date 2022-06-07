namespace MF
{
	public class HumanModel : ActorModel
	{
		public float HungerDecreaseRate { get; set; }
		public float MoneyDecreaseRate { get; set; }
		public float HealthDecreaseRate { get; set; }
		public float EnergyDecreaseRate { get; set; }

		public bool IsInfected { get; set; }
		public bool IsSevere { get; set; }
		public float InfectedDay { get; set; }
		public bool IsInQuarantine { get; set; }
	}
}
