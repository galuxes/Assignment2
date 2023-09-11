using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Integrator
{
    public static void Integrate(Particle2D particle, float dt)
    {
        particle.velocity += particle.acceleration * dt;
        
        particle.transform.position += (Vector3)particle.velocity * dt;

        particle.velocity *= Mathf.Pow(particle.damping, dt);
    }
}

