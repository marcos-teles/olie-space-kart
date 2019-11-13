using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject[] elements;    

    private IEnumerator SequenceAppear(float delay)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            yield return new WaitForSeconds(delay);
            elements[i].GetComponent<Animator>().Play("Appear");          
        }
    }

    public void AppearAll(float delay)
    {
        StartCoroutine(SequenceAppear(delay));      
    }

    public void AppearAll()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].GetComponent<Animator>().Play("Appear");           
        }
    }

    public void DesappearAll()
    {        
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].GetComponent<Animator>().Play("Desappear");
        }
    }
}

