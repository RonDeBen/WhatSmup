using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircleT {
	
	public const string name = "Circle";
	
	public static List<float> draw(){
		List<Vector2> points = new List<Vector2>();
		
		float theta = 0;
		
		for(int i = 2; i <= 360; i +=2){
			theta = i * Mathf.Deg2Rad;
			points.Add(new Vector2(Mathf.Cos(theta)*10,Mathf.Sin(theta)*10));
		}
		
		Recognizer r = new Recognizer();
		return r.Vectorize(r.Resample(points,64));
	}
}
