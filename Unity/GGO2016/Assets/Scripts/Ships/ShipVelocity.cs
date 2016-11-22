using GGO2016.Domain.Ships;
using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Ships
{
    public class ShipVelocity : MonoBehaviour, IVelocityComponent
    {
        private Rigidbody2D rigidbody2D;
        // Use this for initialization
        void Start ()
        {
            this.rigidbody2D = this.GetComponent<Rigidbody2D>();
        }
	
        // Update is called once per frame
        void Update () {
	
        }

        public Vector2 CurrentVelocity
        {
            get
            {
                if(!this.rigidbody2D)
                {
                    return Vector2.zero;
                }

                return this.rigidbody2D.velocity;
            }
        }
    }
}
