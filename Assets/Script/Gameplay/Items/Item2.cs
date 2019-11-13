using UnityEngine;
using System.Collections;

public class Item2 : MonoBehaviour {

    public float hoverHeight = 3f;
    public float rotationSmooth = 5f;
    public GameObject explosion;
    private float swingSmooth;
    private Vector3 currentUp;
    private Quaternion rotation;
    private float currentSpeed = 100;

    void Start()
    {       
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 100), ForceMode.Impulse);
    }

    void Update()
    {
        Acelerate();
        RaycastHit hit5;
        if (Physics.Raycast(transform.position, transform.forward, out hit5, 10))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }          
    }

    void Acelerate()
    {
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, 160));
    }
}
