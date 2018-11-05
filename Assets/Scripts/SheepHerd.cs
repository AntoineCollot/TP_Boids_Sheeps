using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHerd : MonoBehaviour {

    [Tooltip("List of all the sheeps in the herd")]
    [HideInInspector]
    public SheepBoid[] sheeps;

    public static SheepHerd Instance;

	void Awake () {
        Instance = this;
	}
	
	void Start () {
        //Find all sheeps in children
        sheeps = GetComponentsInChildren<SheepBoid>(false);
	}
}
