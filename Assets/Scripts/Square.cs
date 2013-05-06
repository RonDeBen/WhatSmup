using UnityEngine;
using System.Collections;

//Making a mesh
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
//[RequireComponent(typeof(BoxCollider))]
[ExecuteInEditMode]
public class Square : MonoBehaviour{

    public float width = 1f;
    public float height = 1f;

    public bool flip = false;

    public bool rotate = false;

    private float _width = 1f;
    private float _height = 1f;

    [HideInInspector]
    public Vector3[] verts, norms;
    [HideInInspector]
    public Vector2[] uvs;
    [HideInInspector]
    public int[] tris;
    void Update()
    {
        if (width != _width || height != _height)
        {
            _width = width;
            _height = height;
            UpdateMesh();
        }
    }


    [ContextMenu("Update Mesh")]
    public void UpdateMesh()
    {
        //order 123,134
        verts = new Vector3[4];
        uvs = new Vector2[4];
        tris = new int[6] { 0, 1, 3, 1, 2, 3 };
        Vector3[] norms = new Vector3[4] {
            Vector3.forward,
            Vector3.forward,
            Vector3.forward,
            Vector3.back
        };
        if (rotate)
        {
            verts[0] = new Vector3(-width / 2.0f, -height / 2.0f, 0);
            verts[1] = new Vector3(+width / 2.0f, -height / 2.0f, 0);
            verts[2] = new Vector3(width / 2.0f, height / 2.0f, 0);
            verts[3] = new Vector3(-width / 2.0f, height / 2.0f, 0);
        }
        else
        {
            verts[0] = new Vector3(width / 2.0f, -height / 2.0f, 0);
            verts[1] = new Vector3(-width / 2.0f, -height / 2.0f, 0);
            verts[2] = new Vector3(-width / 2.0f, height / 2.0f, 0);
            verts[3] = new Vector3(width / 2.0f, height / 2.0f, 0);
        }

            if (flip)
            {
                uvs[0] = new Vector2(1, 0);
                uvs[1] = new Vector2(0, 0);
                uvs[2] = new Vector2(0, 1);
                uvs[3] = new Vector2(1, 1);
            }
            else
            {
                uvs[0] = new Vector2(0, 0);
                uvs[1] = new Vector2(1, 0);
                uvs[2] = new Vector2(1, 1);
                uvs[3] = new Vector2(0, 1);
            }

        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        if (!mesh)
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().sharedMesh = mesh;
        }

        Material mat = GetComponent<MeshRenderer>().sharedMaterial;
        if (!mat)
        {
            mat = new Material(Shader.Find("Particles/Alpha Blended"));
            GetComponent<MeshRenderer>().sharedMaterial = mat;
        }

        mesh.vertices = verts;
        mesh.normals = norms;
        mesh.uv = uvs;
        mesh.triangles = tris;
    }
}

