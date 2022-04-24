using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
	[TaskDescription("This task calculated the score for human energy in every moment.")]
	[TaskCategory("Score/Human")]
	public class CalculateEnergyScore : BaseAction<HumanController>
	{
		[RequiredField] public SharedFloat EnergyScore;

		public override TaskStatus OnUpdate()
		{
			EnergyScore.Value = Scores.EnergyScore[(int)Actor.Model.Energy.Value];
			return TaskStatus.Running;
		}
	}
}
