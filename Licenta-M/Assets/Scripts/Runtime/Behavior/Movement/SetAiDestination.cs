using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
	public class SetAIDestination : BaseAction<ActorController>
	{
		[RequiredField] public SharedGameObject ActorGameObject;

		public override void OnStart()
		{
			base.OnStart();
			Actor.Movement.AiDestination = ActorGameObject.Value.transform.position;
		}
	}
}
