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

	public class GameFieldSceneViewController :
		BaseViewController<GameFieldSceneView, GameFieldSceneViewController.InitData>
	{
		public readonly struct InitData
		{
			public readonly Level Level;

			public InitData(Level level)
			{
				Level = level;
			}
		}

		private readonly GameManager _gameManager;

		public GameFieldSceneViewController(GameManager gameManager)
		{
			_gameManager = gameManager;

			_gameManager.OnLevelChanged += Reinit;
		}

		protected override void HandleInit(InitData initData)
		{
			View.DynamicObjectsContainer.transform.DestroyAllChildren();

			View.Background.SetScale(initData.Level.GameFieldScale);
			FillLevel(initData.Level);
		}

		private void FillLevel(Level level)
		{
			var circlePrefab = Resources.Load<CircleSceneView>(Path.Combine("Prefabs", "CircleSceneView"));

			foreach (var circle in level.Circles)
			{
				var circleSceneView = Object.Instantiate(circlePrefab, View.DynamicObjectsContainer.transform);
				var circleSceneViewController = new CircleSceneViewController(_gameManager);
				circleSceneViewController.SetView(circleSceneView);
				circleSceneViewController.Init(new CircleSceneViewController.InitData(circle));
			}
		}

		private void Reinit(Level level)
		{
			Init(new InitData(level));
		}
	}
}