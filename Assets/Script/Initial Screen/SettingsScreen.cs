using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScreen : MonoBehaviour {

    void Start()
    {

    }

    public void ShowSettings()
    {
        InitialScreen.Desappear("BtnSettings");
        GetComponent<UIController>().AppearAll();
    }

    public void Back()
    {
        InitialScreen.Appear("BtnSettings");
        GetComponent<UIController>().DesappearAll();
    }


}
