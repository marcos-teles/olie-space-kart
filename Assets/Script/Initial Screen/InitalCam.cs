using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitalCam : MonoBehaviour {

    public float sideDistance;
    public float frontDistance;
    public static float upDistance;
    private Vector3 posTolook;
    private Vector3 playerPos;

    // Use this for initialization
    void Start () {
        
        for (int i = 0; i < Manager.racers.Length; i++)
        {
            Manager.racers[i].transform.position = Manager.racers[i].transform.position + new Vector3(10 * i, 0, 0);
            Manager.racers[i].GetComponent<RacerInfo>().indexRacer = i;
        }
        upDistance = 0;

        playerPos = Manager.player.transform.position;
        transform.position = playerPos + new Vector3(-2, 0, -3);
        posTolook = new Vector3(playerPos.x - sideDistance, playerPos.y + upDistance, playerPos.z - frontDistance) ;
        transform.position = Vector3.Slerp(transform.position, posTolook, 0.2f);

       

    }
	
	// Update is called once per frame
	void Update () {
        if(Manager.startCam)
        {
            playerPos = Manager.player.transform.position;
            posTolook = new Vector3(playerPos.x - sideDistance, playerPos.y + upDistance, playerPos.z - frontDistance);
            transform.position = Vector3.Slerp(transform.position, posTolook, 0.3f);
        } 
    }
}
