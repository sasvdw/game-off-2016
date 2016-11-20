using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Guns
{
    public class Gun : MonoBehaviour
    {
        private Rigidbody2D rigidbody2D;
        private float maxRotation = 30.0f;
        private float gunAngularVelocity = 20.0f;
        private float maxRange = 10.0f;

        private void Start()
        {
            this.rigidbody2D = this.GetComponent<Rigidbody2D>();
            this.rigidbody2D.angularVelocity = this.gunAngularVelocity;
        }

        private void FixedUpdate()
        {
            var rotation = this.transform.localRotation.eulerAngles.z;

            if(rotation > 180.0f)
            {
                rotation = rotation - 360.0f;
            }

            if (rotation > this.maxRotation)
            {
                this.rigidbody2D.angularVelocity = -this.gunAngularVelocity;
                return;
            }
            if (rotation < -this.maxRotation)
            {
                this.rigidbody2D.angularVelocity = this.gunAngularVelocity;
                return;
            }
            var rayDirection = this.transform.TransformDirection(Vector3.down);
            var raycastHit2D = Physics2D.Raycast(this.transform.position, rayDirection, this.maxRange);
            if (!raycastHit2D.transform)
            {
                Debug.DrawLine(this.transform.position, rayDirection * this.maxRange, Color.red);
                return;
            }

            Debug.DrawLine(this.transform.position, rayDirection * this.maxRange, Color.green);
            return;
        }
    }
}
