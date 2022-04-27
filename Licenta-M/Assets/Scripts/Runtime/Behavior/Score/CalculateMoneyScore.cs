using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
	[TaskDescription("This task calculated the score for human money in every moment.")]
	[TaskCategory("Score/Human")]
	public class CalculateMoneyScore : BaseAction<HumanController>
	{
		[RequiredField] public SharedFloat MoneyScore;

		private int startTimeInMinutes = 0;
		private int endTimeInMinutes = 0;

		public override void OnStart()
		{
			base.OnStart();
			startTimeInMinutes = Actor.Model.StartTimeModelToWork.Hours * 60 + Actor.Model.StartTimeModelToWork.Minutes;
			endTimeInMinutes = Actor.Model.EndTimeModelToWork.Hours * 60 + Actor.Model.EndTimeModelToWork.Minutes;
		}

		public override TaskStatus OnUpdate()
		{
			var currentTimeInMinutes = App.TimeManager.TimeModel.Hours * 60 + App.TimeManager.TimeModel.Minutes;

			if (startTimeInMinutes <= currentTimeInMinutes && endTimeInMinutes >= currentTimeInMinutes)
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
