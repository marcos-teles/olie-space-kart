using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRacer : MonoBehaviour {
    private int cont;
    GameObject currentPlayer;
    public void ShowSelectRace()
    {
        currentPlayer = Manager.player;
        cont = currentPlayer.GetComponent<RacerInfo>().indexRacer;
        InitialScreen.Desappear("BtnSelectRacer");
        GetComponent<UIController>().AppearAll();
    }

    public void Back()
    {
        Manager.player = currentPlayer;
        InitialScreen.Appear("BtnSelectRacer");
        GetComponent<UIController>().DesappearAll();
    }

    public void ChangeRight()
    {
        cont++;
        if (cont > 7)
        {
            cont = 0;
        }
        Manager.player = Manager.racers[cont];
    }

    public void ChengeLeft()
    {
        cont--;
        if (cont < 0)
        {
            cont = 7;
        }
        Manager.player = Manager.racers[cont];
    }

    public void Select()
    {
        Manager.SaveGame();
        InitialScreen.Appear("BtnSelectRacer");
        GetComponent<UIController>().DesappearAll();        
    }

}
