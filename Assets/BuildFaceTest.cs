using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildFaceTest : MonoBehaviour
{
	public GameObject Face;
	public Material Material;

	void Start()
	{
		var renderer = GetComponent<MeshRenderer>();
		renderer.material = Material;
	}
}
