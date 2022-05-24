using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
    public class CheckTimeState : Conditional
    {
		public override TaskStatus OnUpdate()
		{
			return App.IsTimeStopped ? TaskStatus.Success : TaskStatus.Failure;
		}
	}
}
