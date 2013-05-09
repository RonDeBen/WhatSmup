using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

[CustomEditor(typeof(TemplateList))]
public class ReDrawTemplatesButton : Editor {
	
	
	public override void OnInspectorGUI(){
		DrawDefaultInspector();
		
		
		if(GUILayout.Button("(Re)Draw Templates")){
			
			TemplateList t = this.target as TemplateList;
			
			List<Template> tl = new List<Template>();
			
			//Template algorithms go here
			
			//Line
			Template line = ScriptableObject.CreateInstance<Template>();
			line.name = LineT.name;
			line.vector = LineT.draw();
			tl.Add(line);
			
			//Square
			tl.Add(new Template(SquareT.name,SquareT.draw()));
			
			//Circle
			tl.Add(new Template(CircleT.name, CircleT.draw()));
			
			Recognizer r = new Recognizer();
			
			Match m1 = new Match(LineT.name, r.optimalCosineDistance(tl[0].vector,SquareT.draw() ));
			Match m2 = new Match(SquareT.name, r.optimalCosineDistance(tl[1].vector,SquareT.draw() ));
			Match m3 = new Match(CircleT.name, r.optimalCosineDistance(tl[2].vector,SquareT.draw() ));
			
			Debug.Log("Line: " +m1.score+" Square: "+m2.score+" Circle: " +m3.score);
			
			t.tl = tl;
			
			
		}
	}
}
