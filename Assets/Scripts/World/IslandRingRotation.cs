using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandRingRotation : MonoBehaviour {

    public float rotationSpeed;
    public float verticalAmplitude;
    public float verticaleSpeed;
    Vector2 randomOffset;
    float noiseCoord;

	// Use this for initialization
	void Start () {
        randomOffset.x = Random.Range(0, 10000.0f);
        randomOffset.y = Random.Range(0, 10000.0f);
    }
	
	// Update is called once per frame
	void Update () {
        noiseCoord += Time.deltaTime * verticaleSpeed;
        Vector3 rot = transform.localEulerAngles;
        rot.x = (Mathf.PerlinNoise(noiseCoord, randomOffset.x)-0.5f) * verticalAmplitude;
        rot.z = (Mathf.PerlinNoise(noiseCoord, randomOffset.y) - 0.5f)* verticalAmplitude;
        transform.localEulerAngles = rot;

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
