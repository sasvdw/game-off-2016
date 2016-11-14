using System;
using GOO2016.Domain.Gravity;
using UnityEngine;

namespace GOO2016.Domain.Ships
{
    public class Ship
    {
        private readonly Engine engine;
        private readonly ReactionControlSystem reactionControlSystem;
        private readonly Body body;

        public float ThrustForce => this.engine.ThrustForce;
        public float YawTorque => this.reactionControlSystem.YawTorque;
        public Vector2 NetGravityForce => this.body.NetForce;

        public Ship(Engine engine, ReactionControlSystem reactionControlSystem, Body body)
        {
            this.engine = engine;
            this.reactionControlSystem = reactionControlSystem;
            this.body = body;
        }

        public void SetThrottle(float throttle)
        {
            if(throttle < 0 || throttle > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(throttle), "Value should be between 0 and 1");
            }

            this.engine.SetThrottle(throttle);
        }

        public void SetYaw(float amount)
        {
            if(amount < -1 || amount > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Value should be between -1 and 1");
            }

            this.reactionControlSystem.SetYaw(amount);
        }
    }
}
