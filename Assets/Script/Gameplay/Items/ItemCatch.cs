using UnityEngine;
using System.Collections;



public class ItemCatch : MonoBehaviour {

   
    public bool isActive = true;

    private Vector3 initScale;
	// Use this for initialization
	void Start () {     
        initScale = transform.localScale;
        RaycastHit hit2;
        if (Physics.Raycast(transform.position, -transform.up, out hit2))
        {
            Quaternion rotationNormal = Quaternion.FromToRotation(transform.up, hit2.normal);
            transform.rotation = rotationNormal * transform.rotation;
            transform.position += transform.up * (1 - hit2.distance);
        }
    }
	
	// Update is called once per frame
	void Update () {	
       
        if(isActive == false)
        {
            transform.localScale = Vector3.Slerp(transform.localScale, Vector3.zero, 0.5f);
        }
        else
        {
            transform.localScale = Vector3.Slerp(transform.localScale, initScale, 0.5f);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        
        if(isActive)
        {
            if (col.tag == "Racer")
            {
                if (col.GetComponent<Kart>().currentItem == null)
                {                    
                    col.GetComponent<AI>().target = null;
                    //col.GetComponent<Kart>().currentItem = RaceTrack.items[Random.Range(0, RaceTrack.items.Length)];
                    if(col.GetComponent<AI>().enabled)
                    {
                        col.GetComponent<Kart>().currentItem = RaceTrack.items[4];
                    }
                    else
                    {
                        col.GetComponent<Kart>().currentItem = RaceTrack.items[2];
                    }
                              
                    isActive = false;
                    Invoke("activeItem", 5);
                }
            }           
        }        
    }

    void activeItem()
    {
        isActive = true;       
    }


}
