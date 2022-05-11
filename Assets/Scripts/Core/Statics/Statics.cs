using System.IO;
using Newtonsoft.Json;
using P1.Framework;
using UnityEngine;

namespace P1.Core
{
	public class Statics : IStatics,
		IInitializable
	{
		private StaticsData _data;

		public void Init()
		{
			var staticsJsonString = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "statics.json"));
			_data = JsonConvert.DeserializeObject<StaticsData>(staticsJsonString);
		}

		public bool TryGetLevel(int levelId, out Level level)
		{
			return _data.Levels.TryGetValue(levelId, out level);
		}
	}
}