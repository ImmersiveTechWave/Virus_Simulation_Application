using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
	[TaskDescription("This task increase hunger for human.")]
	[TaskCategory("ActorModel/Increase")]
	public class IncreaseHumanHunger : BaseAction<HumanController>
	{
		private float lastTime;

		public override void OnStart()
		{
			base.OnStart();
			lastTime = Time.time;

			Actor.Model.CurrentActivity = Activities.Eating;

			if (Actor.CurrentBuilding != null && Actor.Model.CurrentActivity == Actor.CurrentBuilding.ActivityType)
			{
				Actor.MeshController.SkinnedMeshRenderer.enabled = false;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (Time.time - lastTime > 0.2f && Actor.Model.Hunger.Value < 98f)
			{
				Actor.Model.Hunger.Value += 2.0f;
				Actor.Model.Hunger.Value = Mathf.Clamp(Actor.Model.Hunger.Value, 0, 100);
				lastTime = Time.time;
			}

			if (Actor.Model.Hunger.Value > 95f)
			{
				return TaskStatus.Success;
			}

			return TaskStatus.Running;
		}

		public override void OnEnd()
		{
			base.OnEnd();
			Actor.MeshController.SkinnedMeshRenderer.enabled = true;
		}
	}
}
