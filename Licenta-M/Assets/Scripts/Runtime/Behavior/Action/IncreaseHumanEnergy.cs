using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF
{
	public class IncreaseHumanEnergy : BaseAction<HumanController>
	{
		private float lastTime;

		public override void OnStart()
		{
			base.OnStart();
			lastTime = Time.time;
		}

		public override TaskStatus OnUpdate()
		{
			if (Time.time - lastTime > 0.2f && Actor.Model.Energy.Value < 98f)
			{
				Actor.Model.Energy.Value += 2.0f;
				lastTime = Time.time;
			}
			return TaskStatus.Running;
		}
	}
}
