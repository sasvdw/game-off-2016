using GOO2016.Domain.Gravity;
using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Meteor
{
    public class MeteorMass : MonoBehaviour, IMassComponent
    {
        public float MeteorMassConfig = 10.0f;

        public float Mass
        {
            get
            {
                return this.MeteorMassConfig;
            }
        }
    }
}
