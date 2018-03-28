using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SpringConnection
{
    public GameObject springConnection;
    public Spring spring;
    public Vector3 relativeDirection;

    public SpringConnection(GameObject con, Spring spr, Vector3 dir)
    {
        springConnection = con;
        spring = spr;
        relativeDirection = dir;
    }
    
}
public class SpringPart : MonoBehaviour {
    [SerializeField]
    public List<SpringConnection> connections;
    public Vector3 velocity;
    public float mass = 1f;
    public float dampening = 0.99f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach(SpringConnection con in connections)
        {
            Vector3 F = con.spring.CalculateSpringForceWithDirection(con.springConnection.transform.position - transform.position, con.relativeDirection);
            velocity += F * mass* Time.deltaTime;
        }
        velocity *= dampening;
        transform.position += velocity * Time.deltaTime;
	}
}
