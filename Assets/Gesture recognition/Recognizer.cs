using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Recognizer{
	
	
	public List<Template> templates;
	public int resampleRate = 64;
	
	public Recognizer (List<Template> templates, int resampleRate)
	{
		this.templates = templates;
		this.resampleRate = resampleRate;
	}
	
	public Recognizer (List<Template> templates)
	{
		this.templates = templates;
	}
	
	public Recognizer ()
	{
	}

	
	public Match recognize(List<Vector2> points){
		points = Resample(points, resampleRate);
		List<float> vector = Vectorize(points);
		Match m = new Match();
		float score =0;
		float highScore = 0;
		foreach (Template t in templates) {
			score = 1.0f - optimalCosineDistance(t.vector, vector);
			if(score>highScore){
				highScore = score;
				m.name = t.name;
				m.score = highScore;
			}
		}
		return m;
	}
	
	
	public List<Vector2> Resample(List<Vector2> points, int n){
		float I = Equations.pathLength(points)/(n - 1);
		List<Vector2> newPoints = new List<Vector2>();
		newPoints.Add(points[0]);
		float D = 0f;
		float d = 0f;
		for(int i = 1; i < points.Count; i++) {
			d = Equations.Dis(points[i-1],points[i]);
			if((D + d) >= I){
				Vector2 q =new Vector2(0,0);
				q.x = points[i-1].x + ((I-D)/d) *(points[i].x - points[i-1].x);
				q.y = points[i-1].y + ((I-D)/d) *(points[i].y - points[i-1].y);
				newPoints.Add(q);
				points[i] = q;
				D = 0;
			}
			else
				D += d;
		}
		return newPoints;
	}
	
	public List<float> Vectorize(List<Vector2> points){
		Vector2 centroid = Equations.centroid(points);
		points = Equations.translate(points, centroid);
		float delta = -1 * Mathf.Atan2(points[0].y,points[0].x);
		float sum = 0;
		List<float> vector = new List<float>();
		float newX=0;
		float newY=0;
		foreach(Vector2 p in points){
			newX = p.x * Mathf.Cos(delta) -p.y * Mathf.Sin(delta);
			newY = p.y * Mathf.Cos(delta) + p.x * Mathf.Sin (delta);
			sum += newX*newX + newY * newY;
			vector.Add(newX);
			vector.Add(newY);
		}
		float magnitude = Mathf.Sqrt(sum);
		for (int i = 0; i < vector.Count; i++) {
			vector[i] /= magnitude;
		}
		return vector;
	}
	
	// From Protractor by Yang Li, published at CHI 2010. See http://yangl.org/protractor/. 
	public float optimalCosineDistance(List<float> v1, List<float> v2){
		float a = 0;
		float b = 0;
		for(int i = 0; i < Mathf.Min(v1.Count, v2.Count); i+=2){
			a += v1[i] * v2[i] + v1[i + 1] * v2[i + 1];
			b += v1[i] * v2[i + 1] - v1[i + 1] * v2[i];
		}
		float angle = Mathf.Atan(b/a);
		return Mathf.Acos(a * Mathf.Cos(angle) + b *Mathf.Sin(angle));
	}
}
