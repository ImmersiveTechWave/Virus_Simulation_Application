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
		/// Whether or not the actor is enabled (wrapper over <see cref="GameObject.activeInHierarchy"/>)
		/// </summary>
		public bool IsEnabled => gameObject.activeInHierarchy;

		public virtual void Awake()
		{
			Builder.Build();
		}

		public virtual void Start()
		{
			InitializeModelCallbacks();
		}

		protected virtual void InitializeModelCallbacks()
		{

		}
	}
}
