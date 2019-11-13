using UnityEngine;
using System.Collections;

public class RacerInfo : MonoBehaviour {
    public GameObject Instance;
    public int checkPoints;
    public int posInRace;
    public int lap;
    public Sprite avatar;
    public string nameRacer;
    public int indexRacer;
    public int points;  
    private int currentCheck;
    private int lastCheck;
    private bool isReverse;
    private bool sensorFirstHit;
    private int teste = 0;

    
    public LayerMask track;

    // Use this for initialization
    

    void Start () {        
        DontDestroyOnLoad(gameObject);
        points = 0;        
    }

    // Update is called once per frame
    public void StartRace()
    {       
        sensorFirstHit = false;
        lap = 0;

      
    }

    void Update () {
        if(Manager.startRace)
        {
            
            SensorPosition();
        }         
    }   

    void SensorPosition()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 100,track))
        {
            if (!sensorFirstHit)
            {
                checkPoints = hit.triangleIndex;
                lastCheck = hit.triangleIndex;
                currentCheck = hit.triangleIndex;
                sensorFirstHit = true;
                //print("start");
                
            }
            else
            {
                currentCheck = hit.triangleIndex;
              
                int variation = Mathf.Clamp(currentCheck - lastCheck, -15, 15);
                if(variation == -15)
                {
                    variation = 0;
                }
                checkPoints += variation;
                if (variation > 0)
                {
                    isReverse = false;
                }
                else if (variation < 0)
                {
                    isReverse = true;
                }

                lastCheck = currentCheck;
            }

          
        }
      

      
        Debug.DrawRay(transform.position , -transform.up * 100, Color.blue);


        Vector3 rayDirection;

        for (int i = 0; i < Manager.racers.Length; i++)
        {
            if (Manager.racers[i] != gameObject)
            {

                if (posInRace > Manager.racers[i].GetComponent<RacerInfo>().posInRace && checkPoints >= Manager.racers[i].GetComponent<RacerInfo>().checkPoints && lap >= Manager.racers[i].GetComponent<RacerInfo>().lap)
                {
                    rayDirection = Manager.racers[i].transform.position - transform.position;


                    if (Vector3.Angle(Manager.racers[0].transform.forward, rayDirection) > 90)
                    {
                        int temp = Manager.racers[i].GetComponent<RacerInfo>().posInRace;
                        Manager.racers[i].GetComponent<RacerInfo>().posInRace = posInRace;
                        posInRace = temp;
                    }

                }
            }
        }
    }

    public void ChangeLap()
    {
        if (lap == 0)
        {          
            checkPoints = 0;
            lap = 1;           
        }
        else 
        {
            lap = Mathf.CeilToInt(checkPoints * 1f / RaceTrack.triangleCount *1f) + 1;
        }      
    }
}

