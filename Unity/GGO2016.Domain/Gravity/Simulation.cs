using System.Collections.Generic;

namespace GOO2016.Domain.Gravity
{
    public class Simulation
    {
        private readonly HashSet<Body> bodies;

        public IEnumerable<Body> Bodies => this.bodies;

        public const float BigG = 0.6f;

        private static volatile Simulation instance;

        private static object lockObject = new object();

        public static Simulation Instance
        {
            get
            {
                if(instance != null)
                {
                    return instance;
                }

                lock(lockObject)
                {
                    if(instance == null)
                    {
                        instance = new Simulation();
                    }
                }

                return instance;
            }
        }

        private Simulation()
        {
            this.bodies = new HashSet<Body>();
        }

        public void Add(Body bodyToAdd)
        {
            if(this.bodies.Contains(bodyToAdd))
            {
                return;
            }

            this.bodies.Add(bodyToAdd);
        }
    }
}
