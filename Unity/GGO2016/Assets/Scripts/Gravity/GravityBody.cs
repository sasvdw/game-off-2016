using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    private const float bigG = 0.6f;

    private readonly HashSet<GravityBody> bodies;
    private Rigidbody2D rigidbody2D;

    public GravityBody()
    {
        this.bodies = new HashSet<GravityBody>();
    }

    // Use this for initialization
    private void Start()
    {
        this.rigidbody2D = GetComponentInParent<Rigidbody2D>();

        var bodies = FindObjectsOfType<GravityBody>();

        foreach(var body in bodies)
        {
            this.AddBody(body);
        }
    }

    private void AddBody(GravityBody bodyToAdd)
    {
        if(bodyToAdd == this || this.bodies.Contains(bodyToAdd))
        {
            return;
        }

        this.bodies.Add(bodyToAdd);

        bodyToAdd.AddBody(this);
    }

    // Update is called once per frame
    private void Update() {}

    private void FixedUpdate()
    {
        foreach(var body in this.bodies)
        {
            var force = body.GetGravityBetweenBody(this);

            this.rigidbody2D.AddForce(force);
        }
    }

    private Vector2  GetGravityBetweenBody(GravityBody body)
    {
        var heading = this.rigidbody2D.position - body.rigidbody2D.position;

        var rSquared = heading.sqrMagnitude;

        var force = bigG * (this.rigidbody2D.mass * body.rigidbody2D.mass) / (rSquared);

        return heading.normalized * force;
    }
}
