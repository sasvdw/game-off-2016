using GGO2016.Domain.Gravity;
using GGO2016.Domain.Ships;
using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Ships
{
    public class ShipFactory : MonoBehaviour {
        public float ThrustSpeed = 10.0f;
        public float YawSpeed = 10.0f;
        public GameObject ShipPrefab;

        public static Ship CurrentShip;

        // Use this for initialization
        private void Start ()
        {
            var engine = new Engine(this.ThrustSpeed);
            var reactionControlSystem = new ReactionControlSystem(this.YawSpeed);
            var ship = Instantiate(this.ShipPrefab);
            ship.transform.position = this.transform.position;
            var shipMassComponent = ship.GetComponent<IMassComponent>();
            var shipPositionComponent = ship.GetComponent<IPositionComponent>();
            var shipVelocity = ship.GetComponent<IVelocityComponent>();
            var shipBody = new Body(Simulation.Instance, shipMassComponent, shipPositionComponent);

            CurrentShip = new Ship(engine, reactionControlSystem, shipBody, shipVelocity);

            Destroy(this.gameObject);
        }
    }
}
