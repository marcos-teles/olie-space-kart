using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpaceGPScreen : MonoBehaviour {

    // Use this for initialization
    public GameObject[] planets;
    public Sprite[] imgsTracks;
    public GameObject currentImgTrack;
    private int countPlanets;
  
	void Start () {
        countPlanets = 0;
        PlanetCam.target = planets[countPlanets];
        
	}
	
    public void ShowSpaceGP()
    {
        InitialScreen.Desappear("BtnSpaceGP");
        GetComponent<UIController>().AppearAll();
        Manager.track = 1;
    }

    public void Back()
    {
        InitialScreen.Appear("BtnSpaceGP");
        GetComponent<UIController>().DesappearAll();
    }

    public void StartGame()
    {
        Manager.playerToLastPos();
        Manager.changeScene("Gameplay Premio " + Manager.premio + " Track " + Manager.track);  
    }

    public void SelectLeft()
    {  
        ChangePlanet(-1);
       
    }

    public void SelectRight()
    {   
        ChangePlanet(1);
    }

    private void ChangePlanet(int direction)
    {
        countPlanets +=direction;

        if(countPlanets > planets.Length-1)
        {
            countPlanets = 0;
        }

        if(countPlanets <0) 
        {
            countPlanets = planets.Length - 1;
        }
     
        PlanetCam.target = planets[countPlanets];
        currentImgTrack.GetComponent<Image>().sprite = imgsTracks[countPlanets];

        Manager.premio = countPlanets + 1;
    }
}
