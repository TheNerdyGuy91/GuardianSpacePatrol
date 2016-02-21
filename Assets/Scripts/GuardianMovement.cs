using UnityEngine;
using System.Collections;

public class GuardianMovement : MonoBehaviour
{

    // Use this for initialization
    private Rigidbody rb; // to move the guardian
    private float speed, tilt;
    public GameObject tA, tB, tC; // portal 
    private bool userControl;
    private float h, v, y;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 2;
        tilt = 5;
        userControl = true;
        y = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            userControl = (userControl == false);
        }
        // movement
        
            
            if (userControl)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1)) // travel to the star
                {
                    transform.position = tA.transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2)) // travel to the middle
                {
                    transform.position = tB.transform.position;
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3)) // travel to the end
                {
                    transform.position = tC.transform.position;
                }

                if (Input.GetKey(KeyCode.H)) // ascend
                {
                y++;
                }
                if (Input.GetKey(KeyCode.L)) // descend
                {
                y--;
                }
                v = Input.GetAxisRaw("Vertical");
                h = Input.GetAxisRaw("Horizontal");
                Vector3 move = new Vector3(h, y, v);
                rb.AddForce(move * speed);
                rb.rotation = Quaternion.Euler(rb.velocity.x * -tilt, 0.0f, rb.velocity.z * -tilt);
            }
        
    }
}