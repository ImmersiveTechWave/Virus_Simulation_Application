using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
	[TaskCategory("UtilityScore")]
	public class LockAllScores : Action
	{
		public SharedUtilityScore Score1;
		public SharedUtilityScore Score2;
		public SharedUtilityScore Score3;
		public SharedUtilityScore Score4;
		public SharedUtilityScore Score5;
		public SharedUtilityScore Score6;
		public SharedUtilityScore Score7;
		public SharedUtilityScore Score8;
		public SharedUtilityScore Score9;
		public SharedUtilityScore Score10;

		public override void OnStart()
		{
			base.OnStart();
			if (Score1 != null)
				Score1.Value = new UtilityScore(Score1.Value.Score, true);
			if (Score2 != null)
				Score2.Value = new UtilityScore(Score2.Value.Score, true);
			if (Score3 != null)
				Score3.Value = new UtilityScore(Score3.Value.Score, true);
			if (Score4 != null)
				Score4.Value = new UtilityScore(Score4.Value.Score, true);
			if (Score5 != null)
				Score5.Value = new UtilityScore(Score5.Value.Score, true);
			if (Score6 != null)
				Score6.Value = new UtilityScore(Score6.Value.Score, true);
			if (Score7 != null)
				Score7.Value = new UtilityScore(Score7.Value.Score, true);
			if (Score8 != null)
				Score8.Value = new UtilityScore(Score8.Value.Score, true);
			if (Score9 != null)
				Score9.Value = new UtilityScore(Score9.Value.Score, true);
			if (Score10 != null)
				Score10.Value = new UtilityScore(Score10.Value.Score, true);
		}
	}
}
