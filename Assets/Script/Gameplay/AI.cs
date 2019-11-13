using UnityEngine;
using System.Collections;

enum Direction : int
{
    Front = 1,
    Back = -1
}

public class AI : MonoBehaviour
{
    public GameObject target;    
    public float distanceWall;
    public LayerMask trackLeft;
    public LayerMask trackRight;  
    private float newDistanceWall;
    public Kart kart;
    public float teste1;


    // Use this for initialization
    void Start()
    {
        kart = GetComponent<Kart>();
        kart.acelKart = true;
        distanceWall = ObjDistanceWall(gameObject);
        RandomDistance();
        teste1 = 1;             
    }

    // Update is called once per frame
    void Update()
    {

        if (kart.currentItem == null)
        {
            FindTarget(RaceTrack.itemCatchs, Direction.Front, 150);
            if (target != null)
            {
                SetDistanceWall(ObjDistanceWall(target));
               
                Vector3 rayDirection = target.transform.position - transform.position;
                if (Vector3.Angle(transform.forward, rayDirection) > 20)
                {
                    target = null;
                }
                else
                {
                    transform.LookAt(target.transform.position);
                }
            }
        }
        else if (kart.ItemUseMode() == "Frontal")
        {
            FindTarget(Manager.racers, Direction.Front, 60);
            if (target != null)
            {
                SetDistanceWall(ObjDistanceWall(target));
                Vector3 rayDirection = target.transform.position - transform.position;
                if (Vector3.Angle(transform.forward, rayDirection) > 20)
                {
                    target = null;
                }
            }
        }
        else if (kart.ItemUseMode() == "Back")
        {
            FindTarget(Manager.racers, Direction.Back, 20);
            if (target != null)
            {
                Vector3 rayDirection = target.transform.position - transform.position;
                //if (Vector3.Angle(transform.forward, rayDirection) > 20)//verificar se alvo não passou pra frente;
                //{
                //    target = null;
                //}
            }
        }
        else if (kart.ItemUseMode() == "Shield")
        {
            int posInRace = GetComponent<RacerInfo>().posInRace;
            Invoke("UseItem", 1);
            /*if (posInRace > 2 && posInRace < 5)
            {
                Invoke("UseItem", 5);
            }
            else if (posInRace > 5)
            {
                Invoke("UseItem", 1);
            }*/
        }


        if (target != null && kart.currentItem != null)
        {
            Invoke("UseItem", 2);
        }

        if (target == null)
        {
            SetDistanceWall(newDistanceWall);
        }
        //// debug //////////////////////

        if (target != null)
        {
            Vector3 rayDirection = target.transform.position - transform.position;
            Debug.DrawRay(transform.position, rayDirection, Color.green);
        }

        Vector3 rot = Quaternion.AngleAxis(46, transform.up) * transform.forward;
        Debug.DrawRay(transform.position, rot * 10, Color.yellow);
        Vector3 rot2 = Quaternion.AngleAxis(-46, transform.up) * transform.forward;
        Debug.DrawRay(transform.position, rot2 * 10, Color.yellow);

        if (Input.GetKey(KeyCode.Space))
        {

        }

        //////////////////////////////////
        Turn();

    }

    

    void Turn()
    {

        float powerRight = 0;
        float powerLeft = 0;

        Vector3 rot = Quaternion.AngleAxis(-45, transform.up) * transform.forward;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, rot, out hit, 100, trackLeft))
        {          
            powerRight = (distanceWall * 3.3f) * teste1 / hit.distance;                
        }
        else
        {
            powerRight = 0;
        }

        Vector3 rot2 = Quaternion.AngleAxis(45, transform.up) * transform.forward;
        RaycastHit hit2;
        if (Physics.Raycast(transform.position, rot2, out hit2, 100, trackRight))
        {          
            powerLeft = -(100 - distanceWall * 3.3f)*teste1 / hit2.distance;
        }
        else
        {
            powerLeft = 1;
        }

        kart.turnDirection = powerRight + powerLeft;

        /*if(GetComponent<RacerInfo>().nameRacer == "Gilbor")
        {
            print(kart.turnDirection);
        }*/
       
    }

   

    void UseItem()
    {
        kart.UseItem();
    }

    void RandomDistance()
    {
        if (target == null)
        {
            newDistanceWall = Random.Range(5, 25);


            //if(debug)
            //{
            //    print("teste");
            //    print(distanceWall);
            //}


            //maxSpeed = 100 + 0.2f * distanceWall + Random.Range(1, 2) * levelDificult;

        }

        Invoke("RandomDistance", Random.Range(1, 15));
    }

    void FindTarget(GameObject[] targets, Direction dir, float distance)
    {
        if (target == null)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] != gameObject)
                {
                    if (RayCanSee(targets[i], dir, distance))
                    {
                        target = targets[i];
                    }
                }
            }
        }
    }

    bool RayCanSee(GameObject obj, Direction direction, float distance)
    {
        int angleVision;
        if (direction == Direction.Front)
        {
            angleVision = 60;
        }
        else
        {
            angleVision = 60;
        }

        Vector3 rayDirection = obj.transform.position - transform.position;
        //Debug.DrawRay(transform.position, rayDirection, Color.blue);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDirection, out hit, distance))
        {
            return (hit.collider.gameObject == obj && Vector3.Angle((int)direction * transform.forward, rayDirection) < angleVision);
        }
        else
        {
            return false;
        }
    }    

    void SetDistanceWall(float distance)
    {
        distanceWall = Mathf.Lerp(distanceWall, distance, 0.05f);
    }

    float ObjDistanceWall(GameObject obj)
    {
        RaycastHit hit;
        if (Physics.Raycast(obj.transform.position, -obj.transform.right, out hit, 100, trackLeft))
        {
            return Vector3.Distance(hit.point, obj.transform.position);
        }
        else
        {
            return 0;
        }
    }
}

