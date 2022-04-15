using System.Collections.Generic;
using UnityEngine;

namespace MF
{
	public enum Activities
	{
		IsWorking,
		IsEating,
		IsSlepping,
		IsHealing,
		IsMoving,
		IsStaying
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

		public Activities CurrentActivity = Activities.IsStaying;

		public GameObject HomePosition;

		public GameObject HospitalPosition;

		public GameObject MarketPosition;

		public GameObject JobPosition;

		/// <summary>
		/// The actor's current velocity
		/// </summary>
		public Vector3 CurrentVelocity { get; set; }
	}
}
