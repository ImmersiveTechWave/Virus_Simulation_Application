using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
	public class GoToPoint : BaseAction<ActorController>
	{
		public SharedGameObject GameObjectTargetPosition;
		public SharedTransform TransformTargetPosition;
		public SharedVector3 VectorTargetPosition;
		public bool UsePositionFromGameObject = false;
		public bool UsePositionFromTransform = false;
		public bool UsePositionFromVector = false;

		private Vector3 position;

		public override void OnStart()
		{
			base.OnStart();
			if (UsePositionFromGameObject == true)
			{
				position = GameObjectTargetPosition.Value.transform.position;
			}
			else if (UsePositionFromTransform == true)
			{
				position = TransformTargetPosition.Value.position;
			}
			else if (UsePositionFromVector == true)
			{
				position = VectorTargetPosition.Value;
			}
			else
			{
				position = Actor.transform.position;
			}

			Actor.Movement.AiDestination = position;
			Actor.Model.CurrentActivity = Activities.Moving;
		}

		public override TaskStatus OnUpdate()
		{
			Actor.Movement.AiDestination = position;
			if (!Actor.Movement.HasAiReachedDestination)
			{
				return TaskStatus.Running;
			}
			return TaskStatus.Success;
		}
	}
}
