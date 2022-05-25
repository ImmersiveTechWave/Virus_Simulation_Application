namespace MF
{
	public class VirusModel
	{
		/// <summary>
		/// The name of the Virus
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// A value between 0 and 5
		/// </summary>
		public float SpreadRate { get; set; }
		/// <summary>
		/// A value between 0 and 100
		/// </summary>
		public float DeathRate { get; set; }
		/// <summary>
		/// A value between 0 and 100
		/// </summary>
		public float HospitalizationRate { get; set; }
		/// <summary>
		/// A value between 0 and 20
		/// </summary>
		public float IncubationTime { get; set; }
		public float CurrentCases { get; set; } = 0;
		public float TotalCases { get; set; } = 0;
		public float Recovered { get; set; } = 0;
		public float Deaths { get; set; } = 0;

		public VirusModel()
		{
			Name = "Name";
			SpreadRate = 0;
			DeathRate = 0;
			HospitalizationRate = 0;
			IncubationTime = 0;
		}

		public VirusModel(string name, float spreadRate, float deathRate, float hospitalizationRate, float incubationTime)
		{
			Name = name;
			SpreadRate = spreadRate;
			DeathRate = deathRate;
			HospitalizationRate = hospitalizationRate;
			IncubationTime = incubationTime;
		}
	}
}
