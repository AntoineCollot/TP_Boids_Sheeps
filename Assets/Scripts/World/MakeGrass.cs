using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MakeGrass : MonoBehaviour {

    [Header("Main Settings")]

    [SerializeField]
    Mesh originalMesh;

    public float areaRadius;

    public float density;

    public float grassSize = 1;

    [Header("Randomization")]

    [Range(0, 1)]
    public float randomRotation;

    [Range(0,1)]
    public float randomSize;

    public Mesh result;

    [ContextMenu("Build Mesh")]
    public void BuildMesh()
    {
        int meshCount = (int)(density * 2 * Mathf.PI * areaRadius * areaRadius);
        print("Area : " + 2 * Mathf.PI * areaRadius * areaRadius);
        print(meshCount);
        print(meshCount * 9);
        CombineInstance[] combineInstances = new CombineInstance[meshCount];
        for (int i = 0; i < meshCount; i++)
        {
            combineInstances[i].mesh = originalMesh;

            //Find a random position in the circle.
            //We do this this way instead of getting a random direction and random distance so we get an even density across the area, otherwise they get stacked at the center
            Vector3 randomPosition;
            do
            {
                randomPosition = new Vector3(Random.Range(-areaRadius, areaRadius), 0, Random.Range(-areaRadius, areaRadius));
            } while (randomPosition.magnitude > areaRadius);


            Matrix4x4 matrix = Matrix4x4.TRS(randomPosition, Quaternion.Slerp(Quaternion.identity,Random.rotation,randomRotation), Vector3.one * grassSize * Random.Range(1- randomSize,1+ randomSize));
            combineInstances[i].transform = matrix;
        }

        result = new Mesh();
        result.CombineMeshes(combineInstances, true, true);

        GetComponent<MeshFilter>().mesh = result;
        SaveMesh(result);
    }

    public void SaveMesh(Mesh mesh)
    {
        AssetDatabase.CreateAsset(mesh, "Assets/generatedMesh.asset");
        AssetDatabase.SaveAssets();
    }

    Mesh CopyMesh(Mesh mesh)
    {
        Mesh newMesh = new Mesh();
        newMesh.vertices = mesh.vertices;
        newMesh.normals = mesh.normals;
        newMesh.uv = mesh.uv;
        newMesh.triangles = mesh.triangles;
        newMesh.tangents = mesh.tangents;
        newMesh.colors = mesh.colors;
        return newMesh;
    }
}
