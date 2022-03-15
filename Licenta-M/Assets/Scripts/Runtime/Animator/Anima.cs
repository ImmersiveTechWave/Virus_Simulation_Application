using DG.Tweening;
using MF.Promises;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MF
{
	/// <summary>
	/// Constants for animation parameters
	/// </summary>
	public class AnimaParameters
	{
		public int SpeedHorizontal;
		public int SpeedVertical;
		public int SpeedMultiplier;
		public int Die;
	}

	public class Anima : IActorComponent
	{
		/// <summary>
		/// Constants for animation layers
		/// </summary>
		public static class Layers
		{
			public const int BASE_LAYER = 0;
		}

		public float Speed
		{
			get => Actor.View.Animator.speed;
			set => Actor.View.Animator.speed = value;
		}

		public AnimaParameters Parameters { get; private set; }

		private Dictionary<string, UnityAction> wiredEventCallbacks = new Dictionary<string, UnityAction>();
		private bool isInitialized;
		private Vector3 lastHeightlessVelocity;

		/// <summary>
		/// An internal datastructure to keep track of all event promises created by <see cref="WaitForEvent(string, object)"/>.
		/// </summary>
		private List<(string EventId, Promise Promise, Action UnregisterAction, object Caller)>
			waitForEventPromises = new List<(string, Promise, Action, object)>();

		public Anima() : base()
		{
		}

		public override void Initialize(ActorController actor)
		{
			base.Initialize(actor);

			MapBaseParameters();

			isInitialized = true;
		}

		private void MapBaseParameters()
		{
			Parameters = new AnimaParameters();
			if (Actor.View.Animator != null)
			{
				foreach (var animatorParameter in Actor.View.Animator.parameters)
				{
					switch (animatorParameter.name)
					{
						case "speedH":
							Parameters.SpeedHorizontal = animatorParameter.nameHash;
							break;
						case "speedV":
							Parameters.SpeedVertical = animatorParameter.nameHash;
							break;
						case "speedMul":
							Parameters.SpeedMultiplier = animatorParameter.nameHash;
							break;
						case "die":
							Parameters.Die = animatorParameter.nameHash;
							break;
					}
				}
			}
		}

		/// <summary>
		/// Invokes all wired callbacks for the event with the given ID, if there are any.
		/// </summary>
		/// <param name="eventId">the event ID to trigger</param>
		public void TriggerEvent(string eventId)
		{
			if (!wiredEventCallbacks.ContainsKey(eventId))
			{
				Debug.LogWarning($"Animation event [{eventId}] was triggered for [{Actor}] but it had no callbacks wired");
				return;
			}

			wiredEventCallbacks[eventId]?.Invoke();
		}

		/// <summary>
		/// Adds a callback for the specified animation event. 
		/// Event callbacks are additive, meaning you can have multiple callbacks for the same event.
		/// </summary>
		/// <param name="eventId">the ID of the event to register to</param>
		/// <param name="onEventTriggered">the callback to call when the event is triggered</param>
		public void WireEvent(string eventId, UnityAction onEventTriggered)
		{
			if (wiredEventCallbacks.ContainsKey(eventId))
			{
				wiredEventCallbacks[eventId] += onEventTriggered;
			}
			else
			{
				wiredEventCallbacks.Add(eventId, onEventTriggered);
			}
		}

		/// <summary>
		/// Removes a callback from the specified animation event. If it is not wired to the event, nothing happens.
		/// </summary>
		/// <param name="eventId">the ID of the event to register to</param>
		/// <param name="onEventTriggered">the callback to remove</param>
		public void UnwireEvent(string eventId, UnityAction onEventTriggered)
		{
			if (!wiredEventCallbacks.ContainsKey(eventId)) return;

			wiredEventCallbacks[eventId] -= onEventTriggered;
		}

		/// <summary>
		/// Cleans all Animation event promises created by a caller using <see cref="WaitForEvent(string, object)"/>.
		/// Also cleans events whose caller is now null.
		/// It rejects all promises and unwires all events made by the caller.
		/// </summary>
		/// <param name="caller">Events created by this caller will be removed.</param>
		public void RemoveAllEventPromisesForCaller(System.Object caller)
		{
			var i = 0;
			while (i < waitForEventPromises.Count)
			{
				var eventPromise = waitForEventPromises[i];

				if (eventPromise.Caller == caller

					// Also clean up any residual null callers.
					|| eventPromise.Caller == null
					)
				{
					waitForEventPromises.RemoveAt(i);
					eventPromise.UnregisterAction?.Invoke();
					if (eventPromise.Promise?.CurState == PromiseState.Pending)
						eventPromise.Promise?.Reject(null);
				}
				else
				{
					i++;
				}
			}
		}

		/// <summary>
		/// Returns a promise that resolves when the animation event was triggered.
		/// Usefull for chaining animation events, tweens, etc.
		/// </summary>
		/// <param name="eventId">The eventId to listen for.</param>
		/// <param name="caller">Used for cleaning up of residual promises using <see cref="RemoveAllEventPromisesForCaller(object caller)"/>
		/// Usually the object which calls this method.</param>
		/// <returns>Returns a promise that resolves when the animation event was triggered.</returns>
		public Promise WaitForEvent(string eventId, object caller)
		{
			var waitForPromise = new Promise();

			void ResolvePromiseOnEvent()
			{
				waitForPromise.Resolve();
				UnwirePromiseForEvent();
			}

			void UnwirePromiseForEvent()
			{
				UnwireEvent(eventId, ResolvePromiseOnEvent);
			}

			waitForEventPromises.Add((eventId, waitForPromise, UnwirePromiseForEvent, caller));
			WireEvent(eventId, ResolvePromiseOnEvent);

			return waitForPromise;
		}

		/// <summary>
		/// Sets a non-trigger animator parameter's value in the animator.
		///
		/// <para>Note: Unity animator parameter types are limited to: float, bool, int.</para>
		/// </summary>
		/// <typeparam name="T">the type of value to set</typeparam>
		/// <param name="animatorParameterName">the name of the animator parameter</param>
		/// <param name="value">the value of the animator parameter</param>
		public void Set<T>(string animatorParameterName, T value)
		{
			var anim = Actor.View.Animator;

			switch (value)
			{
				case float floatValue:
					anim.SetFloat(animatorParameterName, floatValue);
					break;
				case bool boolean:
					anim.SetBool(animatorParameterName, boolean);
					break;
				case int integer:
					anim.SetInteger(animatorParameterName, integer);
					break;
				default:
					Debug.LogError(
						$"Tried to set value of parameter {animatorParameterName} but {value} is not a float, bool, or int");
					break;
			}
		}

		/// <summary>
		/// Sets a non-trigger animator parameter's value in the animator.
		///
		/// <para>Note: Unity animator parameter types are limited to: float, bool, int.</para>
		/// </summary>
		/// <typeparam name="T">the type of value to set</typeparam>
		/// <param name="animatorParameterHash">the hash of the animator parameter</param>
		/// <param name="value">the value of the animator parameter</param>
		public void Set<T>(int animatorParameterHash, T value)
		{
			var anim = Actor.View.Animator;

			switch (value)
			{
				case float floatValue:
					anim.SetFloat(animatorParameterHash, floatValue);
					break;
				case bool boolean:
					anim.SetBool(animatorParameterHash, boolean);
					break;
				case int integer:
					anim.SetInteger(animatorParameterHash, integer);
					break;
				default:
					Debug.LogError(
						$"Tried to set value of parameter {animatorParameterHash} but {value} is not a float, bool, or int");
					break;
			}
		}

		/// <summary>
		/// Gets a non-trigger animator parameter's value from the animator.
		///
		/// <para>Note: Unity animator parameter types are limited to: float, bool, int.</para>
		/// </summary>
		/// <typeparam name="T">The type of value to get</typeparam>
		/// <param name="animatorParameterName">the name of the animator parameter</param>
		/// <returns>the value of the animator parameter, if it exists, otherwise default is returned</returns>
		public T Get<T>(string animatorParameterName) where T : class
		{
			var anim = Actor.View.Animator;

			if (typeof(T) == typeof(float)) return anim.GetFloat(animatorParameterName) as T;

			if (typeof(T) == typeof(int)) return anim.GetBool(animatorParameterName) as T;

			if (typeof(T) == typeof(bool)) return anim.GetInteger(animatorParameterName) as T;

			return default;
		}

		/// <summary>
		/// Gets a non-trigger animator parameter's value from the animator.
		///
		/// <para>Note: Unity animator parameter types are limited to: float, bool, int.</para>
		/// </summary>
		/// <typeparam name="T">The type of value to get</typeparam>
		/// <param name="animatorParameterHash">the hash of the animator parameter</param>
		/// <returns>the value of the animator parameter, if it exists, otherwise default is returned</returns>
		public T Get<T>(int animatorParameterHash) where T : class
		{
			var anim = Actor.View.Animator;

			if (typeof(T) == typeof(float)) return anim.GetFloat(animatorParameterHash) as T;

			if (typeof(T) == typeof(int)) return anim.GetBool(animatorParameterHash) as T;

			if (typeof(T) == typeof(bool)) return anim.GetInteger(animatorParameterHash) as T;

			return default;
		}

		/// <summary>
		/// Triggers an animator trigger.
		/// </summary>
		/// <param name="animatorParameterName">the name of the trigger.</param>
		public void Trigger(string animatorParameterName)
		{
			Actor.View.Animator.SetTrigger(animatorParameterName);
		}


		/// <summary>
		/// Resets (sets to false) the animation trigger.
		/// </summary>
		/// <param name="animatorParameterName">the name of the trigger.</param>
		public void ResetTrigger(string animatorParameterName)
		{
			Actor.View.Animator.ResetTrigger(animatorParameterName);
		}

		/// <summary>
		/// Triggers an animator trigger.
		/// </summary>
		/// <param name="animatorParameterName">the hash of the trigger.</param>
		public void Trigger(int animatorParameterHash)
		{
			Actor.View.Animator.SetTrigger(animatorParameterHash);
		}

		/// <summary>
		/// Resets (sets to false) the animation trigger.
		/// </summary>
		/// <param name="animatorParameterName">the hash of the trigger.</param>
		public void ResetTrigger(int animatorParameterHash)
		{
			Actor.View.Animator.ResetTrigger(animatorParameterHash);
		}

		public void FixedUpdate()
		{
			UpdateMovementVelocity();
		}

		private void UpdateMovementVelocity()
		{
			// jumping in place has a small velocity on the y-axis, which we need to nullify, otherwise
			// the character will jitter while the jump begins
			var heightlessVelocity =
				transform.InverseTransformDirection(new Vector3(Actor.Model.CurrentVelocity.x, 0f,
					Actor.Model.CurrentVelocity.z));


			// need to smooth out the velocity when AI-mode is on, because it fluctuates a lot
			// from frame to frame
			heightlessVelocity = Vector3.Lerp(lastHeightlessVelocity, heightlessVelocity, Time.deltaTime * 10f);
			lastHeightlessVelocity = heightlessVelocity;


			var currentMovementSpeed = Actor.Model.MovementSpeed.Value;
			// set speed multiplier to 1 if there's no velocity being applied to it, to make the idle
			// animation look normal
			Set(Parameters.SpeedMultiplier,
				heightlessVelocity.sqrMagnitude > 0f ? currentMovementSpeed : 1f);
			Set(Parameters.SpeedHorizontal, heightlessVelocity.x);
			Set(Parameters.SpeedVertical, heightlessVelocity.z);
		}

		/// <summary>
		/// Sets the weight of the layer with the given index in the specified amount of time. The layer index and the desired weight must be greater than or equal to 0.
		///
		/// <para><b>Note 1</b>: Uses DOTween's DOFloat if <paramref name="duration"/> is greater than zero (otherwise it simply calls the <see cref="Animator.SetLayerWeight"/> method once.</para>
		/// <para><b>Note 2</b>: Calling this again for the same layer before the duration ends yields undefined behavior.</para>
		/// </summary>
		/// <param name="layerIndex">the index of the layer to tween</param>
		/// <param name="desiredWeight"></param>
		/// <param name="duration"></param>
		public IPromise SetLayerWeight(int layerIndex, float desiredWeight, float duration)
		{
			var promise = new Promise();

			if (layerIndex < 0)
			{
				promise.Reject(new Exception($"Animation layer index {layerIndex} is invalid"));
				return promise;
			}

			if (desiredWeight < 0)
			{
				promise.Reject(new Exception($"Animation layer weight {desiredWeight} is invalid"));
				return promise;
			}

			if (duration == 0f)
			{
				Actor.View.Animator.SetLayerWeight(layerIndex, desiredWeight);
				promise.Resolve();
				return promise;
			}

			DOTween.To
			(
				() => Actor.View.Animator.GetLayerWeight(layerIndex),
				weight => Actor.View.Animator.SetLayerWeight(layerIndex, weight),
				desiredWeight,
				duration
			);

			return promise;
		}
	}
}
