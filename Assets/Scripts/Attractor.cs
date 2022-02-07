using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    private const float Gravitational = 0.6674f;
    public Rigidbody rb;
    public static List<Attractor> attractors;
    public float distance;
    void FixedUpdate()
    {
        foreach (Attractor attr in attractors)
        {
            if (attr!= this)
            {
                Attract(attr);
            }
        }
    }
    
    void OnEnable ()
    {
        if (attractors == null)
            attractors = new List<Attractor>();

        attractors.Add(this);
    }

    void OnDisable ()
    {
        attractors.Remove(this);
    }
    
    void Attract (Attractor objToAttract){
        Rigidbody rbToAttract = objToAttract.rb;
    
        Vector3 direction = rb.position - rbToAttract.position;
        distance = direction.magnitude;
        
        if (distance == 0f)
            return;
        
        float forceMagnitude = Gravitational*(rb.mass * rbToAttract.mass)/ Mathf.Pow(distance,2);
        Vector3 force = direction.normalized * forceMagnitude;
    
        rbToAttract.AddForce(force);
    }
}
