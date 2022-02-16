using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

namespace MF
{
	public class WanderPoints : BaseAction<ActorController>
	{
		private Random random;
		private bool hasPoints;

		public override void OnAwake()
		{
			base.OnAwake();
			random = new Random();
		}

		public override void OnStart()
		{
			base.OnStart();
			var count = Actor.Model.WanderPoints.Count;
			hasPoints = count == 0 ? false : true;

			if (hasPoints)
			{
				var index = random.Next(0, count);
				Actor.Movement.AiDestination = Actor.Model.WanderPoints[index].transform.position;
			}
		}

		public override TaskStatus OnUpdate()
		{
			if (!hasPoints)
			{
				return TaskStatus.Failure;
			}
			if (!Actor.Movement.HasAiReachedDestination)
			{
				return TaskStatus.Running;
			}
			return TaskStatus.Success;
		}
	}
}
