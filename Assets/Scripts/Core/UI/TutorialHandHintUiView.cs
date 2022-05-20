using P1.Framework;

namespace P1.Core
{
	public class TutorialHandHintUiView : View
	{
	}

	public class TutorialHandHintUiViewController : ViewController<TutorialHandHintUiView>
	{
		private readonly GameManager _gameManager;

		public TutorialHandHintUiViewController(GameManager gameManager)
		{
			_gameManager = gameManager;
		}

		protected override void HandleInit()
		{
			_gameManager.OnLevelStarted += OnLevelStarted;
			_gameManager.OnLevelFinished += OnLevelFinished;
		}

		private void OnLevelStarted()
		{
			SetActive(_gameManager.Level.Id == 1);
		}

		private void OnLevelFinished()
		{
			SetActive(false);
		}
	}
}