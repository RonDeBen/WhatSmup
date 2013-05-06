using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ParticleSystem))]
public class DrawLine : MonoBehaviour {

    private GameObject objLine;
    private LineRenderer lr;
    private List<Vector3> nodes = new List<Vector3>();
    private bool drawing = false;
    void Start()
    {
        lr = gameObject.AddComponent<LineRenderer>();
        lr.SetVertexCount(0);
        Material lineMat = new Material(Shader.Find("Self-Illumin/Bumped Diffuse"));
        lineMat.color = Color.yellow;
        lr.material = lineMat;
        lr.SetWidth(0.1f, 0.1f);
    }
	void Update () {

        if (Input.GetMouseButton(0))
        {
            Plane p = new Plane(Vector3.forward, transform.position.z);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0.0f;

            if(p.Raycast(ray, out hitdist))
            {
                nodes.Add(ray.GetPoint(hitdist));
            }
            lr.SetVertexCount(nodes.Count);
            for (int k = 0; k < nodes.Count; k++)
            {
                lr.SetPosition(k, nodes[k]);
            }
            transform.position = nodes[nodes.Count-1];
        }
        if (Input.GetMouseButtonUp(0))
        {
            nodes.Clear();
            lr.SetVertexCount(0);
            gameObject.transform.position = new Vector3(-30.0f, 0.0f, 0.0f);
        }
	}

    
}
