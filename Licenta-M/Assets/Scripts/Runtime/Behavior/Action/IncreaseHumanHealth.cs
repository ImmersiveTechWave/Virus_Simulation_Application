using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
	[TaskDescription("This task increase health for human.")]
	[TaskCategory("ActorModel/Increase")]
	public class IncreaseHumanHealth : BaseAction<HumanController>
	{
		private float lastTime;

		public override void OnStart()
		{
			base.OnStart();
			lastTime = Time.time;

			Actor.Model.CurrentActivity = Activities.Healing;

			if (Actor.CurrentBuilding != null && Actor.Model.CurrentActivity == Actor.CurrentBuilding.ActivityType)
			{
				Actor.MeshController.SkinnedMeshRenderer.enabled = false;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (Time.time - lastTime > 0.2f && Actor.Model.Health.Value < 98f)
			{
				Actor.Model.Health.Value += 2.0f;
				Actor.Model.Health.Value = Mathf.Clamp(Actor.Model.Health.Value, 0, 100);
				lastTime = Time.time;
			}

			//if (Actor.Model.Health.Value > 95f)
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
