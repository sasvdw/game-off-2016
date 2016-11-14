using System.Collections.Generic;
using GOO2016.Domain.Gravity;
using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Meteor
{
    public class MeteorFactory : MonoBehaviour
    {
        public float Mass = 10.0f;
        private readonly HashSet<Body> bodies;

        public MeteorFactory()
        {
            this.bodies = new HashSet<Body>();
        }

        // Use this for initialization
        void Start ()
        {
            var massComponent = new MassComponent(this.Mass);
            var positionComponent = this.GetComponent<IPositionComponent>();

            var body = new Body(Simulation.Instance, massComponent, positionComponent);
            this.bodies.Add(body);
        }
	
        // Update is called once per frame
        void Update () {
	
        }
    }
}
