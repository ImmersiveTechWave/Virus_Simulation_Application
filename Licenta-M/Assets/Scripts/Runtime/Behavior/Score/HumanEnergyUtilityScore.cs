using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
	[TaskDescription("This task calculated the utility score for human energy.")]
	[TaskCategory("UtilityScore/Human")]
	public class HumanEnergyUtilityScore : BaseAction<HumanController>
	{
		[RequiredField] public SharedUtilityScore Score;
		[RequiredField] public SharedFloat EnergyScore;

		public override float GetUtility()
		{
			if (Actor == null)
			{
				Debug.LogWarning("Actor is null in HumanEnergyUtilityScore.");
				return 0f;
			}

			if (Score == null)
			{
				Debug.LogWarning("Score is null in HumanEnergyUtilityScore.");
				return 0f;
			}

			//if (Score.Value.IsLocked)
			//{
			//	return Score.Value.Score;
			//}

			Score.Value = new UtilityScore(EnergyScore.Value, false);

			return Score.Value.Score;
		}
	}
}
