using UnityEngine;
using GOO2016.Domain.Ships;

public class ShipFactory : MonoBehaviour {
    public float ThrustSpeed = 10.0f;
    public float YawSpeed = 10.0f;

    public static Ship CurrentShip;

    // Use this for initialization
    void Start ()
    {
        var engine = new Engine(this.ThrustSpeed);
        var reactionControlSystem = new ReactionControlSystem(this.YawSpeed);

        CurrentShip = new Ship(engine, reactionControlSystem);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
