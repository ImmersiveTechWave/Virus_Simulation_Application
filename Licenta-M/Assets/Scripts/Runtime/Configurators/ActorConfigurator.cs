using System;
using System.Collections.Generic;
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

		[Header("Stats")]
		[Range(0f, 100f)] public float Health = 100f;
		[Range(0f, 100f)] public float Energy = 100f;
		[Range(0f, 100f)] public float Hunger = 100f;
		[Range(0f, 100f)] public float Money = 100f;


		[Header("Movement")]
		public float MovementSpeed = 2f;
		public float WalkSpeed = 2f;
		public float RunSpeed = 4f;
		public List<GameObject> WanderPoints = new List<GameObject>();

		[Header("Position To Go")]
		public GameObject HomePosition;
		public GameObject HospitalPosition;
		public GameObject MarketPosition;
		public GameObject JobPosition;

		[Header("Work Hours")]
		public TimaData startHoursToWork;
		public TimaData endHoursToWork;

		[Header("Sleep Hours")]
		public TimaData startHoursToSleep;
		public TimaData endHoursToSleep;

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
			model.WanderPoints = WanderPoints;

			model.HomePosition = HomePosition;
			model.HospitalPosition = HospitalPosition;
			model.MarketPosition = MarketPosition;
			model.JobPosition = JobPosition;

			model.StartTimeModelToWork = new TimeModel(startHoursToWork.Hour, startHoursToWork.Minute, 0);
			model.EndTimeModelToWork = new TimeModel(endHoursToWork.Hour, endHoursToWork.Minute, 0);

			model.StartTimeModelToSleep = new TimeModel(startHoursToSleep.Hour, startHoursToSleep.Minute, 0);
			model.EndTimeModelToSleep = new TimeModel(endHoursToSleep.Hour, endHoursToSleep.Minute, 0);
		}

		private string GetOrInitializeUniqueIdentifier()
		{
			UniqueIdentifier = string.IsNullOrEmpty(UniqueIdentifier) ? Guid.NewGuid().ToString() : UniqueIdentifier;

			return UniqueIdentifier;
		}
	}
}
