using BehaviorDesigner.Runtime;

namespace MF
{
    public class NervousSystem : IActorComponent
    {
        private const string ACTOR_CONTROLLER = "actorController";

        private BehaviorTree BehaviorTree => Actor.View.BehaviorTree;

        private void Start()
        {
            var actorController = GetComponent<ActorController>();
            if (actorController != null)
            {
                var sharedActorController = new SharedActorController();
                sharedActorController.Value = actorController;
                BehaviorTree.SetVariable(ACTOR_CONTROLLER, sharedActorController);
            }
        }
    }
}
