using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF
{
	[TaskDescription("This task increase energy for human.")]
	[TaskCategory("ActorModel/Increase")]
	public class IncreaseHumanEnergy : BaseAction<HumanController>
	{
		private float lastTime;

		public override void OnStart()
		{
			base.OnStart();
			lastTime = Time.time;
			Actor.Model.CurrentActivity = Activities.Slepping;
		}

		public override TaskStatus OnUpdate()
		{
			if (Time.time - lastTime > 0.2f && Actor.Model.Energy.Value < 98f)
			{
				Actor.Model.Energy.Value += 2.0f;
				lastTime = Time.time;
			}

			if (Actor.Model.Energy.Value > 95f)
			{
				return TaskStatus.Success;
			}
		
			return TaskStatus.Running;
		}
	}
}
