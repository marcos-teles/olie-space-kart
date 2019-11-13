using UnityEngine;
using System.Collections;

public class Fake : MonoBehaviour {

    // Use this for initialization
    public GameObject guidePilot;
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.Slerp(transform.position, guidePilot.transform.position, 0.05f);
        transform.transform.rotation = guidePilot.transform.rotation;
        transform.LookAt(guidePilot.transform);
    }
}
