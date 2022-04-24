using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
	[TaskDescription("This task calculated the score for human money in every moment.")]
	[TaskCategory("Score/Human")]
	public class CalculateMoneyScore : BaseAction<HumanController>
	{
		[RequiredField] public SharedFloat MoneyScore;

		public override TaskStatus OnUpdate()
		{
			if (Actor.Model.StartTimeModelToWork.Hours <= App.TimeManager.TimeModel.Hours && Actor.Model.EndTimeModelToWork.Hours >= App.TimeManager.TimeModel.Hours)
			{
				MoneyScore.Value = 0.99f;
			}
			else
			{
				MoneyScore.Value = 0;
			}
			return TaskStatus.Running;
		}
	}
}
