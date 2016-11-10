namespace GOO2016.Domain.Ships
{
    public class Engine
    {
        private readonly float engineSpeed;
        private float currentThrottle;
        public float ThrustForce => this.engineSpeed * this.currentThrottle;

        public Engine(float engineSpeed)
        {
            this.engineSpeed = engineSpeed;
            this.currentThrottle = 0.0f;
        }

        internal void SetThrottle(float amount)
        {
            this.currentThrottle = amount;
        }
    }
}
