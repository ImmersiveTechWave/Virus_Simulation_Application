using BehaviorDesigner.Runtime;
using JetBrains.Annotations;
using Pathfinding;
using Pathfinding.RVO;
using UnityEngine;

namespace MF
{
    public class ActorView : MonoBehaviour, IView
    {
        public RVOController RVO { get; [UsedImplicitly] protected set; }
        public Seeker Seeker { get; [UsedImplicitly] protected set; }
        public RichAI RichAi { get; [UsedImplicitly] protected set; }
        public SimpleSmoothModifier SmoothModifier { get; [UsedImplicitly] protected set; }

        public BehaviorTree BehaviorTree { get; [UsedImplicitly] protected set; }

        private void Start()
        {
            RVO = gameObject.AddComponent<RVOController>();
            Seeker = gameObject.AddComponent<Seeker>();
            RichAi = gameObject.AddComponent<RichAI>();
            SmoothModifier = gameObject.AddComponent<SimpleSmoothModifier>();
        }
    }
}
