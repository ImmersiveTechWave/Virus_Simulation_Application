using System.Collections.Generic;
using UnityEngine;

namespace MF
{
	public enum Activities
	{
		Working,
		Eating,
		Slepping,
		Healing,
		Moving,
		Staying
	};

	public class ActorModel
	{
		public string Guid;

		public Observable<float> Health = new Observable<float>();

		public Observable<float> Energy = new Observable<float>();

		public Observable<float> Hunger = new Observable<float>();

		public Observable<float> Money = new Observable<float>();

		public Observable<float> MovementSpeed = new Observable<float>();

		public Observable<float> WalkSpeed = new Observable<float>();

		public Observable<float> RunSpeed = new Observable<float>();

		public List<GameObject> WanderPoints = new List<GameObject>();

		public Activities CurrentActivity = Activities.Staying;

		public TimeModel StartTimeModelToWork;

		public TimeModel EndTimeModelToWork;

		public TimeModel StartTimeModelToSleep;

		public TimeModel EndTimeModelToSleep;

		public BuildingController HomePosition;

		public BuildingController HospitalPosition;

		public BuildingController MarketPosition;

		public BuildingController JobLocation;

		/// <summary>
		/// The actor's current velocity
		/// </summary>
		public Vector3 CurrentVelocity { get; set; }
	}
}
