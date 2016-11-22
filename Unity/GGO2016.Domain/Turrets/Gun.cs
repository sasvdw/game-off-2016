namespace GGO2016.Domain.Turrets
{
    public class Gun
    {
        private readonly IRotationComponent rotationComponent;
        private readonly float rotationSpeed;

        public float CurrentRotation => this.rotationComponent.CurrentRotation;

        public Gun(IRotationComponent rotationComponent, float rotationSpeed)
        {
            this.rotationComponent = rotationComponent;
            this.rotationSpeed = rotationSpeed;
        }
    }

    public interface IRotationComponent
    {
        float CurrentRotation { get; }

        void ChangeDirection(Direction direction);
    }

    public enum Direction
    {
        Clockwise,
        Counterclockwise
    }
}
