using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
    [TaskCategory("UtilityScore")]
    public class UnlockScore : Action
    {
        [RequiredField] public SharedUtilityScore ScoreToUnlock;

        public override void OnStart()
        {
            base.OnStart();
            if (ScoreToUnlock != null)
            {
                ScoreToUnlock.Value = new UtilityScore(ScoreToUnlock.Value.Score, false);
            }
        }
    }
}
