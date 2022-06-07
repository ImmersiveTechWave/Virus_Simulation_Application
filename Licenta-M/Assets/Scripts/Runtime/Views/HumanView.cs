using UnityEngine;

namespace MF
{
	public class HumanView : ActorView
	{
		public SpriteRenderer VirusSprite { get; set; }

		private void Start()
		{
			VirusSprite = GetComponentInChildren<SpriteRenderer>(true);
			VirusSprite.gameObject.SetActive(false);
		}
	}
}
