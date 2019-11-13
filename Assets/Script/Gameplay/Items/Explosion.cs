using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);

        //Color color = GetComponent<Renderer>().material.color;
        //color.a -= 0.05f;
        GetComponent<Renderer>().material.color -= new Color(0, 0, 0, .05f);

        if (transform.localScale.x > 50)
        {
            Destroy(gameObject);
        }
	}
}
