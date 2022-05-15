using UnityEditor;
using UnityEngine;

namespace P1.Core
{
	public static class UtilsEditor
	{
		[MenuItem("AS / Reset progress")]
		public static void ResetProgress()
		{
			PlayerPrefs.DeleteAll();
		}
	}
}