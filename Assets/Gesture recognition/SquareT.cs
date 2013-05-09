using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SquareT {
	
	public const string name = "Square";
	
	public static List<float> draw(){
		List<Vector2> points = new List<Vector2>();
		
		Vector2 place = Vector2.zero;
		
		for(int i = 0; i < 128/4; i++){
			points.Add(new Vector2(place.x,place.y));
			place.x+=5;
		}
		for(int i = 0; i < 128/4; i++){
			points.Add(new Vector2(place.x,place.y));
			place.y+=5;
		}
		for(int i = 0; i < 128/4; i++){
			points.Add(new Vector2(place.x,place.y));
			place.x-=5;
		}
		for(int i = 0; i < 128/4; i++){
			points.Add(new Vector2(place.x,place.y));
			place.y-=5;
		}
		
		Recognizer r = new Recognizer();
		return r.Vectorize(r.Resample(points,64));
	}
}
