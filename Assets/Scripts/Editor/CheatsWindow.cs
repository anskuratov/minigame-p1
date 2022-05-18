using UnityEditor;
using UnityEngine;

namespace P1.Editor
{
	public class CheatsWindow : EditorWindow
	{
		private const string CurrentLevelIdKey = "CurrentLevelId";
		private const string CoinsCountKey = "CoinsCount";

		[MenuItem("AS/Cheats")]
		public static void Open()
		{
			Init();
			GetWindow(typeof(CheatsWindow));
		}

		private static int _currentLevelId;
		private static int _coinsCount;

		private static void Init()
		{
			_currentLevelId = 1;
			_coinsCount = 0;

			if (PlayerPrefs.HasKey(CurrentLevelIdKey))
			{
				_currentLevelId = PlayerPrefs.GetInt(CurrentLevelIdKey);
			}

			if (PlayerPrefs.HasKey(CoinsCountKey))
			{
				_coinsCount = PlayerPrefs.GetInt(CoinsCountKey);
			}
		}

		private void OnGUI()
		{
			DrawChangeProgress();
		}

		private void DrawChangeProgress()
		{
			GUILayout.Label("Change Progress", EditorStyles.boldLabel);

			_currentLevelId = EditorGUILayout.IntField("Current level ID", _currentLevelId);
			_coinsCount = EditorGUILayout.IntField("Coins count", _coinsCount);

			if (GUILayout.Button("Save"))
			{
				Save();
			}

			if (GUILayout.Button("Reset progress"))
			{
				ResetProgress();
			}
		}

		private void Save()
		{
			PlayerPrefs.SetInt(CurrentLevelIdKey, _currentLevelId);
			PlayerPrefs.SetInt(CoinsCountKey, _coinsCount);
		}

		private void ResetProgress()
		{
			PlayerPrefs.DeleteAll();
			Init();
		}
	}
}