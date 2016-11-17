using System.Collections.Generic;
using GOO2016.Domain.Gravity;
using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Meteor
{
    public class MeteorFactory : MonoBehaviour
    {
        public GameObject[] MeteorPrefabs;

        // Use this for initialization
        void Start ()
        {
            if(this.MeteorPrefabs.Length == 0)
            {
                return;
            }

            var index = Random.Range(0, this.MeteorPrefabs.Length);
            var meteor = Instantiate(this.MeteorPrefabs[index]);
            meteor.transform.position = this.transform.position;
            var rotation = Random.Range(0.0f, 360.0f);
            meteor.transform.Rotate(0.0f, 0.0f, rotation);
            var massComponent = meteor.GetComponent<IMassComponent>();
            var positionComponent = meteor.GetComponent<IPositionComponent>();

            new Body(Simulation.Instance, massComponent, positionComponent);

            Destroy(this.gameObject);
        }
    }
}
