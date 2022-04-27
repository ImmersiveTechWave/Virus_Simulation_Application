using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
	public class SetHumanAIVariables : BaseAction<ActorController>
	{
		[RequiredField] public SharedGameObject ActorGameObject;
		[RequiredField] public SharedGameObject HomePosition;
		[RequiredField] public SharedGameObject HospitalPosition;
		[RequiredField] public SharedGameObject MarketPosition;
		[RequiredField] public SharedVector3 JobPosition;

		public override void OnStart()
		{
			base.OnStart();
			ActorGameObject.Value = Actor.gameObject;
			HospitalPosition.Value = Actor.Model.HospitalPosition;
			MarketPosition.Value = Actor.Model.MarketPosition;
			JobPosition.Value = Actor.Model.JobLocation.GetRandomPosition();
			HomePosition.Value = Actor.Model.HomePosition;
		}
	}
}
