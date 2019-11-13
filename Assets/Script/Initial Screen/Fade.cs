using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour {
    public static Fade Instance;   
    static private Animator anim;
    private GameObject openScreen;

    // Use this for initialization
    void Start()
    {        
        anim = GetComponent<Animator>();
    }
   
    public void EndAnimation()
    {
       
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FadeOut"))
        {
            Scene scene = SceneManager.GetActiveScene();            
            print(scene.name);
            if (scene.name != "Initial Screen")
            {
                if (Manager.inCinematic == true)
                {
                    print("cinematic");
                    anim.Play("FadeIn");
                    Cinematic.ChangeEfect();
                }
                else
                {
                    print("closeCinemetic");
                    anim.Play("FadeIn");
                    GetComponent<Button>().enabled = false;
                    transform.localScale = Vector3.zero;
                    Cinematic.startGame();
                }
            }
            else
            {
                if (Manager.nextScene != null)
                {                    
                    if (Manager.nextScene == "Initial Screen")
                    {
                        Manager.desactiveRacers();
                    }
                    SceneManager.LoadScene(Manager.nextScene);
                }
                else
                {
                    GameObject.Find("OpenScreen").transform.localScale = Vector3.zero;
                    InitialScreen.control.AppearAll(0.1f);
                    Manager.startCam = true;
                    anim.Play("FadeIn");
                }
            }                    
        }
    }

    static public void InitialFade()
    {
        anim.Play("FadeOut");
    }


    public void InitFade()
    {
        anim.Play("FadeOut");
    }

}
