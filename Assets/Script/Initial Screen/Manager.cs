using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Manager : MonoBehaviour {
    public static Manager Instance;
    static public int premio;
    static public int track;
    static public GameObject[] racers;
    static public GameObject player;
    static public bool startRace;
    static public bool startCam;
    public static string nextScene;
    public static bool inCinematic;

    // Use this for initialization

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
        racers = GameObject.FindGameObjectsWithTag("Racer").OrderBy(go => go.name).ToArray(); //ver se funciona no Android
        //racers = GameObject.FindGameObjectsWithTag("Racer");
        LoadGame();
      
    }

    void Start()
    {
        Reset();
    }

    static void Reset()
    {
        inCinematic = false;
        startCam = false;
        startRace = false;
        premio = 1;
        track = 1;
    }

    // Update is called once per frame
    void Update () {
        //print(inCinematic);
    }

    static public void activeRacers()
    {
        for(int i=0; i< racers.Length; i++)
        {
            if(racers[i] == player)
            {
                racers[i].GetComponent<AI>().enabled = false;
                racers[i].GetComponent<Player>().enabled = true;
            }
            else
            {
                racers[i].GetComponent<AI>().enabled = true;
            }

           racers[i].GetComponent<Kart>().enabled = true;
            racers[i].GetComponent<Kart>().turnDirection = 0;
           racers[i].GetComponent<Kart>().currentItem = null;
           racers[i].GetComponent<AI>().target = null;
           racers[i].GetComponent<RacerInfo>().StartRace();
        }
    }

    static public void desactiveRacers()
    {
        for (int i = 0; i < racers.Length; i++)
        {
            racers[i].GetComponent<Player>().enabled = false;
            racers[i].GetComponent<AI>().enabled = false;
            racers[i].GetComponent<Kart>().enabled = false;
            //racers[i].GetComponent<RacerInfo>().
            GameObject copy = GameObject.Find(racers[i].name);
            Destroy(copy);            
        }

        Reset();
    }

    static public void SaveGame()
    {
        PlayerPrefs.SetString("Player", player.name);
    }

    static public void LoadGame()
    {
        if(PlayerPrefs.GetString("Player") == "")
        {
            player = racers[0];
        }
        else
        {
            player = GameObject.Find(PlayerPrefs.GetString("Player"));
        }
    }

    static public void playerToLastPos()
    {
        int indexplayer = System.Array.IndexOf(racers, player);
        racers[indexplayer] = racers[racers.Length - 1];
        racers[racers.Length - 1] = player;
    }

    static public void changeScene(string scene)
    {
        nextScene = scene;
        startFade();    
    }

    static public void startFade()
    {           
        Animator anim = GameObject.Find("Fade").GetComponent<Animator>();
        anim.Play("FadeOut");
    }


   

}
