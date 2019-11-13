using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleRacing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void ShowSingleRacing()
    {
        InitialScreen.Desappear("BtnSingleRacing");
        GetComponent<UIController>().AppearAll();
    }

    public void Back()
    {
        InitialScreen.Appear("BtnSingleRacing");
        GetComponent<UIController>().DesappearAll();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay Premio " + Manager.premio + " Track " + Manager.track);
    }

    public void SelectPremio1()
    {
        Manager.premio = 1;
        Manager.track = 1;
    }

    public void SelectPremio2()
    {
        Manager.premio = 2;
        Manager.track = 1;
    }
}
