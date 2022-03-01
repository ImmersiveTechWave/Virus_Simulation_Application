using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
	[TaskDescription("This task increase money for human.")]
	[TaskCategory("ActorModel/Increase")]
	public class IncreaseHumanMoney : BaseAction<HumanController>
	{
		private float lastTime;

		public override void OnStart()
		{
			base.OnStart();
			lastTime = Time.time;
		}

		public override TaskStatus OnUpdate()
		{
			if (Time.time - lastTime > 0.2f && Actor.Model.Money.Value < 98f)
			{
				Actor.Model.Money.Value += 2.0f;
				lastTime = Time.time;
			}
			return TaskStatus.Running;
		}
	}
}
