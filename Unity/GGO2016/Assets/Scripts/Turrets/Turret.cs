using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Turrets
{
    public class Turret : MonoBehaviour
    {
        private float maxRotation = 30.0f;
        private float gunAngularVelocity = 20.0f;
        private Rigidbody2D[] guns;
        private void Start ()
        {
            //this.guns = this.GetComponentsInChildren<Rigidbody2D>();

            //foreach(var gun in this.guns)
            //{
            //    gun.angularVelocity = this.gunAngularVelocity;
            //}
        }
	
        private void FixedUpdate ()
        {
            //foreach(var gun in this.guns)
            //{
            //    if(gun.rotation > this.maxRotation)
            //    {
            //        gun.angularVelocity = -this.gunAngularVelocity;
            //    }
            //    else if(gun.rotation < -this.maxRotation)
            //    {
            //        gun.angularVelocity = this.gunAngularVelocity;
            //    }
            //}
        }
    }
}
