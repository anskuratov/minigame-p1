using UnityEngine;

namespace P1.Framework
{
	public static class TransformExtensions
	{
		public static void DestroyAllChildren(this Transform transform)
		{
			var childrenCount = transform.childCount;
			for (var i = 0; i < childrenCount; ++i)
			{
				var child = transform.GetChild(i);
				Object.Destroy(child.gameObject);
			}
		}
	}
}