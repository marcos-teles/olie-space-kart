using UnityEngine;
using System.Collections;

public class CamGame : MonoBehaviour {

    public GameObject target;
    private Transform distance;   
    private Vector3 posDamage;
    private Vector3 lastF;
       
    public static bool moveCam;   

    // Use this for initialization
    void Start () {
        target = Manager.player;
        //target = Manager.racers[1];
        moveCam = true;
        distance = target.transform.Find("Cam Guide").transform; 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        if(moveCam)
        {            
            transform.position = Vector3.Slerp(transform.position, distance.transform.position, 0.6f);
            lastF = target.transform.forward;
        }
        else
        {
            posDamage = target.transform.position - lastF * 4f + target.transform.up * 1f;
            transform.position = Vector3.Slerp(transform.position, posDamage, 0.2f);
        }

        transform.LookAt(target.transform.position);


        //transform.position = Vector3.Slerp(transform.position, distance.transform.position + distance.transform.right * 1.5f * Input.GetAxis("Horizontal"), 0.2f);
        //Quaternion angle = Quaternion.Euler(player.transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, player.transform.rotation.eulerAngles.z - 2*Input.GetAxis("Horizontal"));
        //transform.rotation = angle;
        //transform.rotation = Quaternion.Slerp(player.transform.rotation, angle, 0.2f);


    }
}
