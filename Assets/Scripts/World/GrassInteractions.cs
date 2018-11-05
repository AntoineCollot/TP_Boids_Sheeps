using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassInteractions : MonoBehaviour {

    [SerializeField]
    Material mat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector4[] pos = new Vector4[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 childPos = transform.GetChild(i).position;
            pos[i] = new Vector4(childPos.x, childPos.z,0,0);
        }

        mat.SetInt("_BenderCount", pos.Length);
        mat.SetVectorArray("_BenderPositions", pos);
	}
}
