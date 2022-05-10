using P1.Framework;
using UnityEngine;

namespace P1.Core
{
	public class CircleSceneView : BaseView
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;

		public SpriteRenderer SpriteRenderer => _spriteRenderer;
	}

	public class CircleSceneViewController : BaseViewController<CircleSceneView, CircleSceneViewController.InitData>
	{
		public readonly struct InitData
		{
			public readonly int Number;

			public InitData(int number)
			{
				Number = number;
			}
		}

		public int Number { get; private set; }

		protected override void HandleInit(InitData initData)
		{
			Number = initData.Number;
			
			
		}

		private void SetColor(Color color)
		{
			View.SpriteRenderer.color = color;
		}
	}
}