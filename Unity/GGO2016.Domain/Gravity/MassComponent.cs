namespace GOO2016.Domain.Gravity
{
    public class MassComponent : IMassComponent
    {
        public float Mass { get; }

        public MassComponent(float mass)
        {
            this.Mass = mass;
        }
    }
}
