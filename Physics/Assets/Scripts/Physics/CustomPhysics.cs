using UnityEngine;
using System.Collections;

public class CustomPhysics : MonoBehaviour {
    private static CustomPhysics instance = new CustomPhysics();

    public static Vector3 WindVelocity {
        set { instance.windVelocity = value; }
        get { return instance.windVelocity; }
    }

    public static Vector3 Gravity {
        set { instance.gravity = value; }
        get { return instance.gravity; }
    }

    public static float AirDensity {
        set { instance.airDensity = value; }
        get { return instance.airDensity; }
    }


    public static Vector3 AirVelocity(Vector3 velocity) {
        //Velocity relative to surrounding air
        return velocity - WindVelocity;
    }

    [SerializeField]
    private Vector3 gravity = new Vector3(0, -9.81f, 0);

    [SerializeField]
    private float airDensity = 1.225f;

    [SerializeField]
    private Vector3 windVelocity = new Vector3(0, 0, 0);


    void Start() {
        instance = this;
    }
}
