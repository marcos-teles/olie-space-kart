using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour {

    // Use this for initialization
    public GameObject camCinematic;
    public GameObject camGamePlay;
    public GameObject hud;
    static public GameObject cam1;
    static public GameObject cam2;
    static public GameObject sHud;
    static public GameObject pivot;
    private float countTime;

	void Start () {
        Manager.inCinematic = true;
        cam1 = camCinematic;
        cam2 = camGamePlay;
        sHud = hud;
        pivot = gameObject;
	}
	
	// Update is called once per frame
	void Update () {       

        if(Manager.inCinematic)
        {
            transform.Rotate(0, 0.5f, 0);
            countTime += Time.deltaTime;
            if(countTime > 5)
            {
                countTime = 0;
                ChangeCinematic();
            }
        }
	}

    void ChangeCinematic()
    {
        print("change");
        Fade.InitialFade();
       
    }

    static public void ChangeEfect()
    {
        pivot.transform.position = Manager.player.transform.position;
        cam1.transform.localPosition = Manager.player.transform.right * 5;
        cam1.transform.LookAt(Manager.player.transform.position);
    }

    public void CloseCinematic()
    {     
        Manager.inCinematic = false;
        //print("close " + Manager.inCinematic);
        Fade.InitialFade();      
    }

    static public void startGame()
    {
        print("start");      
        cam1.GetComponent<Camera>().enabled = false;
        cam2.GetComponent<Camera>().enabled = true;
        sHud.GetComponent<Hud>().StartHud();   
    }
}
