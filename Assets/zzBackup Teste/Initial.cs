using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initial : MonoBehaviour {

    public GameObject[] screen1Elements;
    public GameObject[] screen2Elements;
    public GameObject[] screen3Elements;
    private GameObject[] currentElements;
    private GameObject currentOpition;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(AppearAll(screen1Elements));
    }

    //void Update()
    //{
    //    //if (Animator > 1 && !Animator.IsInTransition(0))
    //    if ( buttons[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime> 1 && buttons[0].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("UpScreen1") )
    //    {
    //        // Avoid any reload.
    //        print("caraio");
    //    }        
    //}

    public void SpaceGP()
    {
        print("spaceGP");
        DesappearAll(screen1Elements, screen1Elements[0].name);
        currentOpition = screen1Elements[0];
        screen1Elements[0].GetComponent<Animator>().Play("UpScreen1");
        currentElements = screen2Elements;
        StartCoroutine(AppearAll(screen2Elements));
    }

    public void Arcade()
    {
        print("arcade");
        DesappearAll(screen1Elements, screen1Elements[1].name);
        screen1Elements[1].GetComponent<Animator>().Play("UpScreen2");
    }

    public void Store()
    {
        print("store");
        DesappearAll(screen1Elements, screen1Elements[2].name);
        screen1Elements[2].GetComponent<Animator>().Play("UpScreen1");
    }

    public void SelectRacer()
    {
        print("select racer");
        DesappearAll(screen1Elements, screen1Elements[3].name);
        screen1Elements[3].GetComponent<Animator>().Play("UpScreen1");
    }

    public void Settings()
    {
        print("settings");
        DesappearAll(screen1Elements, screen1Elements[4].name);
        screen1Elements[4].GetComponent<Animator>().Play("UpScreen5");
    }

    public void Back()
    {
        currentOpition.GetComponent<Animator>().Play("DownScreen1");
        DesappearAll(currentElements, null);
        StartCoroutine(AppearAll(screen1Elements));
    }

    IEnumerator AppearAll(GameObject[] elements)
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].GetComponent<Animator>().Play("Appear");
            yield return new WaitForSeconds(0.1f);
        }

    }

    void DesappearAll(GameObject[] elements, string exception)
    {
        print(elements.Length);
        for (int i = 0; i < elements.Length; i++)
        {
            if (elements[i].name != exception)
            {
                elements[i].GetComponent<Animator>().Play("Desappear");
            }
        }
    }
}
