using System.IO;
using UnityEngine;

public class BuildFaces : MonoBehaviour
{
	public GameObject Face;

	void Start()
	{
		var mesh = GetComponent<MeshFilter>().mesh;
		var triangles = mesh.triangles;
		var vertices = mesh.vertices;
		for (var i = 0; i < triangles.Length / 3; i++)
		{
			CreateFaceObject(
				i,
				new Vector3[]
				{
					vertices[triangles[i * 3]],
					vertices[triangles[i * 3 + 1]],
					vertices[triangles[i * 3 + 2]]
				});
		}
	}

	private void CreateFaceObject(int i, Vector3[] vertices)
	{
		var face = Instantiate(Face, transform);
		face.name = $"triangle_{i}";
		face.AddComponent<MeshFilter>();
		var mesh = face.GetComponent<MeshFilter>().mesh;
		mesh.vertices = vertices;
		mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
		mesh.triangles = new int[] { 0, 1, 2 };
		face.AddComponent<MeshRenderer>();
		var renderer = face.GetComponent<MeshRenderer>();
		var rand = new System.Random();
		var resourcesPath = $@"{Directory.GetCurrentDirectory()}\Assets\Resources\";
		var materials = Directory.GetFiles($"{resourcesPath}Materials", "*.mat");
		var materialPath = materials[rand.Next(materials.Length)];
		var path = materialPath.Replace(resourcesPath, "");
		System.Console.WriteLine(path);
		renderer.material = Resources.Load(path, typeof(Material)) as Material;
	}
}
