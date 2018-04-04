using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SpringConnection
{
    public GameObject springConnection;
    public Spring spring;
    public Vector3 relativeDirection;
    public bool inverse;

    public SpringConnection(GameObject con, Spring spr, Vector3 dir)
    {
        springConnection = con;
        spring = spr;
        relativeDirection = dir;
    }
    public SpringConnection(GameObject con, Spring spr, Vector3 dir, bool inv)
    {
        springConnection = con;
        spring = spr;
        relativeDirection = dir;
        inverse = inv;
    }
}
public class SpringPart : MonoBehaviour {
    [SerializeField]
    public List<SpringConnection> connections;
    public Vector3 velocity;
    public float mass = 1f;
    public float dampening = 0.99f;
    public bool LogRelativePos;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(SpringConnection con in connections)
        {
            Vector3 F = Vector3.zero;
            if(!con.inverse)
                F = con.spring.CalculateSpringForceWithDirection(con.springConnection.transform.position - transform.position, transform.rotation * con.relativeDirection);
            else
                F = con.spring.CalculateSpringForceWithDirection(con.springConnection.transform.position - transform.position, transform.rotation * con.relativeDirection);
            velocity += F * mass* Time.deltaTime;
        }
        //velocity += Vector3.down * 0.1f * Time.deltaTime;
        velocity *= dampening;
        transform.position += velocity * Time.deltaTime;
        if (LogRelativePos)
            Debug.Log((connections[0].springConnection.transform.position - transform.position).magnitude);
	}
}
