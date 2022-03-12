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
		}

		public override TaskStatus OnUpdate()
		{
			if (Time.time - lastTime > 0.2f && Actor.Model.Health.Value < 98f)
			{
				Actor.Model.Health.Value += 2.0f;
				lastTime = Time.time;
			}
			if (Actor.Model.Health.Value > 99f)
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}
	}
}
