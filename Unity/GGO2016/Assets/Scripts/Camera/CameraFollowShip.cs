using GGO2016.Unity.Assets.Scripts.Ship;
using UnityEngine;

namespace GGO2016.Unity.Assets.Scripts.Camera
{
    public class CameraFollowShip : MonoBehaviour
    {
        public float DampTime = 0.9f;
        private UnityEngine.Camera camera;
        private Vector3 velocity = Vector3.zero;

        // Use this for initialization
        void Start()
        {
            this.camera = this.GetComponent<UnityEngine.Camera>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            var ship = ShipFactory.CurrentShip;

            if(ship == null)
            {
                return;
            }

            var speed = ship.CurrentVelocity * 0.5f;
            var currentPosition = new Vector3(ship.CurrentPosition.x, ship.CurrentPosition.y);
            var cameraOffset = currentPosition + new Vector3(speed.x, speed.y, 0);
            var point = this.camera.WorldToViewportPoint(cameraOffset);
            var delta = cameraOffset - this.camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            var destination = this.transform.position + delta;
            this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref this.velocity, this.DampTime);
        }
    }
}
