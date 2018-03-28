using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ObjectWithSpring : MonoBehaviour {
    public GameObject springConnection;
    public Spring spring;
    Rigidbody body;
    MidPoint mid;
    public Vector3 velocity;
    public float mass;
    
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        if (springConnection != null)
        {
            mid = springConnection.GetComponent<MidPoint>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (springConnection != null)
        {
            if (mid == null)
            {
                //body.AddForce(spring.CalculateSpringForce(springConnection.transform.position - transform.position));
                velocity += spring.CalculateSpringForce(springConnection.transform.position - transform.position) * mass * Time.deltaTime;
                velocity *= spring.dampening;
                transform.position += velocity * Time.deltaTime;
            }
            else
            {
                velocity += (spring.CalculateSpringForceToMidPoint(springConnection.transform.position - transform.position) * mass) * Time.deltaTime;
                velocity *= spring.dampening;
                transform.position += velocity * Time.deltaTime;
            }
        }
    }
}
