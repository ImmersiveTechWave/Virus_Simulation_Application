using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;
using UnityEngine;

namespace MF
{
	[TaskDescription("This task calculated the score for human energy in every moment.")]
	[TaskCategory("Score/Human")]
	public class CalculateEnergyScore : BaseAction<HumanController>
	{
		[RequiredField] public SharedFloat EnergyScore;

		private int startTimeInMinutes = 0;
		private int endTimeInMinutes = 0;
		private int endTimeOffset = 0;

		public override void OnStart()
		{
			base.OnStart();

			if (Actor.Model.EndTimeModelToSleep.Hours < Actor.Model.StartTimeModelToSleep.Hours)
			{
				endTimeOffset = 24;
			}
			startTimeInMinutes = Actor.Model.StartTimeModelToSleep.Hours * 60 + Actor.Model.StartTimeModelToSleep.Minutes;
			endTimeInMinutes = (Actor.Model.EndTimeModelToSleep.Hours + endTimeOffset) * 60 + Actor.Model.EndTimeModelToSleep.Minutes;
		}

		public override TaskStatus OnUpdate()
		{
			try
			{

				EnergyScore.Value = Scores.EnergyScore[(int)Actor.Model.Energy.Value];
			}
			catch (Exception ex)
			{
				Debug.Log(Actor.name + " --- " + (int)Actor.Model.Energy.Value);
			}

			var currentTimeInMinutes = (App.TimeManager.TimeModel.Hours + endTimeOffset) * 60 + App.TimeManager.TimeModel.Minutes;
			if (startTimeInMinutes < currentTimeInMinutes && endTimeInMinutes > currentTimeInMinutes)
			{
				EnergyScore.Value = 0.8f;
			}

			return TaskStatus.Running;
		}
	}
}
