namespace GGO2016.Domain.Gravity
{
    public class BasicMassComponent : IMassComponent
    {
        public float Mass { get; }

        public BasicMassComponent(float mass)
        {
            this.Mass = mass;
        }
    }
}
