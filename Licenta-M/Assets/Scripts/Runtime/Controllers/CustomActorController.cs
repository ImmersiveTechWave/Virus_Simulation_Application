namespace MF
{
    /// <summary>
	/// A customizable <see cref="ActorController"/> which lets you specify the type of each of its <see cref="IActorComponent"/>s.
	///
	/// <para>Also exposes a set of properties that are the typecast equivalent of each of <see cref="ActorController.Model"/>, <see cref="ActorController.View"/>, <see cref="ActorController.Anima"/> and so on, with "My" at the beginning of the name, e.g., <see cref="CustomActorController{TModel,TView,TAnima,TMovement,TNervousSystem,TBody,TPsyche}.MyModel"/>, <see cref="CustomActorController{TModel,TView,TAnima,TMovement,TNervousSystem,TBody,TPsyche}.MyView"/> and so on.</para>
	/// </summary>
	/// <typeparam name="TModel">the type of <see cref="ActorModel"/> to use.</typeparam>
	/// <typeparam name="TView">the type of <see cref="ActorView"/> to use.</typeparam>
	/// <typeparam name="TMovement">the type of <see cref="Movement"/> to use.</typeparam>
	/// <typeparam name="TNervousSystem">the type of <see cref="NervousSystem"/> to use.</typeparam>
    public abstract class CustomActorController<TModel, TView, TMovement, TNervousSystem> : ActorController
        where TModel : ActorModel, new()
        where TView : ActorView, new()
        where TMovement : Movement, new()
        where TNervousSystem : NervousSystem, new()
    {
        /// <summary>
        /// This is <see cref="ActorController.Model"/> cast to <typeparamref name="TModel"/>.
        ///
        /// <para><b>Important</b>: It is assumed you never reassign <see cref="ActorController.Model"/>. Undefined behaviour will occur if you do.</para>
        /// </summary>
        public TModel MyModel { get; private set; }

        /// <summary>
        /// This is <see cref="ActorController.View"/> cast to <typeparamref name="TView"/>
        ///
        /// <para><b>Important</b>: It is assumed you never reassign <see cref="ActorController.View"/>. Undefined behaviour will occur if you do.</para>
        /// </summary>
        public TView MyView { get; private set; }

        /// <summary>
        /// This is <see cref="ActorController.Movement"/> cast to <typeparamref name="TMovement"/>
        ///
        /// <para><b>Important</b>: It is assumed you never reassign <see cref="ActorController.Movement"/>. Undefined behaviour will occur if you do.</para>
        /// </summary>
        public TMovement MyMovement { get; private set; }

        /// <summary>
        /// This is <see cref="ActorController.NervousSystem"/> cast to <typeparamref name="TNervousSystem"/>
        ///
        /// <para><b>Important</b>: It is assumed you never reassign <see cref="ActorController.NervousSystem"/>. Undefined behaviour will occur if you do.</para>
        /// </summary>
        public TNervousSystem MyNervousSystem { get; private set; }

        public override void Awake()
        {
            Builder
                .WithModel<TModel>()
                .WithView<TView>()
                .WithMovement<TMovement>()
                .WithNervousSystem<TNervousSystem>()
                .OnBuilt(InitializeMyReferences);
            base.Awake();
        }

        private void InitializeMyReferences()
        {
            MyModel = (TModel)Model;
            MyView = (TView)View;
            MyMovement = (TMovement)Movement;
            MyNervousSystem = (TNervousSystem)NervousSystem;
        }
    }

    /// <summary>
    /// A variant of <see cref="CustomActorController{TModel,TView,TMovement,TNervousSystem}"/> which lets you specify the type
    /// of <see cref="ActorModel"/> you want to use (all the other aspects are set to the base class type)
    /// </summary>
    /// <typeparam name="TModel">the type of <see cref="ActorModel"/> to use</typeparam>
    public abstract class CustomActorController<TModel> : CustomActorController<TModel, ActorView, Movement, NervousSystem>
        where TModel : ActorModel, new()
    {
    }

    /// <summary>
    /// A variant of <see cref="CustomActorController{TModel,TView,TAnima,TMovement,TNervousSystem,TBody,TPsyche}"/> which lets you specify the type
    /// of <see cref="ActorModel"/> and <see cref="ActorView"/> you want to use (all the other aspects are set to the base class type)
    /// </summary>
    /// <typeparam name="TModel">the type of <see cref="ActorModel"/> to use</typeparam>
    /// <typeparam name="TView">the type of <see cref="ActorView"/> to use</typeparam>
    public abstract class CustomActorController<TModel, TView> : CustomActorController<TModel, TView, Movement, NervousSystem>
        where TModel : ActorModel, new()
        where TView : ActorView, new()
    {
    }

    /// <summary>
    /// A variant of <see cref="CustomActorController{TModel,TView,TAnima,TMovement,TNervousSystem,TBody,TPsyche}"/> which lets you specify the type
    /// of <see cref="ActorModel"/>, <see cref="ActorView"/>, and <see cref="Movement"/> you want to use (all the other aspects are set to the base class type)
    /// </summary>
    /// <typeparam name="TModel">the type of <see cref="ActorModel"/> to use</typeparam>
    /// <typeparam name="TView">the type of <see cref="ActorView"/> to use</typeparam>
    /// <typeparam name="TMovement">the type of <see cref="Movement"/> to use</typeparam>
    public abstract class CustomActorController<TModel, TView, TMovement> : CustomActorController<TModel, TView, TMovement, NervousSystem>
        where TModel : ActorModel, new()
        where TView : ActorView, new()
        where TMovement : Movement, new()
    {
    }
}
