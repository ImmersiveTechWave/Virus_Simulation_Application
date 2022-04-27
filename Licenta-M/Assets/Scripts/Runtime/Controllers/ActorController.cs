using UnityEngine;

namespace MF
{
	[RequireComponent(typeof(ActorConfigurator))]
	public class ActorController : MonoBehaviour
	{
		public ActorConfigurator Configurator => configurator ??= GetComponent<ActorConfigurator>();
		private ActorConfigurator configurator;

		/// <summary>
		/// Use this to build all the aspects of an <see cref="ActorController"/>
		/// </summary>
		protected ActorBuilder Builder => builder ?? (builder = new ActorBuilder(this));
		private ActorBuilder builder;

		/// <summary>
		/// The actor's view
		/// </summary>
		public ActorView View { get; set; }

		/// <summary>
		/// The actor's model, from where you can access all modifiable
		/// or relevant actor information
		/// </summary>
		public ActorModel Model { get; set; }

		/// <summary>
		/// The actor's nervous system (handles AI-related functionality)
		/// </summary>
		public NervousSystem NervousSystem { get; set; }

		/// <summary>
		/// The actor's means of locomotion
		/// </summary>
		public Movement Movement { get; set; }

		/// <summary>
		/// The actor's anima (handles animations and animation events)
		/// </summary>
		public Anima Anima { get; set; }

		/// <summary>
		/// Whether or not the actor is enabled.
		/// </summary>
		public bool IsEnabled => gameObject.activeInHierarchy;

		/// <summary>
		/// The building where the actor is. 
		/// </summary>
		public BuildingController CurrentBuilding = null;

		/// <summary>
		/// The building where the actor is. 
		/// </summary>
		public MeshController MeshController = null;

		public virtual void Awake()
		{
			Builder.Build();
			MeshController = GetComponentInChildren<MeshController>();
		}

		public virtual void Start()
		{
			InitializeModelCallbacks();
		}

		/// <summary>
		/// Triggers an animation event in the actor's anima.
		///
		/// <para>Note: this should only be called from the actor's animation clip events.</para>
		/// </summary>
		/// <param name="eventId">the ID of the animation event to trigger</param>
		public void AnimationEventTriggered(string eventId)
		{
			Anima.TriggerEvent(eventId);
		}

		protected virtual void InitializeModelCallbacks()
		{

		}
	}
}
