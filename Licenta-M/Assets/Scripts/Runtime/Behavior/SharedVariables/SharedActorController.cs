using BehaviorDesigner.Runtime;

namespace MF
{
    public class SharedActorController : SharedVariable<ActorController>
    {
        public static implicit operator SharedActorController(ActorController actorController)
        {
            return new SharedActorController { mValue = actorController };
        }
    }
}
