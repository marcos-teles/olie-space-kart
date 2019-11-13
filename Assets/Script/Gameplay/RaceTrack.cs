using UnityEngine;
using System.Collections;

public class RaceTrack : MonoBehaviour {


    public static GameObject[] items;
    public static GameObject[] itemCatchs;
    public static int triangleCount;
    public GameObject leftWall;
  
 

    // Use this for initialization
    void Start () {
        items = Resources.LoadAll<GameObject>("Items");
        itemCatchs = GameObject.FindGameObjectsWithTag("ItemCatch");
        triangleCount = leftWall.GetComponent<MeshFilter>().mesh.triangles.Length/3;
        //print(triangleCount);       
    }
	
	// Update is called once per frame
	void Update () {      
	}

    

    //GameObject[] addArray(GameObject[] array1, GameObject[] array2)
    //{      
    //    GameObject[] finalArray = new GameObject[array1.Length + array2.Length];
    //    for(int i =0; i< array1.Length; i++)
    //    {
    //        finalArray[i] = array1[i];
    //    }

    //    for (int i = 0; i < array2.Length; i++)
    //    {
    //        finalArray[i+ array1.Length] = array2[i];
    //    }

    //    return finalArray;
    //}
}
