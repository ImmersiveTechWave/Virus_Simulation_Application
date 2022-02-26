using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
    [TaskDescription("This task calculated the utility score for human money.")]
    [TaskCategory("UtilityScore/Human")]
    public class HumanMoneyUtilityScore : BaseAction<HumanController>
    {
        [RequiredField] public SharedUtilityScore Score;

        public override float GetUtility()
        {
            if (Actor == null)
            {
                Debug.LogWarning("Actor is null in HumanMoneyUtilityScore.");
                return 0f;
            }

            if (Score == null)
            {
                Debug.LogWarning("Score is null in HumanMoneyUtilityScore.");
                return 0f;
            }

            if (Score.Value.IsLocked)
            {
                return Score.Value.Score;
            }

            var money = Actor.Model.Money.Value / 100f;
            var score = Mathf.Sin(1.8f * money + 1.6f) * 0.9f;
            score = Mathf.Clamp(score, 0, 1);

            Score.Value = new UtilityScore(score, false);

            return Score.Value.Score;
        }
    }
}
