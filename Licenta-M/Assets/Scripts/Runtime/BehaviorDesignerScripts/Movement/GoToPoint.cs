using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MF
{
    public class GoToPoint : BaseAction<ActorController>
    {
        [RequiredField] public SharedGameObject FirstPoint;
        [RequiredField] public SharedGameObject SecondPoint;

        private int positionNumber = 1;

        public override void OnStart()
        {
            base.OnStart();
            if (positionNumber == 1)
            {
                Actor.Movement.AiDestination = FirstPoint.Value.transform.position;
                positionNumber = 2;
            }
            else
            {
                Actor.Movement.AiDestination = SecondPoint.Value.transform.position;
                positionNumber = 1;
            }

        }

        public override TaskStatus OnUpdate()
        {
            if (!Actor.Movement.HasAiReachedDestination)
            {
                return TaskStatus.Running;
            }
            return TaskStatus.Success;
        }
    }
}
