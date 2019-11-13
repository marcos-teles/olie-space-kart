using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCam : MonoBehaviour {

	// Use this for initialization
    public static GameObject target;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(target != null)
        {
            transform.LookAt(target.transform.position);
        }        
	}
}
