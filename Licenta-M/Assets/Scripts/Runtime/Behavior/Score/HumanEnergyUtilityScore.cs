using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
	[TaskDescription("This task calculated the utility score for human energy.")]
	[TaskCategory("UtilityScore/Human")]
	public class HumanEnergyUtilityScore : BaseAction<HumanController>
	{
		[RequiredField] public SharedUtilityScore Score;

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

			if (Score.Value.IsLocked)
			{
				return Score.Value.Score;
			}

			var energy = Actor.Model.Energy.Value / 100f;
			var score = Mathf.Sin(1.8f * energy + 1.6f) * 0.9f;
			score = Mathf.Clamp(score, 0, 1);

			Score.Value = new UtilityScore(score, false);

			return Score.Value.Score;
		}
	}
}
