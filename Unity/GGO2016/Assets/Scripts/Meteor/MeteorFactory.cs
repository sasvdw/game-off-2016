using System.Collections.Generic;
using System.Linq;
using GGO2016.Domain.Gravity;
using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Meteor
{
    public class MeteorFactory : MonoBehaviour
    {
        public GameObject[] MeteorPrefabs;
        public int TotalMeteors = 1000;
        public int SpawnRadius = 250;
        private readonly HashSet<Body> bodies;

        public MeteorFactory()
        {
            this.bodies = new HashSet<Body>();
        }

        // Use this for initialization
        private void Start ()
        {
            if(this.MeteorPrefabs.Length == 0)
            {
                Debug.LogError("No MeteorPrefabs set!");
                return;
            }
            int tryCount = 0;
            while(this.bodies.Count < this.TotalMeteors)
            {
                tryCount++;
                var insideUnitCircle = Random.insideUnitCircle;
                var meteorPosition = (insideUnitCircle * (this.SpawnRadius - 1)) + insideUnitCircle.normalized * 2;

                if(this.bodies.Any(x => (x.Position - meteorPosition).sqrMagnitude < 4))
                {
                    continue;
                }

                this.SpawnMeteor(meteorPosition);
            }
            Debug.Log("try count: " + tryCount);
            Destroy(this.gameObject);
        }

        private void SpawnMeteor(Vector2 position)
        {
            var index = Random.Range(0, this.MeteorPrefabs.Length);
            var meteor = Instantiate(this.MeteorPrefabs[index]);
            meteor.transform.position = position;
            var rotation = Random.Range(0.0f, 360.0f);
            meteor.transform.Rotate(0.0f, 0.0f, rotation);
            var massComponent = meteor.GetComponent<IMassComponent>();
            var positionComponent = meteor.GetComponent<IPositionComponent>();

            var body = new Body(Simulation.Instance, massComponent, positionComponent);
            this.bodies.Add(body);
        }
    }
}
