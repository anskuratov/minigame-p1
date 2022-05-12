using UnityEngine;

namespace P1.Core
{
	public static class RaycastUtils
	{
		public static bool TryRaycast(out Transform raycastTransform)
		{
			var returnValue = false;
			raycastTransform = default;

			var collider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

			if (collider)
			{
				raycastTransform = collider.transform;
				returnValue = true;
			}

			return returnValue;
		}
	}
}