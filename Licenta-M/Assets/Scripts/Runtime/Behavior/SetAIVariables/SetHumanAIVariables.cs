using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
	public class SetHumanAIVariables : BaseAction<HumanController>
	{
		[RequiredField] public SharedGameObject ActorGameObject;
		[RequiredField] public SharedVector3 HomePosition;
		[RequiredField] public SharedVector3 HospitalPosition;
		[RequiredField] public SharedVector3 MarketPosition;
		[RequiredField] public SharedVector3 JobPosition;
		[RequiredField] public SharedBool IsInQuarantine;

		public override TaskStatus OnUpdate()
		{
			ActorGameObject.Value = Actor.gameObject;
			HospitalPosition.Value = Actor.Model.HospitalPosition.GetRandomPosition();
			MarketPosition.Value = Actor.Model.ShopPosition.GetRandomPosition();
			JobPosition.Value = Actor.Model.JobPosition.GetRandomPosition();
			HomePosition.Value = Actor.Model.HomePosition.GetRandomPosition();
			IsInQuarantine.Value = Actor.MyModel.IsInQuarantine;
			return TaskStatus.Running;
		}
	}
}
