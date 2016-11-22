using System.Collections.Generic;
using UnityEngine;

namespace GGO2016.Domain.Gravity
{
    public class Body
    {
        private readonly IMassComponent massComponent;
        private readonly IPositionComponent positionComponent;
        private readonly HashSet<Body> otherBodies;

        public float Mass => this.massComponent.Mass;
        public Vector2 Position => this.positionComponent.Position;

        public Vector2 NetForce
        {
            get
            {
                var netForce = Vector2.zero;

                foreach (var otherBody in this.otherBodies)
                {
                    var heading = otherBody.Position - this.Position;

                    var rSquared = heading.sqrMagnitude;

                    var force = Simulation.BigG * (this.Mass * otherBody.Mass) / rSquared;

                    netForce += heading.normalized * force;
                }

                return netForce;
            }
        }

        public Body(Simulation simulation, IMassComponent massComponent, IPositionComponent positionComponent)
        {
            this.otherBodies = new HashSet<Body>(simulation.Bodies);

            this.massComponent = massComponent;
            this.positionComponent = positionComponent;

            simulation.Add(this);

            foreach(var otherBody in this.otherBodies)
            {
                otherBody.otherBodies.Add(this);
            }
        }
    }
}
