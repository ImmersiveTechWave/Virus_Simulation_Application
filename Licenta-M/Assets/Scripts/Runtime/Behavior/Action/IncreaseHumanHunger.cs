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
		}

		public override TaskStatus OnUpdate()
		{
			if (Time.time - lastTime > 0.2f && Actor.Model.Hunger.Value < 98f)
			{
				Actor.Model.Hunger.Value += 2.0f;
				lastTime = Time.time;
			}

			if (Actor.Model.Hunger.Value > 95f)
			{
				return TaskStatus.Success;
			}

			return TaskStatus.Running;
		}
	}
}
