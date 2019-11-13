using UnityEngine;
using System.Collections;

public class Item3 : MonoBehaviour {

   
    public float currentSpeed;
    private Vector3 currentUp;
    public float distanceWall;
    public LayerMask trackLeft;
    public GameObject target;
    public float cont;

    void Start()
    {
        cont = 0;
        distanceWall = ObjDistanceWall(gameObject);
    }

    void Update()
    {
        FindTarget(Manager.racers, Direction.Front, 100);
        if (target != null)
        {
            distanceWall = ObjDistanceWall(target);
            print("com alvo");
        }
        else
        {
            cont += Time.deltaTime;
            print("sem alvo");
            if (cont > 2)
            {
                target = null;
                cont = 0;
            }
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit2;
        if (Physics.Raycast(transform.position, -transform.right, out hit2, 100, trackLeft))
        {
            Quaternion rotationToTrack = Quaternion.FromToRotation(transform.right, hit2.normal);
            transform.rotation = rotationToTrack * transform.rotation;
            transform.position += transform.right * (distanceWall - hit2.distance) * 0.1f;

            Debug.DrawRay(transform.position, -transform.right*100, Color.blue);
        }
       
        transform.position += transform.forward * (currentSpeed * Time.deltaTime);
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
