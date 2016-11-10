using System;

namespace GOO2016.Domain.Ships
{
    public class Ship
    {
        public Engine Engine { get; }
        public ReactionControlSystem ReactionControlSystem { get; }

        public Ship(Engine engine, ReactionControlSystem reactionControlSystem)
        {
            this.Engine = engine;
            this.ReactionControlSystem = reactionControlSystem;
        }

        public void SetThrottle(float throttle)
        {
            if(throttle < 0 || throttle > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(throttle), "Value should be between 0 and 1");
            }

            this.Engine.SetThrottle(throttle);
        }

        public void SetYaw(float amount)
        {
            if(amount < -1 || amount > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Value should be between -1 and 1");
            }

            this.ReactionControlSystem.SetYaw(amount);
        }
    }
}
