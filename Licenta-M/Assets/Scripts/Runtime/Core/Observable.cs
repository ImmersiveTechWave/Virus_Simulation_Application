using System;

namespace MF
{
	/// <summary>
	/// Wraps a value in order to allow observing its value change
	/// </summary>
	[Serializable]
	public class Observable<T> : IEquatable<Observable<T>>
	{
		private T internalValue;

		/// <summary>
		/// If set to true it will trigger on changed event also when the value is destroyed
		/// </summary>
		public bool NotifyOnDestroyed;

		/// <summary>
		/// Retrieves the previous value of the observed value
		/// </summary>
		public T PreviousValue { get; private set; }

		/// <summary>
		/// Retrieves whether the value has been changed
		/// </summary>
		public bool IsSet { get; private set; }

		public Observable()
		{
			internalValue = typeof(T) == typeof(string) ? (T)(object)string.Empty : default;
		}

		public Observable(T internalValue, bool notifyOnDestroyed = false)
		{
			NotifyOnDestroyed = notifyOnDestroyed;
			this.internalValue = internalValue;
		}

		/// <summary>
		/// Action listener for changed event. It will get triggered when the internal value has been changed either through Set method or Value property
		/// </summary>
		public Action<Observable<T>> OnChanged;

		/// <summary>
		/// Adds a listener for on changed event. This is cumulative so it does not replace the old handler, but adds another one
		/// </summary>
		/// <param name="listener"></param>
		public void AddListener(Action<Observable<T>> listener)
		{
			OnChanged += listener;
		}

		public void AddEmptyListener(Action listener)
		{
			OnChanged += new Action<Observable<T>>((_) => listener.Invoke());
		}

		/// <summary>
		/// Clears all listeners
		/// </summary>
		public void RemoveListeners()
		{
			OnChanged = null;
		}

		/// <summary>
		/// Expose the internal value through a property that also notifies on assignment
		/// </summary>
		public T Value
		{
			get => internalValue;
			set
			{
				if (value.Equals(internalValue))
				{
					return;
				}

				var oldValue = internalValue;
				internalValue = value;
				PreviousValue = oldValue;
				OnChanged?.Invoke(this);
			}
		}

		/// <summary>
		/// Sets the internal value
		/// </summary>
		/// <param name="value"></param>
		public void Set(T value)
		{
			Value = value;
			IsSet = true;
		}

		public T Get()
		{
			return Value;
		}

		/// <summary>
		/// Retrieves the internal value through the implicit cast operator
		/// </summary>
		/// <param name="observable"></param>
		public static implicit operator T(Observable<T> observable)
		{
			return observable.internalValue;
		}

		public override string ToString()
		{
			return internalValue.ToString();
		}

		public bool Equals(Observable<T> other)
		{
			return other != null && other.internalValue.Equals(internalValue);
		}

		public override bool Equals(object other)
		{
			var observable = other as Observable<T>;
			return observable != null && observable.internalValue.Equals(internalValue);
		}

		public override int GetHashCode()
		{
			return internalValue.GetHashCode();
		}

		/// <summary>
		/// Marks the observable as being dirty
		/// </summary>
		public void NotifyDirty()
		{
			IsSet = true;
		}

		~Observable()
		{
			if (NotifyOnDestroyed)
				OnChanged?.Invoke(null);
		}
	}
}
