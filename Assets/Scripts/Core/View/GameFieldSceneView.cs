using System.Collections.Generic;
using System.IO;
using AS.Framework;
using UnityEngine;

namespace P1.Core
{
	public class GameFieldSceneView : View
	{
		[SerializeField] private View _background;
		[SerializeField] private View _dynamicObjectsContainer;

		public View Background => _background;
		public View DynamicObjectsContainer => _dynamicObjectsContainer;
	}

	public class GameFieldSceneViewController :
		ViewController<GameFieldSceneView>
	{
		private readonly GameManager _gameManager;
		private readonly Dictionary<Circle, CircleSceneView> _circles;

		private IPool<CircleSceneView> _circlesPool;

		public GameFieldSceneViewController(GameManager gameManager)
		{
			_gameManager = gameManager;
			_circles = new Dictionary<Circle, CircleSceneView>(4);

			_gameManager.OnCircleConnected += OnCircleConnected;
		}

		protected override void HandleInit()
		{
			var circlePrefab = Resources.Load<CircleSceneView>(Path.Combine("Prefabs", "CircleSceneView"));
			_circlesPool = new MonoPool<CircleSceneView>(circlePrefab, View.DynamicObjectsContainer.transform);

			_gameManager.OnLevelStarted += Refresh;
		}

		protected override void HandleRefresh()
		{
			View.Background.SetScale(_gameManager.Level.GameFieldScale);
			FillLevel(_gameManager.Level);
		}

		private void FillLevel(Level level)
		{
			Clear();

			foreach (var circle in level.Circles)
			{
				var circleSceneView = _circlesPool.Get();
				var circleSceneViewController = new CircleSceneViewController(_gameManager);
				circleSceneViewController.SetView(circleSceneView);
				circleSceneViewController.Init(
					new CircleSceneViewController.InitData(circle));

				_circles.Add(circle, circleSceneView);
			}
		}

		private void OnCircleConnected(Circle circle)
		{
			var circleSceneView = _circles[circle];
			_circlesPool.Put(circleSceneView);

			_circles.Remove(circle);
		}

		private void Clear()
		{
			foreach (var circleSceneView in _circles.Values)
			{
				_circlesPool.Put(circleSceneView);
			}

			_circles.Clear();
		}
	}
}