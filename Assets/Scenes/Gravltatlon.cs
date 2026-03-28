using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
public class Gravitation : MonoBehaviour
{
    public static List<Gravitation> otherObj;
    private Rigidbody _rd;
    const float G = 0.00667f;
    void Awake()
    {
        _rd = GetComponent<Rigidbody>();
        if (otherObj == null)
        {
            otherObj = new List<Gravitation>();
        }
        otherObj.Add(this);
    }


    void FixedUpdate()
    {
        foreach (Gravitation obj in otherObj)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        }
    }
    void Attract(Gravitation other)
    {
        Rigidbody otherRb = other._rd;
        Vector3 direction = _rd.position - otherRb.position;

        float distance = direction.magnitude;
        if (distance == 0f) return;

        // F = G(m1 * m2) / r^2
        float forceMagnitude = G * (_rd.mass * otherRb.mass) / Mathf.Pow(distance, 2);
        Vector3 gravitationForce = forceMagnitude * direction.normalized;
        otherRb.AddForce (gravitationForce);
    }
}
