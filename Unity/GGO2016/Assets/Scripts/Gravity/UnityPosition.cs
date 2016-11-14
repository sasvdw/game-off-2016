using GOO2016.Domain.Gravity;
using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Gravity
{
    public class UnityPosition : MonoBehaviour, IPositionComponent
    {
        public Vector2 Position
        {
            get
            {
                return this.transform.position;
            }
        }
    }
}
