using GOO2016.Domain.Gravity;
using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Meteor
{
    public class MeteorFactory : MonoBehaviour
    {
        public GameObject[] MeteorPrefabs;
        public int TotalMeteors = 100;
        public int SpawnRadius = 100;

        // Use this for initialization
        void Start ()
        {
            if(this.MeteorPrefabs.Length == 0)
            {
                Debug.LogError("No MeteorPrefabs set!");
                return;
            }

            for(var i = 0; i < this.TotalMeteors; i++)
            {
                var insideUnitCircle = Random.insideUnitCircle;
                var meteorPosition = (insideUnitCircle * (this.SpawnRadius - 1)) + insideUnitCircle.normalized;
                this.SpawnMeteor(meteorPosition);
            }

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

            new Body(Simulation.Instance, massComponent, positionComponent);
        }
    }
}
