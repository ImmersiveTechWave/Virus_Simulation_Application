using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
	[TaskDescription("This task calculated the score for human health in every moment.")]
	[TaskCategory("Score/Human")]
	public class CalculateHealthScore : BaseAction<HumanController>
	{
		[RequiredField] public SharedFloat HealthScore;

		public override TaskStatus OnUpdate()
		{
			HealthScore.Value = Scores.HealthScore[(int)Actor.Model.Health.Value];
			return TaskStatus.Running;
		}
	}
}
