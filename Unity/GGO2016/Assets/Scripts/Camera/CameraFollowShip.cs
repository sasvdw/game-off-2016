using UnityEngine;

public class CameraFollowShip : MonoBehaviour
{
    public float DampTime = 0.9f;
    private Camera camera;
    private GameObject ship;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        this.camera = GetComponent<Camera>();
        this.ship = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!this.ship)
        {
            return;
        }

        var speed = this.ship.GetComponent<Rigidbody2D>().velocity * 0.5f;
        var cameraOffset = this.ship.transform.position + new Vector3(speed.x, speed.y, 0);
        var point = this.camera.WorldToViewportPoint(cameraOffset);
        var delta = cameraOffset - this.camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        var destination = this.transform.position + delta;
        this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref this.velocity, this.DampTime);
    }
}
