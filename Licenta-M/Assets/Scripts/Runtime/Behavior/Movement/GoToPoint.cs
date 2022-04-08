using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
	public class GoToPoint : BaseAction<ActorController>
	{
		[RequiredField] public SharedGameObject TargetPosition;
		[RequiredField] public SharedUtilityScore ScoreToLock1;
		[RequiredField] public SharedUtilityScore ScoreToLock2;
		[RequiredField] public SharedUtilityScore ScoreToLock3;

		public override void OnStart()
		{
			base.OnStart();
			Actor.Movement.AiDestination = TargetPosition.Value.transform.position;
			ScoreToLock1.Value = new UtilityScore(ScoreToLock1.Value.Score, true);
			ScoreToLock2.Value = new UtilityScore(ScoreToLock2.Value.Score, true);
			ScoreToLock3.Value = new UtilityScore(ScoreToLock3.Value.Score, true);
		}

		public override TaskStatus OnUpdate()
		{
			Actor.Movement.AiDestination = TargetPosition.Value.transform.position;
			if (!Actor.Movement.HasAiReachedDestination)
			{
				return TaskStatus.Running;
			}
			ScoreToLock1.Value = new UtilityScore(ScoreToLock1.Value.Score, false);
			ScoreToLock2.Value = new UtilityScore(ScoreToLock2.Value.Score, false);
			ScoreToLock3.Value = new UtilityScore(ScoreToLock3.Value.Score, false);
			return TaskStatus.Success;
		}
	}
}
