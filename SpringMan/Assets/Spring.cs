using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Spring", menuName ="Spring", order=1)]
public class Spring : ScriptableObject {
    public float restDist;
    public float stiffness;
    public float dampening = 0.9f;
    public Vector3 CalculateSpringForce(Vector3 distance)
    {
        float mag = distance.magnitude;
        float diff = restDist - mag;
        return -stiffness * diff * distance.normalized;
    }
    public Vector3 CalculateSpringForceToMidPoint(Vector3 distance)
    {
        float mag = distance.magnitude;
        float diff = (restDist/2 - mag);
        return -stiffness * diff * distance.normalized;
    }
    public Vector3 CalculateSpringForce(Vector3 distance, float restDist)
    {
        float mag = distance.magnitude;
        float diff = restDist - mag;
        return -stiffness * diff * distance.normalized;
    }
    public Vector3 CalculateSpringForceWithDirection(Vector3 distance, Vector3 relativeDirection)
    {
        Vector3 dir = relativeDirection.normalized* restDist;
        float mag = distance.magnitude;
        Vector3 diff = dir - distance;
        return -stiffness * diff; //* distance.normalized;
    }
    public Spring copy()
    {
        Spring temp = new Spring();
        temp.dampening = dampening;
        temp.restDist = restDist;
        temp.stiffness = stiffness;
        return temp;
    }
}
