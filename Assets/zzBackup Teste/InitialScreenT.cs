using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialScreenT : MonoBehaviour {
    public GameObject []screen1;
    public GameObject screen2;
	// Use this for initialization
    void Start()
    {

    }

	public void SpaceGP()
    {
        print("spaceGP");
        for(int i=1; i<screen1.Length; i++)
        {
            screen1[i].GetComponent<Animator>().Play("Desappear");
        }

        screen1[0].GetComponent<Animator>().Play("Up Screen");
        screen2.GetComponent<Animator>().Play("Screen2");

    }

    public void Arcade()
    {
        print("arcade");
    }

    public void Store()
    {
        print("store");
    }

    public void SelectRacer()
    {
        print("select racer");
    }

    public void Settings()
    {
        print("settings");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");      
    }
}
