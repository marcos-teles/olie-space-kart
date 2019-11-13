using UnityEngine;
using System.Collections;

public class Playerbck : MonoBehaviour
{
    public float accel = 100f;
    public float maxSpeed = 120f;
    public float brakeSpeed = 60f;
    public float turnSpeed = 50f;
    public float rotationY;
    private float currentSpeed;
    public float hoverHeight = 3f;
    public float heightSmooth = 10f;
    public float rotationSmooth = 5f;
    private float swingSmooth;
    private Vector3 currentUp;
    private GameObject itemShild;
    public GameObject currentItem;
    public LayerMask mask;
    private float acelSide;
    public int move = 0;
   

    void Start()
    {

    }

    void Update()
    {        

        if (Input.GetKeyDown(KeyCode.C)&& currentItem !=null)
        {
            switch(currentItem.name)
            {
                case "item1":
                case "item2":
                case "item3":
                    Instantiate(currentItem, transform.position + transform.forward * 6, transform.rotation);
                    break;

                case "item4":
                    Instantiate(currentItem, transform.position - transform.forward * 6, transform.rotation);
                    break;

                case "item5":
                case "item6":
                    itemShild = Instantiate(currentItem, transform.position, transform.rotation) as GameObject;
                    itemShild.transform.parent = transform;
                    break;                              
            }
            currentItem = null;           
        }


    }


    public void MoveLeft()
    {
        move = 1;
    }

    public void MoveRigth()
    {
        move = -1;
    }

    public void stop()
    {
        move = 0;
    }

    void FixedUpdate()
    {
        swingSmooth += 0.00f;

        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += (currentSpeed >= maxSpeed) ? 0f : accel * Time.deltaTime;
        }
        else
        {
            if (currentSpeed > 0)
            {
                currentSpeed -= brakeSpeed * Time.deltaTime;
            }
            else
            {
                currentSpeed = 0f;
            }
        }


        swingSmooth += 0.000f;
        currentUp = transform.up;
        rotationY -= turnSpeed * Time.deltaTime * move;
        rotationY += turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");        
        transform.rotation = Quaternion.Euler(0, rotationY,0);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -currentUp, out hit, mask))
        {        
            Vector3 directionNormal = Vector3.Lerp(currentUp, hit.normal, Time.deltaTime * rotationSmooth);
            Quaternion rotationNormal = Quaternion.FromToRotation(transform.up, directionNormal);
            transform.rotation = Quaternion.Lerp(rotationNormal * transform.rotation, transform.rotation, 0.01f);
            transform.localPosition += currentUp * (hoverHeight - hit.distance) / hit.distance + new Vector3(0, (Mathf.Sin(swingSmooth) * 0.2f), 0);
        }


        RaycastHit hit2;
         if (Physics.Raycast(transform.position, transform.right, out hit2, 1.5f))
         {
            if (hit2.transform.tag != "Item Catch")
            {
                currentSpeed -= 5;
                if (currentSpeed < 20)
                {
                    currentSpeed = 0;
                    transform.localPosition += -transform.right * 1.5f;
                }
                else
                {
                    acelSide = currentSpeed* 0.008f;
                }
            
               
            }            
         }

         RaycastHit hit3;
         if (Physics.Raycast(transform.position, -transform.right, out hit3, 1.5f))
         {
            if (hit3.transform.tag != "Item Catch")
            {
                currentSpeed -= 5;
                if (currentSpeed < 20)
                {
                    currentSpeed = 0;
                    transform.localPosition += transform.right * 1.5f;
                }
                else
                {
                    acelSide = -currentSpeed* 0.008f;

                }
      
                
            }
        
         }


        RaycastHit hit4;

        if (Physics.Raycast(transform.position, transform.forward, out hit4, 3))
        {
            if(hit4.transform.tag != "Item Catch" )
            {
                currentSpeed -= 20;
                if (currentSpeed < 20)
                {
                    currentSpeed = 20;
                  
                }
             
                transform.position += -transform.forward * (currentSpeed * Time.deltaTime);
            }
           
        }

        transform.position += transform.forward * (currentSpeed * Time.deltaTime);
        if(acelSide<0)
        {
            acelSide += 0.01f;
        }
        else if (acelSide > 0)
        {
            acelSide -= 0.01f;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y-Mathf.Sin(acelSide*3)*12 , transform.rotation.eulerAngles.z + acelSide);
        transform.localPosition += -transform.right * acelSide;

  


    }

    void Turbo()
    {
        maxSpeed = 180f;
        accel = 160;
        Invoke("RestoreVel", 3);
    }

    void RestoreVel()
    {
        maxSpeed = 120f;
        accel = 100;
    }

  
}
