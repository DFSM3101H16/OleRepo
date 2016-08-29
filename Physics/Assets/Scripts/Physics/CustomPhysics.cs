using UnityEngine;
using System.Collections;
using UnityEditor;

public class CustomPhysics {
    private static Vector3 windVelocity =
        new Vector3(EditorPrefs.GetFloat("windx", 0),
                    EditorPrefs.GetFloat("windy", 0),
                    EditorPrefs.GetFloat("windz", 0));
    public static Vector3 WindVelocity {
        set { windVelocity = value; }
        get { return windVelocity; }
    }

    private static Vector3 gravity =
        new Vector3(EditorPrefs.GetFloat("gravx", 0),
                    EditorPrefs.GetFloat("gravy", -9.81f),
                    EditorPrefs.GetFloat("gravx", 0));
    public static Vector3 Gravity {
        set { gravity = value; }
        get { return gravity; }
    }

    private static float airDensity = EditorPrefs.GetFloat("airDensity");
    public static float AirDensity {
        set { airDensity = value; }
        get { return airDensity; }
    }

    public static Vector3 AirVelocity(Vector3 velocity) {
        return velocity - WindVelocity;
    }
}
