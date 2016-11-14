using GOO2016.Domain.Gravity;
using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Ship
{
    public class ShipMass : MonoBehaviour, IMassComponent
    {
        private Rigidbody2D rigidbody2D;

        public float Mass
        {
            get
            {
                return this.rigidbody2D.mass;
            }
        }

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
