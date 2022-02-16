using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
	public class GoToPoint : BaseAction<ActorController>
	{
		[RequiredField] public SharedGameObject TargetPosition;

		public override void OnStart()
		{
			base.OnStart();
			Actor.Movement.AiDestination = TargetPosition.Value.transform.position;
		}

		public override TaskStatus OnUpdate()
		{
			Actor.Movement.AiDestination = TargetPosition.Value.transform.position;
			if (!Actor.Movement.HasAiReachedDestination)
			{
				return TaskStatus.Running;
			}
			return TaskStatus.Success;
		}
	}
}
