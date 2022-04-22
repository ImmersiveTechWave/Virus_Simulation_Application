using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
	public class BaseAction<T> : Action where T : ActorController
	{
		public SharedActorController ActorController;

		protected T Actor => ActorController?.Value as T;
	}
}
