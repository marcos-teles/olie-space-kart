using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;





public class Hud : MonoBehaviour {

    // Use this for initialization
   
    public GameObject playerInfo;
    public GameObject textPos;
    public GameObject textLap;
    public GameObject[] racersEdge;
    public GameObject lightPainel;
    public GameObject[] lights;
    public GameObject finalRacePainels;
    public GameObject[] finalRaceInfo;   
    private GameObject[] RacersInOrder;
    private bool endScreenActive;
    
    private int contLights;

    public void StartHud()
    {
        playerInfo.GetComponent<UIController>().AppearAll();
        contLights = 0;
        StartCoroutine("ChangeLights");
        endScreenActive = false;
        for (int i = 0; i < racersEdge.Length; i++)
        {
            racersEdge[i].GetComponent<Image>().sprite = Manager.racers[i].GetComponent<RacerInfo>().avatar;
        }
        //ShowFinalRace();     
    }

    // Update is called once per frame
    void Update()
    {       
        HudInfo();
        RecersEdgeUpdate();
    }

    void HudInfo()
    {
        textPos.GetComponent<Text>().text = Manager.player.GetComponent<RacerInfo>().posInRace + "º.";

        if (Manager.player.GetComponent<RacerInfo>().lap <= 1)
        {
            textLap.GetComponent<Text>().text = "1/3";
        }
        else if(Manager.player.GetComponent<RacerInfo>().lap < 4)
        {
            textLap.GetComponent<Text>().text = Manager.player.GetComponent<RacerInfo>().lap + "/3";
        }
        else if(!endScreenActive)
        {
            SortRacers();
            ShowFinalRace();
            Manager.player.GetComponent<Player>().enabled = false;
            Manager.player.GetComponent<AI>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            SortRacers();
            ShowFinalRace();
            Manager.player.GetComponent<Player>().enabled = false;
            Manager.player.GetComponent<AI>().enabled = true;
        }       
    }

    void ShowFinalRace()
    {
        playerInfo.GetComponent<UIController>().DesappearAll();
        finalRacePainels.GetComponent<UIController>().AppearAll(0.1f);      
    }

    void RecersEdgeUpdate()
    {
        for (int i = 0; i < racersEdge.Length; i++)
        {
            if(Manager.racers[i].GetComponent<RacerInfo>().lap > 0)
            {
                float proportionalPosX = Mathf.Clamp((Manager.racers[i].GetComponent<RacerInfo>().checkPoints - (Manager.racers[i].GetComponent<RacerInfo>().lap-1)* RaceTrack.triangleCount) * (980f / RaceTrack.triangleCount), 0, 980);
             
                racersEdge[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(proportionalPosX, 0);
                racersEdge[i].transform.SetSiblingIndex(Manager.racers.Length - Manager.racers[i].GetComponent<RacerInfo>().posInRace);
            }         
        }
    }

    void SortRacers()
    {
        //Manager.startRace = false;
        endScreenActive = true;
        GameObject temp;


        for (int i = 0; i < Manager.racers.Length; i++)
        {
            for (int sort = 0; sort < Manager.racers.Length - 1; sort++)
            {
                if (Manager.racers[sort].GetComponent<RacerInfo>().posInRace > Manager.racers[sort + 1].GetComponent<RacerInfo>().posInRace)
                {
                    temp = Manager.racers[sort + 1];
                    Manager.racers[sort + 1] = Manager.racers[sort];
                    Manager.racers[sort] = temp;
                }
            }
        }



        for (int i = 0; i < Manager.racers.Length; i++)
        {           
            RacerInfo info = Manager.racers[i].GetComponent<RacerInfo>();
            int points = 9 - i * 3;
            if(points == 0)
            {
                points = 1;
            }
            else if(points <0)
            {
                points = 0;
            }
            info.points += points;

            finalRaceInfo[i*2].GetComponent<Image>().sprite = info.avatar;
            finalRaceInfo[i*2+1].GetComponent<Text>().text = info.posInRace + ". " + info.nameRacer +" "+ info.points;
        }
    }

    IEnumerator ChangeLights()
    {
        yield return new WaitForSeconds(1f);
        lightPainel.GetComponent<Animator>().Play("Appear");
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < 3; i++)
        {
            lights[i].GetComponent<Animator>().Play("Turn Red");
            yield return new WaitForSeconds(1f);
        }       
        Manager.startRace = true;
        for (int i = 0; i < 3; i++)
        {
            lights[i].GetComponent<Animator>().Play("Turn Green");
        }
        yield return new WaitForSeconds(1f);
        lightPainel.GetComponent<Animator>().Play("Desappear");   
    }

    public void Next()
    {
        print("next");
        string scene;
        Manager.startRace = false;
        if (Manager.track < 2)
        {
            Manager.track++;           
            System.Array.Reverse(Manager.racers);
            scene = "Gameplay Premio " + Manager.premio + " Track " + Manager.track;

        }
        else
        {            
            scene = "Initial Screen";
            Manager.desactiveRacers();
            Manager.startCam = true;
        }
        print(scene);       
        SceneManager.LoadScene(scene);
        Manager.changeScene(scene);
       
    }

    public void StartAcel()
    {
        Manager.player.GetComponent<Player>().StartAcel();
    }

    public void StopAcel()
    {
        Manager.player.GetComponent<Player>().StopAcel();
    }

    public void StartTR()
    {
        Manager.player.GetComponent<Player>().StartTR();
    }

    public void StopTR()
    {
        Manager.player.GetComponent<Player>().StopTR();
    }

    public void StartTL()
    {
        Manager.player.GetComponent<Player>().StartTL();
    }

    public void StopTL()
    {
        Manager.player.GetComponent<Player>().StopTL();
    }

    public void UseI()
    {
        Manager.player.GetComponent<Player>().UseI();
    }


}
