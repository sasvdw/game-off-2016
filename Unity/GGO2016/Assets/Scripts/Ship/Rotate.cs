using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Rigidbody2D body;

    // Use this for initialization
    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var amount = Input.GetAxis("Horizontal");

        ShipFactory.CurrentShip.SetYaw(amount);
    }

    void FixedUpdate()
    {
        body.AddTorque(-ShipFactory.CurrentShip.ReactionControlSystem.YawTorque);
    }
}
