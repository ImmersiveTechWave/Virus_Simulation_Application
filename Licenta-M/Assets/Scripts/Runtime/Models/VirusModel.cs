namespace MF
{
    public class VirusModel 
    {
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
    }
}
