using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MF
{
    public class ActorBuilder
    {
        private ActorController controller;
        private ActorModel model;
        private ActorView view;
        //private Anima anima;
        private Movement movement;
        private NervousSystem nervousSystem;
        private Action onBuilt;

        public ActorBuilder(ActorController controller) : base()
        {
            this.controller = controller;
        }

        public ActorBuilder WithModel<T>() where T : ActorModel, new()
        {
            model = new T();

            return this;
        }

        public ActorBuilder WithModel(Type modelType)
        {
            if (!typeof(ActorModel).IsAssignableFrom(modelType))
            {
                Debug.LogError(
                    $"Tried to build actor [{controller}] with a model of type [{modelType}] but that does not inherit from {nameof(ActorModel)}");
                return this;
            }

            model = (ActorModel)Activator.CreateInstance(modelType);

            return this;
        }

        public ActorBuilder WithView<T>() where T : ActorView
        {
            if (view != null)
            {
                Object.Destroy(view);
            }

            view = controller.gameObject.AddComponent<T>();

            return this;
        }

        public ActorBuilder WithView(Type viewType)
        {
            if (!typeof(ActorView).IsAssignableFrom(viewType))
            {
                Debug.LogError(
                    $"Tried to build actor [{controller}] with a view of type [{viewType}] but that does not inherit from {nameof(ActorView)}");
                return this;
            }

            view = (ActorView)Activator.CreateInstance(viewType);

            return this;
        }

        public ActorBuilder WithMovement<T>() where T : Movement, new()
        {
            if (movement != null)
            {
                Object.Destroy(movement);
            }

            movement = controller.gameObject.AddComponent<T>();

            return this;
        }

        public ActorBuilder WithMovement(Type movementType)
        {
            if (!typeof(Movement).IsAssignableFrom(movementType))
            {
                Debug.LogError(
                    $"Tried to build actor [{controller}] with a movement of type [{movementType}] but that does not inherit from {nameof(Movement)}");
                return this;
            }

            movement = (Movement)Activator.CreateInstance(movementType);

            return this;
        }

        public ActorBuilder WithNervousSystem<T>() where T : NervousSystem, new()
        {
            if (nervousSystem != null)
            {
                Object.Destroy(movement);
            }

            nervousSystem = controller.gameObject.AddComponent<T>();

            return this;
        }

        public ActorBuilder WithNervousSystem(Type nervousSystemType)
        {
            if (!typeof(NervousSystem).IsAssignableFrom(nervousSystemType))
            {
                Debug.LogError(
                    $"Tried to build actor [{controller}] with a nervous system of type [{nervousSystemType}] but that does not inherit from {nameof(NervousSystem)}");
                return this;
            }

            nervousSystem = (NervousSystem)Activator.CreateInstance(nervousSystemType);

            return this;
        }

        public ActorBuilder OnBuilt(Action onBuilt)
        {
            this.onBuilt = onBuilt;

            return this;
        }

        public void Build()
        {
            // ensure default construction of all components
            model ??= new ActorModel();
            view ??= controller.gameObject.AddComponent<ActorView>();
            movement ??= controller.gameObject.AddComponent<Movement>();
            nervousSystem ??= controller.gameObject.AddComponent<NervousSystem>();

            controller.Model = model;
            controller.View = view;
            controller.Movement = movement;
            controller.NervousSystem = nervousSystem;

            controller.Configurator.Configure(model);


            movement.Initialize(controller);
            nervousSystem.Initialize(controller);


            model = null;
            view = null;
            movement = null;
            nervousSystem = null;

            onBuilt?.Invoke();
        }
    }
}
