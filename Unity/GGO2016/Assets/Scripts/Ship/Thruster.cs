using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Ship
{
    public class Thruster : MonoBehaviour
    {
        private Rigidbody2D body;

        // Use this for initialization
        void Start()
        {
            this.body = this.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            var input = Input.GetAxis("Vertical");
            var throttle = input > 0 ? input : 0;

            ShipFactory.CurrentShip.SetThrottle(throttle);
        }

        void FixedUpdate()
        {
            var forceVector = new Vector2(0, ShipFactory.CurrentShip.Engine.ThrustForce);
            var rot = Quaternion.Euler(0, 0, this.body.rotation);
            Vector2 force = rot * forceVector;
            this.body.AddForce(force);
        }
    }
}
