using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Equations{

	public static float CosDis(Vector2 a, Vector2 b){
			return (1-(Vector2.Dot(a,b)/(a.magnitude*b.magnitude)));
	}
	
	public static float Dis(Vector2 a, Vector2 b){
		return Mathf.Sqrt(Mathf.Pow((a.x - b.x),2) + Mathf.Pow((a.x + b.y),2));	
	}
	
	public static float pathLength(List<Vector2> points){
		float distance =0;
		for(int i = 1; i < points.Count; i++){
			distance += Dis (points[i-1],points[i]);
		}
		return distance;
	}
	
	public static Vector2 centroid(List<Vector2> points){
		Vector2 c = Vector2.zero;
		foreach (Vector2 item in points) {
			c.x += item.x;
		}
		foreach (Vector2 item in points) {
			c.y += item.y;
		}
		c.x /= points.Count;
		c.y /= points.Count;
		return c;
	}
	
	public static Vector3 centroid(List<Vector3> points){
		Vector3 c = Vector3.zero;
		foreach (Vector3 item in points) {
			c.x += item.x;
		}
		foreach (Vector3 item in points) {
			c.y += item.y;
		}
		foreach (Vector3 item in points) {
			c.z += item.z;
		}
		c.x /= points.Count;
		c.y /= points.Count;
		c.z /= points.Count;
		return c;
	}
	
	public static List<Vector2> translate(List<Vector2> points, Vector2 centroid){
		float deltaX = centroid.x *-1;
		float deltaY = centroid.y *-1;
		List<Vector2> newPoints = new List<Vector2>();
		foreach (var p in points) {
			newPoints.Add(new Vector2(p.x + deltaX, p.y +deltaY));
		}
		return newPoints;
	}
}