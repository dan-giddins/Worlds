using UnityEngine;

public class BuildFaces : MonoBehaviour
{
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
		var gameObject = Instantiate(new GameObject(), transform);
		gameObject.name = $"triangle_{i}";
		gameObject.AddComponent<MeshFilter>();
		gameObject.AddComponent<MeshRenderer>();
		var triangleMesh = gameObject.GetComponent<MeshFilter>().mesh;
		triangleMesh.Clear();
		triangleMesh.vertices = vertices;
		triangleMesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
		triangleMesh.triangles = new int[] { 0, 1, 2 };
	}
}
