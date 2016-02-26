using UnityEngine;

public static class RendererUtility {

	public static bool IsVisibleFrom(this Bounds bound, Camera camera) {
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
		return GeometryUtility.TestPlanesAABB(planes, bound);
	}
}
