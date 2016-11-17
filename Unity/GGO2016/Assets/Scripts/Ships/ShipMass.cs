using GOO2016.Domain.Gravity;
using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Ships
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
    }
}
