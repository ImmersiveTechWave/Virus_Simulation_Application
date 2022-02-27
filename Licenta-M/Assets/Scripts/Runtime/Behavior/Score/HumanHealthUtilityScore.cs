using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

namespace MF
{
	[TaskDescription("This task calculated the utility score for human health.")]
	[TaskCategory("UtilityScore/Human")]
	public class HumanHealthUtilityScore : BaseAction<HumanController>
	{
		[RequiredField] public SharedUtilityScore Score;

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

			if (Score.Value.IsLocked)
			{
				return Score.Value.Score;
			}

			var health = Actor.Model.Health.Value / 100;
			var score = Mathf.Sin(1.8f * health + 1.6f);
			score = Mathf.Clamp(score, 0, 1);

			Score.Value = new UtilityScore(score, false);

			return Score.Value.Score;
		}
	}
}
