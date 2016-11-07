using UnityEngine;

public class CameraFollowShip : MonoBehaviour
{
    public float DampTime = 0.15f;
    private Camera camera;
    private Transform ship;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        this.camera = GetComponent<Camera>();
        this.ship = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!this.ship)
        {
            return;
        }

        var point = this.camera.WorldToViewportPoint(this.ship.position);
        var delta = this.ship.position - this.camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        var destination = this.transform.position + delta;
        this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref this.velocity, this.DampTime);
    }
}
