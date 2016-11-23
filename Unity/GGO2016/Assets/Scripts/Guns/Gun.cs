using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Guns
{
    public class Gun : MonoBehaviour
    {
        public Transform Lazer;
        private Rigidbody2D rigidbody2D;
        private float maxRotation = 30.0f;
        private float gunAngularVelocity = 20.0f;
        private float maxRange = 10.0f;
        private Transform lazerSpawn;
        private float energy = 0.0f;
        private float energyPerShot = 10.0f;
        private float energyPerSecond = 20.0f;

        private void Start()
        {
            this.rigidbody2D = this.GetComponent<Rigidbody2D>();
            this.rigidbody2D.angularVelocity = this.gunAngularVelocity;
            this.lazerSpawn = this.transform.FindChild("Lazer Spawn");
        }

        private void Update()
        {
            if(this.energy > this.energyPerShot)
            {
                return;
            }
            this.energy += this.energyPerSecond * Time.deltaTime;
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

            if(this.energy > this.energyPerShot)
            {
                this.energy -= this.energyPerShot;
                var eulerAngles = this.transform.eulerAngles;
                var lazer = Instantiate(this.Lazer, this.lazerSpawn.position, Quaternion.Euler(eulerAngles)) as Transform;

                lazer.GetComponent<Rigidbody2D>().AddForce(rayDirection * 3.0f);
            }

            Debug.DrawLine(this.transform.position, rayDirection * this.maxRange, Color.green);
            return;
        }
    }
}
