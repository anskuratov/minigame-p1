using P1.Framework;
using UnityEngine.Device;

namespace P1.Core
{
	public class SettingsController : IInitializable
	{
		public void Init()
		{
			Application.targetFrameRate = 60;
		}
	}
}