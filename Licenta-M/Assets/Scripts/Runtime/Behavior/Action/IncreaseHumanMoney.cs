using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
	[TaskDescription("This task increase money for human.")]
	[TaskCategory("ActorModel/Increase")]
	public class IncreaseHumanMoney : BaseAction<HumanController>
	{
		private float lastTime;
		private int startTimeInMinutes = 0;
		private int endTimeInMinutes = 0;

		public override void OnStart()
		{
			base.OnStart();

			startTimeInMinutes = Actor.Model.StartTimeModelToWork.Hours * 60 + Actor.Model.StartTimeModelToWork.Minutes;
			endTimeInMinutes = Actor.Model.EndTimeModelToWork.Hours * 60 + Actor.Model.EndTimeModelToWork.Minutes;

			lastTime = Time.time;

			Actor.Model.CurrentActivity = Activities.Working;
			if (Actor.CurrentBuilding != null && Actor.Model.CurrentActivity == Actor.CurrentBuilding.ActivityType)
			{
				Actor.MeshController.SkinnedMeshRenderer.enabled = false;
				Actor.MyView.VirusSprite.gameObject.SetActive(false);
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (Time.time - lastTime > 0.2f)
			{
				Actor.Model.Money.Value += 2.0f;
				Actor.Model.Money.Value = Mathf.Clamp(Actor.Model.Money.Value, 0, 100);
				lastTime = Time.time;
			}

			var currentTimeInMinutes = App.TimeManager.TimeModel.Hours * 60 + App.TimeManager.TimeModel.Minutes;
			if (startTimeInMinutes > currentTimeInMinutes || endTimeInMinutes < currentTimeInMinutes)
			{
				return TaskStatus.Success;
			}

			return TaskStatus.Running;
		}

		public override void OnEnd()
		{
			base.OnEnd();
			Actor.MeshController.SkinnedMeshRenderer.enabled = true;
			Actor.MyView.VirusSprite.gameObject.SetActive(Actor.MyModel.IsInfected);
		}
	}
}
