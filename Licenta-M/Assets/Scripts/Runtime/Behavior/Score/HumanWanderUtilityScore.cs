using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
    [TaskCategory("UtilityScore/Human")]
    public class HumanWanderUtilityScore : BaseAction<HumanController>
    {
        [RequiredField] public SharedUtilityScore Score;
        [RequiredField] public SharedFloat WanderScore;

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

			Score.Value = new UtilityScore(WanderScore.Value, false);
			return Score.Value.Score;
		}
	}
}
