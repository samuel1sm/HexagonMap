﻿using UnityEngine;

namespace Utils
{
	public static class HexMetrics {

		public const float outerRadius = 10f;

		public const float innerRadius = outerRadius * 0.866025404f;
		public const float solidFactor = 0.75f;
	
		public const float blendFactor = 1f - solidFactor;
		
		private static readonly Vector3[] Corners = {
			new Vector3(0f, 0f, outerRadius),
			new Vector3(innerRadius, 0f, 0.5f * outerRadius),
			new Vector3(innerRadius, 0f, -0.5f * outerRadius),
			new Vector3(0f, 0f, -outerRadius),
			new Vector3(-innerRadius, 0f, -0.5f * outerRadius),
			new Vector3(-innerRadius, 0f, 0.5f * outerRadius),
			new Vector3(0f, 0f, outerRadius)

		};
		
		public static Vector3 GetBridge (HexDirection direction) {
			return (Corners[(int)direction] + Corners[(int)direction + 1]) *
			       0.5f * blendFactor;
		}
		
		public static Vector3 GetFirstSolidCorner (HexDirection direction) {
			return Corners[(int)direction] * solidFactor;
		}

		public static Vector3 GetSecondSolidCorner (HexDirection direction) {
			return Corners[(int)direction + 1] * solidFactor;
		}
		
		public static Vector3 GetFirstCorner (HexDirection direction) {
			return Corners[(int)direction];
		}

		public static Vector3 GetSecondCorner (HexDirection direction) {
			return Corners[(int)direction + 1];
		}
	}
}