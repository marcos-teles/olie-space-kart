using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 100), ForceMode.Impulse);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Acelerate();
        Turn();
        //print(GetComponent<Rigidbody>().velocity.magnitude);
    }

    void Acelerate()
    {
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 160));
    }

    void Turn()
    {  
        Vector3 rot = Quaternion.AngleAxis(-45, transform.up) * transform.forward;
        Debug.DrawRay(transform.position, rot * 25);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, rot, out hit, 2))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 50, transform.rotation.eulerAngles.z);
        }

        Vector3 rot2 = Quaternion.AngleAxis(45, transform.up) * transform.forward;
        Debug.DrawRay(transform.position, rot2 * 25);
        RaycastHit hit2;
        if (Physics.Raycast(transform.position, rot2, out hit2, 2))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 50, transform.rotation.eulerAngles.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
       
    }
}
