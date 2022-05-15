using UnityEditor;
using UnityEngine;

namespace P1.Editor
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