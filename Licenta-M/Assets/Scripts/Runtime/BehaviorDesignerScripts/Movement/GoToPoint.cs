using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
	public class GoToPoint : BaseAction<ActorController>
	{
		[RequiredField] public GameObject TargetPosition;

		public override void OnStart()
		{
			base.OnStart();
			Actor.Movement.AiDestination = TargetPosition.transform.position;
		}

		public override TaskStatus OnUpdate()
		{
			Actor.Movement.AiDestination = TargetPosition.transform.position;
			if (!Actor.Movement.HasAiReachedDestination)
			{
				return TaskStatus.Running;
			}
			return TaskStatus.Success;
		}
	}
}
