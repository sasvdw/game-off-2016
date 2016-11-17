using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Ships
{
    public class ShipGravity : MonoBehaviour
    {
        private Rigidbody2D rigidbody2D;

        private void Start()
        {
            this.rigidbody2D = this.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            this.rigidbody2D.AddForce(ShipFactory.CurrentShip.NetGravityForce);
        }
    }
}