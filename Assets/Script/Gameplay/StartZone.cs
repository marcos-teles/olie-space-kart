using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZone : MonoBehaviour {

    // Use this for initialization
    public float distanceFront;
    public float distanceSide;
    public float distanceZone;
    public float distanceDesl;
    public float center;
	void Start () {

        
        Manager.activeRacers();
        print("active Racer in start zone");

        for (int i = 0; i < Manager.racers.Length; i++)
        {
            Manager.racers[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            Manager.racers[i].GetComponent<Kart>().damageCount = 0;
            Manager.racers[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            Manager.racers[i].transform.position = transform.position + new Vector3(center + (i%2)*distanceSide, 1, -distanceZone - Mathf.Floor(i/2)*distanceFront + distanceDesl* (i % 2));            
            Manager.racers[i].GetComponent<RacerInfo>().posInRace = i+1;
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "Racer")
        {
            obj.GetComponent<RacerInfo>().ChangeLap();           
        }
    }

}
