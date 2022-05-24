using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
	[TaskDescription("This task calculated the utility score for human health.")]
	[TaskCategory("UtilityScore/Human")]
	public class HumanHealthUtilityScore : BaseAction<HumanController>
	{
		[RequiredField] public SharedUtilityScore Score;
		[RequiredField] public SharedFloat HealthScore;

		public override float GetUtility()
		{
			if (Actor == null)
			{
				Debug.LogWarning("Actor is null in HumanHealthUtilityScore.");
				return 0f;
			}

			if (Score == null)
			{
				Debug.LogWarning("Score is null in HumanHealthUtilityScore.");
				return 0f;
			}

			//if (Score.Value.IsLocked)
			//{
			//	return Score.Value.Score;
			//}

			Score.Value = new UtilityScore(HealthScore.Value, false);

			return Score.Value.Score;
		}
	}
}
