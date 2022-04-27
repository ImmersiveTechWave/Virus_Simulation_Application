using UnityEngine;

namespace MF
{
	public class MeshController : MonoBehaviour
	{
		public SkinnedMeshRenderer SkinnedMeshRenderer { get; set; }

		private void Awake()
		{
			SkinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
		}
	}
}
