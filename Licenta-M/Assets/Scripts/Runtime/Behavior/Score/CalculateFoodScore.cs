using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
	[TaskDescription("This task calculated the score for human hunger in every moment.")]
	[TaskCategory("Score/Human")]
	public class CalculateFoodScore : BaseAction<HumanController>
	{
		[RequiredField] public SharedFloat FoodScore;

		public override TaskStatus OnUpdate()
		{
			FoodScore.Value = Scores.FoodScore[(int)Actor.Model.Hunger.Value];
			return TaskStatus.Running;
		}
	}
}
