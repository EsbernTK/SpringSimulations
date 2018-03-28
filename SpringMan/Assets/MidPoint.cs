using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidPoint : MonoBehaviour {
    
    public GameObject object1;
    public GameObject object2;
    public Spring spring;

    public GameObject object3;
    public Vector3 velocity;
    public float dampening = 0.1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (object3 != null && object1 != null && object2 != null)
        {
            Vector3 midPoint = (object2.transform.position - object1.transform.position) * 0.5f + object1.transform.position;
            Vector3 springForceTo3 = spring.CalculateSpringForce(object3.transform.position - transform.position);
            Vector3 springForceToMid = spring.CalculateSpringForce(midPoint - transform.position, 0);
            velocity += (springForceTo3 + springForceToMid) * Time.deltaTime;
            velocity *= dampening;
            transform.position += velocity * Time.deltaTime;
        }
        else if(object1 != null && object2 != null)
        {
            Vector3 midPoint = (object2.transform.position - object1.transform.position) * 0.5f + object1.transform.position;
            Vector3 springForceToMid = spring.CalculateSpringForce(midPoint - transform.position, 0);
            velocity += (springForceToMid) * Time.deltaTime;
            velocity *= dampening;
            transform.position += velocity * Time.deltaTime;
        }
    }
}
