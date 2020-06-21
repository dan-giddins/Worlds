using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexureFace : MonoBehaviour
{
    public Material Material;
    public Mesh Mesh;

    // Start is called before the first frame update
    void Start()
    {
        //Mesh.Clear()
        //Mesh.vertices = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0) }; ;
        ////mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
        //Mesh.triangles = new int[] { 0, 1, 2 };
        ////face.AddComponent<MeshRenderer>();

        var mesh = new Mesh();

        var vertices = new Vector3[4];
        vertices[0] = new Vector3(0, 0, 0); //top-left
        vertices[1] = new Vector3(1, 0, 0); //top-right
        vertices[2] = new Vector3(0, -1, 0); //bottom-left
        vertices[3] = new Vector3(1, -1, 0); //bottom-right

        mesh.vertices = vertices;

        var triangles = new int[6] { 0, 1, 2, 3, 2, 1 };
        mesh.triangles = triangles;

        //this is also acceptable!
        //mesh.SetTriangleStrip(new int[4]{0,1,2,3}, 0);

        var uvs = new Vector2[4];
        uvs[0] = new Vector2(0, 1); //top-left
        uvs[1] = new Vector2(1, 1); //top-right
        uvs[2] = new Vector2(0, 0); //bottom-left
        uvs[3] = new Vector2(1, 0); //bottom-right

        mesh.uv = uvs;

        //Vector3[] normals = new Vector3[4] { Vector3.back, Vector3.back, Vector3.back, Vector3.back };
        //mesh.normals = normals;

        //you could also call this instead...
        mesh.RecalculateNormals();


        //grab our filter.. set the mesh
        var filter = GetComponent<MeshFilter>();
        filter.mesh = mesh;

        var renderer = GetComponent<Renderer>();
        renderer.material = Material;

    }

    private void Awake() => Mesh = GetComponent<MeshFilter>().mesh;
}
