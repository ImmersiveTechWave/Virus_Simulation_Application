using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
    [TaskCategory("UtilityScore")]
    public class LockScore : Action
    {
        [RequiredField] public SharedUtilityScore ScoreToLock;

        public override void OnStart()
        {
            base.OnStart();
			if (ScoreToLock != null)
			{
				ScoreToLock.Value = new UtilityScore(ScoreToLock.Value.Score, true);
			}
		}
	}
}
