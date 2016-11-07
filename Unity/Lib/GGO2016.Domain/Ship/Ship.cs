namespace GGO2016.Domain.Ship
{
    public class Ship
    {
        private readonly IEngine engine;
        private readonly float speed;

        public Ship(IEngine engine, float speed)
        {
            this.engine = engine;
            this.speed = speed;
        }

        public void SetThrust(float thrust)
        {
            var force = thrust * this.speed;
            this.engine.Apply(force);
        }
    }
}
