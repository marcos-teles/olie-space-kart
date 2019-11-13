using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {

    // Use this for initialization
    public GameObject racer;
    private Kart kart;
    private Animator anim;
    private Player player;
	void Start () {
        player = racer.GetComponent<Player>();
        kart = racer.GetComponent<Kart>();
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("direction", kart.turnDirection);
        if(player.enabled)
        {
            anim.SetBool("isPlayer", true);
        }
        else
        {
            anim.SetBool("isPlayer", false);
        }
	}
}
