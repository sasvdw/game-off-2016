using System.Collections.Generic;
using UnityEngine;

namespace GOO2016.Domain.Gravity
{
    public class Body
    {
        private readonly IMassProvider massProvider;
        private readonly IPositionProvider positionProvider;
        private readonly HashSet<Body> otherBodies;

        public float Mass => this.massProvider.Mass;
        public Vector2 Posiition => this.positionProvider.Position;

        public Vector2 NetForce
        {
            get
            {
                var netForce = Vector2.zero;

                foreach (var otherBody in this.otherBodies)
                {
                    var heading = otherBody.Posiition - this.Posiition;

                    var rSquared = heading.sqrMagnitude;

                    var force = Simulation.BigG * (this.Mass * otherBody.Mass) / rSquared;

                    netForce += heading.normalized * force;
                }

                return netForce;
            }
        }

        public Body(IMassProvider massProvider, IPositionProvider positionProvider, Simulation simulation)
        {
            this.otherBodies = new HashSet<Body>(simulation.Bodies);

            this.massProvider = massProvider;
            this.positionProvider = positionProvider;

            simulation.Add(this);

            foreach(var otherBody in this.otherBodies)
            {
                otherBody.otherBodies.Add(this);
            }
        }
    }
}
