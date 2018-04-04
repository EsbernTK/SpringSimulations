using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringChainCreator : MonoBehaviour {
    public SpringPart SpringPartPrefab;
    GameObject prefab;
    public int chainLength;
    public Spring spring;
    
	// Use this for initialization
	void Start () {
        prefab = SpringPartPrefab.gameObject;

        GameObject former = Instantiate(prefab);
        former.transform.parent = gameObject.transform;
        SpringPart formerPart = former.GetComponent<SpringPart>();
        formerPart.connections.Add(new SpringConnection(gameObject, spring, Vector3.left, true));
        for (int i = 1; i < chainLength; i++)
        {
            GameObject cur = Instantiate(prefab, former.transform.position + Vector3.right, former.transform.rotation);
            SpringPart curPart = cur.GetComponent<SpringPart>();
            cur.transform.parent = gameObject.transform;
            if (i > 1)
            {
                curPart.connections.Add(new SpringConnection(former, spring, Vector3.left, true));
                formerPart.connections.Add(new SpringConnection(cur, spring, Vector3.right));
                cur.transform.rotation = cur.transform.rotation * Quaternion.LookRotation(formerPart.connections[formerPart.connections.Count - 1].relativeDirection.normalized);
            }
            else
            {
                curPart.connections.Add(new SpringConnection(former, spring, new Vector3(-1, -1, -1), true));
                formerPart.connections.Add(new SpringConnection(cur, spring, new Vector3(1, 1, 1)));
                cur.transform.rotation = cur.transform.rotation * Quaternion.LookRotation(formerPart.connections[formerPart.connections.Count - 1].relativeDirection.normalized);
            }
            former = cur;
            formerPart = curPart;
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}
