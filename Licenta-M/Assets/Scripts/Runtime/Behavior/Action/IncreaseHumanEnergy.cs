using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
	[TaskDescription("This task increase energy for human.")]
	[TaskCategory("ActorModel/Increase")]
	public class IncreaseHumanEnergy : BaseAction<HumanController>
	{
		private float lastTime;
		private int startTimeInMinutes = 0;
		private int endTimeInMinutes = 0;
		private int endTimeOffset = 0;

		public override void OnStart()
		{
			base.OnStart();
			lastTime = Time.time;

			if (Actor.Model.EndTimeModelToSleep.Hours < Actor.Model.StartTimeModelToSleep.Hours)
			{
				endTimeOffset = 24;
			}

			startTimeInMinutes = Actor.Model.StartTimeModelToSleep.Hours * 60 + Actor.Model.StartTimeModelToSleep.Minutes;
			endTimeInMinutes = (Actor.Model.EndTimeModelToSleep.Hours + endTimeOffset) * 60 + Actor.Model.EndTimeModelToSleep.Minutes;

			Actor.Model.CurrentActivity = Activities.Slepping;
			if (Actor.CurrentBuilding != null && Actor.Model.CurrentActivity == Actor.CurrentBuilding.ActivityType)
			{
				Actor.MeshController.SkinnedMeshRenderer.enabled = false;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (Time.time - lastTime > 0.2f && Actor.Model.Energy.Value < 98f)
			{
				Actor.Model.Energy.Value += 2.0f;
				Actor.Model.Energy.Value = Mathf.Clamp(Actor.Model.Energy.Value, 0, 100);
				lastTime = Time.time;
			}

			var currentTimeInMinutes = (App.TimeManager.TimeModel.Hours + endTimeOffset) * 60 + App.TimeManager.TimeModel.Minutes;
			//if (startTimeInMinutes > currentTimeInMinutes || endTimeInMinutes < currentTimeInMinutes)
			//{
			//	return TaskStatus.Success;
			//}

			return TaskStatus.Running;
		}

		public override void OnEnd()
		{
			base.OnEnd();
			Actor.MeshController.SkinnedMeshRenderer.enabled = true;
		}
	}
}
