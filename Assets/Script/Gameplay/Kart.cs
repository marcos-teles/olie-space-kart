using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart : MonoBehaviour {

    
    public GameObject currentItem;
    public GameObject itemShield;
    public bool acelKart;
    public float turnDirection;
    public float turnLeft;
    public float turnRight;
    public float speed;
    public float speedTurn;
    public bool activeItem;
    public int damageCount;
    private Rigidbody kartBody;
   

    // Use this for initialization
    void Start () {
        acelKart = false;
        turnDirection = 0;
        speed = 80;
        speedTurn = 2;
        kartBody = GetComponent<Rigidbody>();
	}
	

    void FixedUpdate()
    {
        if (Manager.startRace)
        {            
            if (damageCount == 0)
            {
                Acelerate();
                Turn();
            }
            else
            {
                Damage();
            }
        }
        //Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
    }

    void Acelerate()
    {
        if (acelKart)
        {
            kartBody.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.Acceleration);
        }
        else
        {
            if (kartBody.velocity.magnitude > 20)
                kartBody.AddRelativeForce(new Vector3(0, 0, Mathf.Lerp(speed, 0, 0.5f)), ForceMode.Acceleration);

        }
    }

    void Turn()
    {
        speedTurn = 2;
        if (kartBody.velocity.magnitude < 6)
        {
            speedTurn = 4;
        }
        
        kartBody.AddRelativeTorque(new Vector3(0, turnDirection * speedTurn*5, 0));
       
      

        //kartBody.AddRelativeTorque(new Vector3(0, turnLeft, 0));
        //kartBody.AddRelativeTorque(new Vector3(0, turnRight, 0));

    }

    void Damage()
    {
        if(gameObject == Manager.player)
        {
            CamGame.moveCam = false;
        }
        
        kartBody.drag = 0.5f;
        if (damageCount < 30)
        {
            kartBody.AddRelativeTorque(new Vector3(0, 4, 0));
            kartBody.AddRelativeForce(new Vector3(0, 2, 0), ForceMode.Acceleration);
        }
        else if (damageCount > 30 && damageCount < 90)
        {
            kartBody.AddRelativeTorque(new Vector3(0, -6, 0));
            kartBody.AddRelativeForce(new Vector3(0, -2, 0), ForceMode.Acceleration);
        }
        else
        {
            kartBody.AddRelativeTorque(new Vector3(0, 10, 0));
        }

        if (damageCount < 180)
        {
            damageCount++;
        }
        else
        {
            kartBody.drag = 2f;
            damageCount = 0;
            CamGame.moveCam = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
            kartBody.AddExplosionForce(300, contact.point, 1);
        }

        if (collision.collider.tag == "Item")
        {
            Destroy(collision.collider.gameObject);
            damageCount = 1;
        }
    }

    public string ItemUseMode()
    {
        string useMode = " ";
        switch (currentItem.name)
        {
            case "item1":
            case "item2":
            case "item3":
                useMode = "Frontal";
                break;

            case "item4":
                useMode = "Back";
                break;

            case "item5":
            case "item6":
                useMode = "Shield";

                break;
        }
        return useMode;
    }

    public void UseItem()
    {
        AI AIRacer = GetComponent<AI>();
        if (currentItem != null)
        {
            switch (ItemUseMode())
            {
                case "Frontal":
                    if(AIRacer.enabled && AIRacer.target != null)
                    {
                        transform.LookAt(AIRacer.target.transform.position);
                    }
                    Instantiate(currentItem, transform.position + transform.forward * 2f, transform.rotation);
                    break;

                case "Back":
                    Instantiate(currentItem, transform.position - transform.forward * 2f, transform.rotation);
                    break;

                case "Shield":
                    itemShield = Instantiate(currentItem, transform.position, transform.rotation) as GameObject;
                    itemShield.transform.parent = transform;
                    break;
            }

            if (AIRacer.enabled)
            {
                currentItem = null;
            }
           
            AIRacer.target = null;
        }
    }
}
