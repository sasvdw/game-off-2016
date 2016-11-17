using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Ships
{
    public class Rotate : MonoBehaviour
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
            var amount = Input.GetAxis("Horizontal");

            ShipFactory.CurrentShip.SetYaw(amount);
        }

        void FixedUpdate()
        {
            this.body.AddTorque(-ShipFactory.CurrentShip.YawTorque);
        }
    }
}
