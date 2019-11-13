using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

    // Use this for initialization
    private float swing;
    private float auxAngle;
    public LayerMask trackGround;
	void Start () {
        auxAngle = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        SwingMove();
        AlingGround();
	}

    void SwingMove()
    {
        auxAngle = auxAngle > 360 ? 1 : auxAngle + 0.05f;
        swing = Mathf.Sin(auxAngle)*0.1f;        
    }

    void AlingGround()
    {
        RaycastHit hit;
       
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10, trackGround))
        {
            Quaternion rotationNormal = Quaternion.FromToRotation(transform.up, hit.normal);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationNormal * transform.rotation, 0.2f); 
            transform.position += transform.up * ((2f+swing) - hit.distance);
        }
    }
}
