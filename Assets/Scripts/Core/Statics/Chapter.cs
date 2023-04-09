using System;
using UnityEngine;

namespace P1.Core
{
	[Serializable]
	public struct Chapter
	{
		[SerializeField] private string _chapterName;
		[SerializeField] private int _startChapterLevelId;
		[SerializeField] private int _endChapterLevelId;

		public string ChapterName => _chapterName;
		public int StartChapterLevelId => _startChapterLevelId;
		public int EndChapterLevelId => _endChapterLevelId;
	}
}