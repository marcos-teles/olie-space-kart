using UnityEngine;
using System.Collections;

public class RefTrack : MonoBehaviour {

    private Vector3 currentUp;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        AlingGround();
        AlingGuide();

    }

    void AlingGround()
    {
        currentUp = transform.up;
     

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -currentUp, out hit))
        {       
            Quaternion rotationNormal = Quaternion.FromToRotation(transform.up, hit.normal);
            transform.rotation = rotationNormal * transform.rotation;
            transform.localPosition += currentUp * (40 - hit.distance);
        }
    }

    void AlingGuide()
    {       
        RaycastHit hit2;

        if (Physics.Raycast(transform.position, -transform.transform.right, out hit2))
        {
            Quaternion rotationToTrack = Quaternion.FromToRotation(transform.right, hit2.normal);
            transform.rotation = rotationToTrack * transform.rotation; 
            transform.localPosition += transform.right * (50 - hit2.distance);

            //print(hit2.triangleIndex);
        }

       
    }

    void SensorPosition()
    {

    }
}
