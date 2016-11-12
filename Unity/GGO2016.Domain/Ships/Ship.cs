using System;

namespace GOO2016.Domain.Ships
{
    public class Ship
    {
        private readonly Engine engine;
        private readonly ReactionControlSystem reactionControlSystem;

        public float ThrustForce => this.engine.ThrustForce;
        public float YawTorque => this.reactionControlSystem.YawTorque;


        public Ship(Engine engine, ReactionControlSystem reactionControlSystem)
        {
            this.engine = engine;
            this.reactionControlSystem = reactionControlSystem;
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
