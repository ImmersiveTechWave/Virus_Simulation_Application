using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
	[TaskDescription("This task calculated the utility score for human money.")]
	[TaskCategory("UtilityScore/Human")]
	public class HumanMoneyUtilityScore : BaseAction<HumanController>
	{
		[RequiredField] public SharedUtilityScore Score;
		[RequiredField] public SharedFloat MoneyScore;

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

			Score.Value = new UtilityScore(MoneyScore.Value, false);
			return Score.Value.Score;
		}
	}
}
