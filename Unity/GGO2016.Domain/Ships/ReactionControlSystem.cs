namespace GGO2016.Domain.Ships
{
    public class ReactionControlSystem
    {
        private readonly float yawSpeed;
        private float yawInput;

        public float YawTorque => this.yawSpeed * this.yawInput;

        public ReactionControlSystem(float yawSpeed)
        {
            this.yawSpeed = yawSpeed;
            this.yawInput = 0.0f;
        }

        internal void SetYaw(float amount)
        {
            this.yawInput = amount;
        }
    }
}
