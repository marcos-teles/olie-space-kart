using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Kart kart;
	void Start () {
        kart = GetComponent<Kart>();
        kart.speed = 80;
	}

    public void StartAcel()
    {
        kart.acelKart = true;
    }

    public void StopAcel()
    {
        kart.acelKart = false;
    }

    public void StartTR()
    {
        kart.turnDirection = 1;
        print(kart.turnDirection);
    }

    public void StopTR()
    {
        kart.turnDirection = 0;
    }

    public void StartTL()
    {
        kart.turnDirection = -1;
    }

    public void StopTL()
    {
        kart.turnDirection = 0;
    }

    public void UseI()
    {
        kart.activeItem = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {          
            kart.acelKart = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            kart.acelKart = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            kart.turnDirection = -1;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            kart.turnDirection = 0;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            kart.turnDirection = 1;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            kart.turnDirection = 0;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            kart.UseItem();
        }

        // kart.turnDirection = Input.GetAxis("Horizontal");
        // print(kart.turnDirection);
        //print(GetComponent<RacerInfo>().checkPoints);
    }   
}
