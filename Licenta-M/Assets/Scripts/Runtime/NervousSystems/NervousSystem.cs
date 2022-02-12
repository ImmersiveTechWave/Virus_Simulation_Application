using BehaviorDesigner.Runtime;

namespace MF
{
    public class NervousSystem : IActorComponent
    {
        private BehaviorTree BehaviorTree => Actor.View.BehaviorTree;
    }
}
