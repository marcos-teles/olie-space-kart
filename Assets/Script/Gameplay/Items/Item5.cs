using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item5 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Item")
        {
            Destroy(transform.gameObject);
            Destroy(collision.collider.gameObject);           
        }
    }
}
