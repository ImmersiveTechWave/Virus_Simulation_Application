using UnityEngine;

namespace MF
{
    public abstract class IActorComponent : MonoBehaviour
    {
        /// <summary>
        /// The actor this component belongs to
        /// </summary>
        public ActorController Actor { get; protected set; }

        /// <summary>
        /// Shorthand for <see cref="Actor.gameObject"/>
        /// </summary>
        public GameObject gameObject => Actor?.gameObject;

        /// <summary>
        /// Shorthand for <see cref="Actor.transform"/>
        /// </summary>
        public Transform transform => Actor?.transform;

        /// <summary>
        /// Shorthand for <see cref="Actor.name"/>
        /// </summary>
        public string name => Actor?.name;

        protected IActorComponent()
        {
        }

        public virtual void Initialize(ActorController actor)
        {
            Actor = actor;
        }

        /// <summary>
        /// Should be called when <see cref="ActorController.Start"/> is called
        /// </summary>
        public virtual void OnStart()
        {
        }
    }
}
