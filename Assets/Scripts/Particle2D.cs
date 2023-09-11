using UnityEngine;

public class Particle2D : MonoBehaviour
{
    public float mass, inverseMass;
    public Vector2 velocity, acceleration = Vector2.zero, accumulatedForces = Vector2.zero, accelerationDueToGravity = new Vector2(0f,-9.8f);
    [Range(0.00f, 1f)] public float damping = 1f;

    private void FixedUpdate()
    {
        acceleration = accelerationDueToGravity;
        Integrator.Integrate(this, Time.deltaTime);
    }
}
