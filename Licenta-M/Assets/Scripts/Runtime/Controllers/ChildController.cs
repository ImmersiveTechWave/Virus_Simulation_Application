using UnityEngine;

namespace MF
{
	[RequireComponent(typeof(ChildConfigurator))]
	public class ChildController : CustomActorController<ChildModel, ChildView, Movement, NervousSystem>
	{

	}
}
