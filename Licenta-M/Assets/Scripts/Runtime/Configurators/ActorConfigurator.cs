using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MF
{
	[Serializable]
	public struct TimaData
	{
		public int Hour;
		public int Minute;

		public TimaData(int hour, int minute)
		{
			Hour = hour;
			Minute = minute;
		}
	};

	/// <summary>
	/// Container class for all actor edit-mode configuration.  Modifying any of the values in this class in play-mode
	/// should not have any effect on the game.
	/// <para>This class is needed because many things we want to configure are part of the actor model, which cannot be 
	/// initialized at edit-time. This serves as a contained compromise that lets us (minimally) configure actors before 
	/// hitting play.</para>
	/// </summary>
	public class ActorConfigurator : MonoBehaviour
	{
		[Header("Core setup")]
		public string UniqueIdentifier = Guid.NewGuid().ToString();

		[Header("Sex")]
		public Sex Sex = Sex.M;

		[Header("Stats")]
		[Range(0f, 100f)] public float Health = 100f;
		[Range(0f, 100f)] public float Energy = 100f;
		[Range(0f, 100f)] public float Hunger = 100f;
		[Range(0f, 100f)] public float Money = 100f;

		[Header("Movement")]
		public float MovementSpeed = 2f;
		public float WalkSpeed = 2f;
		public float RunSpeed = 4f;
		public GameObject WanderPointsHolder;

		//[Header("Position To Go")]
		//public BuildingController HomePosition;
		//public BuildingController HospitalPosition;
		//public BuildingController MarketPosition;
		//public BuildingController JobLocation;

		//[Header("Work Hours")]
		//public TimaData startHoursToWork;
		//public TimaData endHoursToWork;

		//[Header("Sleep Hours")]
		//public TimaData startHoursToSleep;
		//public TimaData endHoursToSleep;


		public virtual void Configure(ActorModel model)
		{
			model.Guid = GetOrInitializeUniqueIdentifier();
			model.Health.Value = Health;
			model.Energy.Value = Energy;
			model.Hunger.Value = Hunger;
			model.Money.Value = Money;

			model.MovementSpeed.Value = MovementSpeed;
			model.WalkSpeed.Value = WalkSpeed;
			model.RunSpeed.Value = RunSpeed;
			var wanderPointsList = new List<GameObject>();
			if (WanderPointsHolder != null)
			{
				var points = WanderPointsHolder.GetComponentsInChildren<Transform>().ToList();
				foreach (var point in points)
				{
					wanderPointsList.Add(point.gameObject);
				}
			}
			model.WanderPoints = wanderPointsList;

			//model.HomePosition = HomePosition;
			//model.HospitalPosition = HospitalPosition;
			//model.ShopPosition = MarketPosition;
			//model.JobPosition = JobLocation;

			var random = new System.Random();
			var startHourToWork = random.Next(2) + 8;
			var startMinuteToWork = random.Next(60);
			var endHourToWork = random.Next(4) + 14;
			var endMinuteToWork = random.Next(60);

			var startHourToSleep = random.Next(2) + 21;
			var startMinuteToSleep = random.Next(60);
			var endHourToSleep = random.Next(2) + 6;
			var endMinuteToSleep = random.Next(60);
			model.StartTimeModelToWork = new TimeModel(startHourToWork, startMinuteToWork, 0);
			model.EndTimeModelToWork = new TimeModel(endHourToWork, endMinuteToWork, 0);

			model.StartTimeModelToSleep = new TimeModel(startHourToSleep, startMinuteToSleep, 0);
			model.EndTimeModelToSleep = new TimeModel(endHourToSleep, endMinuteToSleep, 0);
			model.Sex = Sex;
		}

		private string GetOrInitializeUniqueIdentifier()
		{
			UniqueIdentifier = string.IsNullOrEmpty(UniqueIdentifier) ? Guid.NewGuid().ToString() : UniqueIdentifier;

			return UniqueIdentifier;
		}
	}
}
