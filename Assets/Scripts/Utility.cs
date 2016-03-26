using UnityEngine;
using System.Collections;


namespace BerlinJam
{
	public static class Utility
	{
		public static float GetAngle(this Vector2 vector)
		{
			return (Mathf.PI * 4 + Mathf.Atan2(vector.y, vector.x) - Mathf.PI * 0.5f) % (Mathf.PI * 2);
		}
	}
}
