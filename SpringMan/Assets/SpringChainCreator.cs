using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringChainCreator : MonoBehaviour {
    public SpringPart SpringPartPrefab;
    GameObject prefab;
    public int chainLength;
    public Spring spring;
    Spring tempSpring;
    public float tempSpringStiffness;
	// Use this for initialization
	void Start () {
        prefab = SpringPartPrefab.gameObject;
        tempSpring = spring.copy();
        tempSpring.stiffness = tempSpringStiffness;
        GameObject former = Instantiate(prefab);
        former.transform.parent = gameObject.transform;
        SpringPart formerPart = former.GetComponent<SpringPart>();
        formerPart.connections.Add(new SpringConnection(gameObject, spring, Vector3.left, true));
        formerPart.spring = spring;
        for (int i = 1; i < chainLength; i++)
        {
            
            GameObject cur = Instantiate(prefab, former.transform.position + formerPart.connections[0].relativeDirection, former.transform.rotation);
            SpringPart curPart = cur.GetComponent<SpringPart>();
            cur.transform.parent = gameObject.transform;
            if (i > 1)
            {
                curPart.connections.Add(new SpringConnection(former, tempSpring, new Vector3(-1, -1, -1), true));
                formerPart.connections.Add(new SpringConnection(cur, spring, new Vector3(1, 1, 1)));
                cur.transform.rotation = cur.transform.rotation * Quaternion.LookRotation(formerPart.connections[formerPart.connections.Count - 1].relativeDirection.normalized, Vector3.up);
            }
            else
            {
                curPart.connections.Add(new SpringConnection(former, tempSpring, new Vector3(-1, -1, -1), true));
                formerPart.connections.Add(new SpringConnection(cur, spring, new Vector3(1, 1, 1)));
                cur.transform.rotation = cur.transform.rotation * Quaternion.LookRotation(formerPart.connections[formerPart.connections.Count - 1].relativeDirection.normalized);
            }
            //curPart.mass = (float)i / (float)chainLength * 20f;
            curPart.spring = spring;
            former = cur;
            formerPart = curPart;
        }
        Debug.Log(Quaternion.LookRotation(new Vector3(1, 0, 1))* Vector3.right);
    }
	
	// Update is called once per frame
	void Update () {
        tempSpring.restDist = spring.restDist;
        tempSpring.stiffness = tempSpringStiffness;
	}
}
