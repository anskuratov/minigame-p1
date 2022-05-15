using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace P1.Core
{
	public class LevelGeneratorWindow : EditorWindow
	{
		[MenuItem("AS / Level Generator")]
		public static void Open()
		{
			GetWindow(typeof(LevelGeneratorWindow));
		}

		private int _startId;
		private int _endId;
		private Vector2 _gameFieldSize;

		private void OnGUI()
		{
			GUILayout.Label("Generating Parameters", EditorStyles.boldLabel);

			_startId = EditorGUILayout.IntField("Start ID", _startId);
			_endId = EditorGUILayout.IntField("End ID", _endId);
			_gameFieldSize = EditorGUILayout.Vector2Field("Game field size", _gameFieldSize);

			if (GUILayout.Button("Generate"))
			{
				Generate();
			}
		}

		private void Generate()
		{
			var staticsData =
				AssetDatabase.LoadAssetAtPath<StaticsData>(Path.Combine("Assets", "ScriptableObjects", "StaticsData.asset"));

			if (staticsData != null)
			{
				var levels = new List<Level>(staticsData.Levels);

				var positions = GetAllPositions();

				for (var i = _startId; i <= _endId; ++i)
				{
					var circles = new List<Circle>();
					var positionsCopy = new List<Vector2>(positions);
					var circleNumber = 1;

					while (positionsCopy.Count >= 2)
					{
						var firstCircleIndex = Random.Range(0, positionsCopy.Count);
						var firstCirclePosition = positionsCopy[firstCircleIndex];
						positionsCopy.RemoveAt(firstCircleIndex);
						var firstCircle = new Circle(circleNumber, firstCirclePosition);
						circles.Add(firstCircle);

						var secondCircleIndex = Random.Range(0, positionsCopy.Count);
						var secondCirclePosition = positionsCopy[secondCircleIndex];
						positionsCopy.RemoveAt(secondCircleIndex);
						var secondCircle = new Circle(circleNumber, secondCirclePosition);
						circles.Add(secondCircle);

						circleNumber += 1;
					}

					Level levelToDelete = default;
					foreach (var level in levels)
					{
						if (level.Id == i)
						{
							levelToDelete = level;
							break;
						}
					}

					if (levelToDelete.Id != 0)
					{
						levels.Remove(levelToDelete);
					}

					levels.Add(new Level(i, i + 1, circles.ToArray(), _gameFieldSize));
				}

				staticsData.SetStaticsData(levels.ToArray());
			}
		}

		private List<Vector2> GetAllPositions()
		{
			var returnValue = new List<Vector2>();

			var xBorderPosition = _gameFieldSize.x / 2 - 0.5f;
			var yBorderPosition = _gameFieldSize.y / 2 - 0.5f;

			for (var i = -xBorderPosition; i <= xBorderPosition; i += 1)
			{
				for (var j = -yBorderPosition; j <= yBorderPosition; j += 1)
				{
					returnValue.Add(new Vector2(i, j));
				}
			}

			return returnValue;
		}
	}
}