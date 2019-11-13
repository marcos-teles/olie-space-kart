using UnityEngine;
using System.Collections;

public class Item6 : MonoBehaviour
{


    // Use this for initialization
    private Kart kart;

    void Start()
    {
        kart = transform.parent.GetComponent<Kart>();
        StartCoroutine("EndTurbo");
    }

    // Update is called once per frame
    void Update()
    {
        kart.speed = 130;
    }

    IEnumerator EndTurbo()
    {
        yield return new WaitForSeconds(5f);
        kart.speed = 80;
        Destroy(transform.gameObject);
    }
}
