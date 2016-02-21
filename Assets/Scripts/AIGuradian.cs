using UnityEngine;
using System.Collections;
// AI will control the Guradian

public class AIGuradian : MonoBehaviour {
    public GameObject enemy; // to get to the threat 
    public GameObject tA, tB, tC; // for best portal
    private NavMeshAgent AI;
    private bool AIControl;
	// Use this for initialization
	void Start ()
    {
        AIControl = false;
	}
	void FixedUpdate ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            AIControl = (AIControl == false);
        }
        if (AIControl) // if AI is control if not do not do anything 
        {
            AITraversal();
        }
	}
    float getDistance(GameObject obj)
    {
        return Vector3.Distance(obj.transform.position, transform.position);
    }

    float getDistSqr(GameObject obj)
    {
        Vector3 delta = obj.transform.position - transform.position;
        return Vector3.Dot(delta, delta);
    }

    void AITraversal()
    {
        if (getDistance(enemy) >= 60.0f) // if it is too far find a portal
        {
            findBestPortal();
        }
        AI.SetDestination(enemy.transform.position);
    }
    void findBestPortal()
    {
        // find the distance and which portal is shorter
        float distA = getDistance(tA), distB = getDistance(tB), distC = getDistance(tC);
        if (distA <= distB && distA <= distC)
        {
            transform.position = tA.transform.position;
        }
        else if (distB < distA && distB <= distC)
        {
            transform.position = tB.transform.position;
        }
        else
        {
            transform.position = tC.transform.position;
        }
    }
}
