using System.IO;
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
		}

		private readonly IStatics _statics;
		private readonly ProgressManager _progressManager;

		public GameFieldSceneViewController(IStatics statics, ProgressManager progressManager)
		{
			_statics = statics;
			_progressManager = progressManager;
		}

		protected override void HandleInit(InitData initData)
		{
			if (_statics.TryGetLevel(_progressManager.CurrentLevelId, out var levelData))
			{
				View.Background.SetScale(levelData.GameFieldScale);
				FillLevel(levelData);
			}
		}

		private void FillLevel(Level level)
		{
			var circlePrefab = Resources.Load<CircleSceneView>(Path.Combine("Prefabs", "CircleSceneView"));

			foreach (var circle in level.Circles)
			{
				var circleSceneView = Object.Instantiate(circlePrefab, View.DynamicObjectsContainer.transform);
				var circleSceneViewController = new CircleSceneViewController();
				circleSceneViewController.SetView(circleSceneView);
				circleSceneViewController.Init(new CircleSceneViewController.InitData(circle));
			}
		}
	}
}