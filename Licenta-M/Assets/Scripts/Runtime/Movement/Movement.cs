using UnityEngine;
using UnityEngine.Events;

namespace MF
{
	public class Movement : IActorComponent
	{
		/// <summary>
		/// The default AI destination (see <see cref="RichAI.destination" />)
		/// </summary>
		public static readonly Vector3 DEFAULT_DESTINATION = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

		/// <summary>
		/// Gets or sets the current destination <b>of the AI</b>.
		/// </summary>
		public Vector3 AiDestination
		{
			get => Actor.View.RichAi.destination;
			set
			{
				if (Actor.View.RichAi.destination != value)
				{
					Actor.View.RichAi.destination = value;
				}
			}
		}

		/// <summary>
		/// True if the pathfinding component of the AI has reached its destination.
		/// </summary>
		public bool HasAiReachedDestination => Actor.View.RichAi.reachedDestination;

		/// <summary>
		/// True only after <see cref="Initialize" /> is called successfully
		/// </summary>
		public bool IsInitialized { get; private set; }

		/// <summary>
		/// Callback from when an AI-controlled actor has just arrived at its destination
		/// <para>Note: This gets cleared after each time it is called.</para>
		/// </summary>
		public UnityAction OnAiArrivedAtDestination { get; set; }

		public Movement() : base()
		{
		}

		public override void Initialize(ActorController actor)
		{
			base.Initialize(actor);
			InitializeCallbacks();
			SetRichAiSpeed(Actor.Model.MovementSpeed.Value);
			IsInitialized = true;
		}

		private void FixedUpdate()
		{
			if (!IsInitialized)
			{
				return;
			}

			UpdateAiDestinationCallback();
			UpdateVelocityAndGrounding();
		}

		private void UpdateAiDestinationCallback()
		{
			if (AiDestination == DEFAULT_DESTINATION || !Actor.View.RichAi.reachedDestination || OnAiArrivedAtDestination == null)
			{
				return;
			}

			OnAiArrivedAtDestination?.Invoke();
			OnAiArrivedAtDestination = null;
		}

		private void InitializeCallbacks()
		{
			Actor.Model.MovementSpeed.OnChanged += OnActorMovementSpeedChanged;
		}

		private void OnActorMovementSpeedChanged(Observable<float> movementSpeed)
		{
			SetRichAiSpeed(movementSpeed.Value);
		}

		private void SetRichAiSpeed(float speed)
		{
			Actor.View.RichAi.maxSpeed = speed;
			Actor.View.RichAi.acceleration = speed; //* 5f;
		}

		private void UpdateVelocityAndGrounding()
		{
			Actor.Model.CurrentVelocity = Actor.View.RichAi.velocity;
		}
	}
}
