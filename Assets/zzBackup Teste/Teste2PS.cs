using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste2PS : MonoBehaviour {

    // Use this for initialization
    private int life;
	void Start () {
        life = 5;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.J))
        {
            life--;
            print(life);
        }
    }
}
