using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
	public class SetHumanAIVariables : BaseAction<ActorController>
	{
		[RequiredField] public SharedGameObject ActorGameObject;

		public override void OnStart()
		{
			base.OnStart();
			ActorGameObject.Value = Actor.gameObject;
		}
	}
}
