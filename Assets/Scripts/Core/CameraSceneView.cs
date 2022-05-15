using P1.Framework;
using UnityEngine;

namespace P1.Core
{
	public class CameraSceneView : View
	{
		[SerializeField] private Camera _camera;

		public Camera Camera => _camera;
	}

	public class CameraSceneViewController : ViewController<CameraSceneView>
	{
		private const float Offset = 0.5f;

		private readonly GameManager _gameManager;

		public CameraSceneViewController(GameManager gameManager)
		{
			_gameManager = gameManager;

			_gameManager.OnLevelStarted += AdjustCameraSize;
		}

		protected override void HandleInit()
		{
		}

		private void AdjustCameraSize()
		{
			View.Camera.orthographicSize = 5;

			var level = _gameManager.Level;

			var maxX = level.GameFieldScale.x / 2 - 0.5f + Offset;
			var maxY = level.GameFieldScale.y / 2 - 0.5f + Offset;

			var maxXViewportPosition = View.Camera.WorldToViewportPoint(new Vector3(maxX, 0, 0)).x;
			var minXViewportPosition = View.Camera.WorldToViewportPoint(new Vector3(-maxX, 0, 0)).x;
			var maxYViewportPosition = View.Camera.WorldToViewportPoint(new Vector3(0, maxY, 0)).y;
			var minYViewportPosition = View.Camera.WorldToViewportPoint(new Vector3(0, -maxY, 0)).y;

			while (maxXViewportPosition > 1
				|| maxYViewportPosition > 1
				|| minXViewportPosition < 0
				|| minYViewportPosition < 0)
			{
				View.Camera.orthographicSize += 1;

				maxXViewportPosition = View.Camera.WorldToViewportPoint(new Vector3(maxX, 0, 0)).x;
				minXViewportPosition = View.Camera.WorldToViewportPoint(new Vector3(-maxX, 0, 0)).x;
				maxYViewportPosition = View.Camera.WorldToViewportPoint(new Vector3(0, maxY, 0)).y;
				minYViewportPosition = View.Camera.WorldToViewportPoint(new Vector3(0, -maxY, 0)).y;
			}
		}
	}
}