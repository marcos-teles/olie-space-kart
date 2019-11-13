using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void ShowStore()
    {
        print("aa");
        InitialScreen.Desappear("BtnStore");
        GetComponent<UIController>().AppearAll();
    }

    public void Back()
    {
        InitialScreen.Appear("BtnStore");
        GetComponent<UIController>().DesappearAll();
    }
}
