using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialScreen : MonoBehaviour {

    // Use this for initialization
    static public UIController control;

	void Start () {
        control = GetComponent<UIController>();
        if (Manager.nextScene == "Initial Screen")
        {
            InitialScreen.control.AppearAll(0.1f);
            GameObject.Find("OpenScreen").transform.localScale = Vector3.zero;
        }
        //control.AppearAll(0.1f);
    }

    static public void Desappear(string toUp)
    {       
        control.DesappearAll();
        GameObject optionSelec = GameObject.Find(toUp);
        optionSelec.GetComponent<Animator>().Play("UpScreen");

    }

    static public void Appear(string toDown)
    {
        control.AppearAll();
        GameObject optionSelec = GameObject.Find(toDown);
        optionSelec.GetComponent<Animator>().Play("DownScreen");

    }
}
