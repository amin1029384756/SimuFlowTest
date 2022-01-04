using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
   public Rigidbody rb;
    const float G = 66.74f;

    void FixedUpdate()
    {
        Gravity[] attractors = FindObjectsOfType<Gravity>();
        foreach (Gravity gravity in attractors)
        {
            if (gravity != this)
            {
                Gravitate(gravity);
            }
        }
    }

    void Gravitate(Gravity objToAttract)
    {
        Rigidbody ItemThatHasMass = objToAttract.rb;

        Vector3 direction = rb.position - ItemThatHasMass.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * (rb.mass * ItemThatHasMass.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        ItemThatHasMass.AddForce(force);
    }

}
