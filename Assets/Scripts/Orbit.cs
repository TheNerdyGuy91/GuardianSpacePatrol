using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {
	private float updateTime;
	public float speed;
    public int height, width, xPos, zPos;
	// Use this for initialization
	void Start () 
	{
        updateTime = 0;    
	}
	
	// Update is called once per frame
	void Update () 
	{
        updateTime += Time.deltaTime * speed;
		float x, y = 5, z;
		z = Mathf.Sin (updateTime) * height + zPos;
        x = Mathf.Cos(updateTime) * width + xPos;
        transform.position = new Vector3(x, y, z);
	}
}
