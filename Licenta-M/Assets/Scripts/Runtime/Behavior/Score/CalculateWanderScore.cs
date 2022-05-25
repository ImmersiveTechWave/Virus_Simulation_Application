using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MF
{
	[TaskCategory("Score/Human")]
	public class CalculateWanderScore : BaseAction<HumanController>
	{
		[RequiredField] public SharedFloat WanderScore;
		[RequiredField] public SharedFloat MoneyScore;
		[RequiredField] public SharedFloat EnergyScore;
		[RequiredField] public SharedFloat HungerScore;

		public override TaskStatus OnUpdate()
		{
			WanderScore.Value = 0f;

			if (MoneyScore.Value < 0.3f && EnergyScore.Value < 0.2f && HungerScore.Value < 0.3f)
			{
				WanderScore.Value = 0.35f;
			}
			return TaskStatus.Running;
		}
	}
}
