using UnityEngine;

namespace P1.Framework
{
	public static class RaycastUtils
	{
		public static bool TryRaycast(out Transform raycastTransform)
		{
			var returnValue = false;
			raycastTransform = default;

#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
			var collider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.touches[0].position));
#else 
			var collider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
#endif

			if (collider)
			{
				raycastTransform = collider.transform;
				returnValue = true;
			}

			return returnValue;
		}
	}
}