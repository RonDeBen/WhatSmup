using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Template : ScriptableObject{
	public string name;
	public List<float> vector;
	
	public Template (string name, List<float> vector)
	{
		this.name = name;
		this.vector = vector;
	}
	
}


