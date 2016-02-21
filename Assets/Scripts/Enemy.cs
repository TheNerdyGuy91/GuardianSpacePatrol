// the enemy will spawn in a different location each time it is destroyed
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private Vector3 location; // to spawn threat at location
    private float x, y, z;
    public GameObject tLight;
    void Start() // create the first threat
    {
        y = 7.5f; // constant height;
        getNewLocation();

    }
    void getNewLocation()
    {

        x = Random.Range(0, 224);
        z = Random.Range(0, 256);
        location = new Vector3(x, y, z);
        transform.position = location;
        tLight.transform.position = location;
    }

    void OnTriggerEnter(Collider obj) // if the enemy collides with guardian
    {
        if (obj.tag == "Guardian")
        {
            getNewLocation();
        }
    }
}
