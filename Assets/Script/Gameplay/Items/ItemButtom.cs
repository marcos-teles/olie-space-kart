using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtom : MonoBehaviour {

    private Kart playerKart;   
    public Sprite []imgsItens;
    private bool startedCorrotine;
    private bool inTrasition;
    private Sprite currentImg;
	// Use this for initialization
	void Start () {      
        playerKart = Manager.player.GetComponent<Kart>();
    }
	
	// Update is called once per frame
	void Update () {
		if(playerKart.currentItem != null)
        {
            //GetComponent<Image>().sprite = playerKart.currentItem.GetComponent<Image>().sprite;
            if(!startedCorrotine)
            {
                startedCorrotine = true;
                StartCoroutine("ChangeImg");
                inTrasition = true;
            }
        }
        else
        {
            GetComponent<Image>().sprite = imgsItens[imgsItens.Length-1];
        }
	}

    IEnumerator ChangeImg()
    {
        float seconds = 0.1f;
        for(int j=0; j<5; j++)
        {
            for (int i = 0; i < imgsItens.Length; i++)
            {                
                GetComponent<Image>().sprite = imgsItens[i];
                yield return new WaitForSeconds(seconds);
            }
        }

        GetComponent<Image>().sprite = playerKart.currentItem.GetComponent<Image>().sprite;
        inTrasition = false;       
    }

    public void UseItem()
    {
        if(inTrasition == false)
        {
            playerKart.UseItem();
            startedCorrotine = false;
        }
    }
}
