using P1.Framework;
using UnityEngine;

namespace P1.Core
{
	public class GameFieldSceneView : BaseView
	{
		[SerializeField] private BaseView _background;
		[SerializeField] private BaseView _dynamicObjectsContainer;

		public BaseView Background => _background;
		public BaseView DynamicObjectsContainer => _dynamicObjectsContainer;
	}

	public class GameFieldSceneViewController : BaseViewController<GameFieldSceneView, GameFieldSceneViewController.InitData>
	{
		public readonly struct InitData
		{
			public readonly Vector3 FieldScale;

			public InitData(Vector3 fieldScale)
			{
				FieldScale = fieldScale;
			}
		}

		protected override void HandleInit(InitData initData)
		{
			SetScale(initData.FieldScale);
		}
	}
}