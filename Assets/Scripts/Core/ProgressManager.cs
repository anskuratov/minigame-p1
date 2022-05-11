using UnityEngine;

namespace P1.Core
{
	public class ProgressManager
	{
		private const string CurrentLevelIdKey = "CurrentLevelId";
		private const string CoinsCountKey = "CoinsCount";

		public int CurrentLevelId
		{
			get
			{
				_currentLevelId = PlayerPrefs.HasKey(CurrentLevelIdKey) ? PlayerPrefs.GetInt(CurrentLevelIdKey) : 1;
				return _currentLevelId;
			}
			set
			{
				_currentLevelId = value;
				PlayerPrefs.SetInt(CurrentLevelIdKey, _currentLevelId);
			}
		}

		public int CoinsCount
		{
			get
			{
				_coinsCount = PlayerPrefs.HasKey(CoinsCountKey) ? PlayerPrefs.GetInt(CoinsCountKey) : 0;
				return _coinsCount;
			}
			set
			{
				_coinsCount = value;
				PlayerPrefs.SetInt(CoinsCountKey, _coinsCount);
			}
		}

		private int _currentLevelId;
		private int _coinsCount;
	}
}