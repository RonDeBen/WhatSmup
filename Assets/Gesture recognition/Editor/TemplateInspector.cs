using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Template))]
public class TemplateInspector : Editor {

	public override void OnInspectorGUI(){
		Template t = this.target as Template;
		GUILayout.Label(t.name);
	}
}
