using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HudTrack : MonoBehaviour {
    public GameObject player;
    private Text pos;
    private Text lap;
    private RacerInfo playerInfo;
    
    

	// Use this for initialization
	void Start () {
        playerInfo = player.GetComponent<RacerInfo>();
        pos = GameObject.Find("Position").GetComponent<Text>();
        lap = GameObject.Find("Lap").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        //print(player.GetComponent<RacerInfo>().posInRace);
        pos.text = playerInfo.posInRace + "";

        if (playerInfo.lap <= 0)
        {
            lap.text = "0/3";
        }
        else
        {
            lap.text = playerInfo.lap + "/3";
        }
    }
}
