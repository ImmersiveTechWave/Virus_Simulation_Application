namespace MF
{
	public class SetAiDestination : BaseAction<ActorController>
	{
		public override void OnStart()
		{
			base.OnStart();
			Actor.Movement.AiDestination = Actor.transform.position;
		}
	}
}
