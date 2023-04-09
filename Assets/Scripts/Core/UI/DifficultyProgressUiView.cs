using System.Linq;
using P1.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace P1.Core
{
	public class DifficultyProgressUiView : View
	{
		[SerializeField] private Slider _slider;
		[SerializeField] private TMP_Text _chapterNameText;

		public Slider Slider => _slider;
		public TMP_Text ChapterNameText => _chapterNameText;
	}

	public class DifficultyProgressUiViewController : ViewController<DifficultyProgressUiView>
	{
		private readonly IStatics _statics;
		private readonly GameManager _gameManager;

		public DifficultyProgressUiViewController(IStatics statics, GameManager gameManager)
		{
			_statics = statics;
			_gameManager = gameManager;
		}

		protected override void HandleInit()
		{
			_gameManager.OnLevelStarted += OnLevelStarted;
		}

		protected override void HandleRefresh()
		{
			var currentLevelId = _gameManager.Level.Id;

			var currentChapter = _statics.Chapters.Last(); 
			foreach (var chapter in _statics.Chapters)
			{
				if (currentLevelId >= chapter.StartChapterLevelId)
				{
					currentChapter = chapter;
				}
			}

			View.Slider.minValue = currentChapter.StartChapterLevelId;
			View.Slider.maxValue = currentChapter.EndChapterLevelId;
			View.Slider.value = currentLevelId;

			View.ChapterNameText.text = currentChapter.ChapterName;
		}

		private void OnLevelStarted()
		{
			Refresh();
		}
	}
}