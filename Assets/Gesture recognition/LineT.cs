using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineT {
	
	public const string name = "Line";
	
	public static List<float> draw(){
		List<Vector2> vector = new List<Vector2>();
		for(int x=0; x <128*5; x+=5){
			vector.Add(new Vector2(x,0));
		}
		Recognizer r = new Recognizer();
		return r.Vectorize(r.Resample(vector,64));
	}
}
