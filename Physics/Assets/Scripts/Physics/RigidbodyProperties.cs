using System;
using UnityEngine;

[Serializable]
public class RigidbodyProperties {
    [SerializeField]
    private Vector3 velocity = new Vector3(0, 0, 0);
    public Vector3 Velocity {
        set { velocity = value; }
        get { return velocity; }
    }

    private Vector3 force = new Vector3(0, 0, 0);
    public Vector3 Force {
        set { velocity = value; }
        get { return velocity; }
    }

    private Vector3 centerOfMass = new Vector3(0, 0, 0);
    public Vector3 CenterOfMass {
        set { centerOfMass = value; }
        get { return centerOfMass; }
    }

    [SerializeField]
    private float area = 0.001432f;
    public float Area {
        set { area = value; }
        get { return area; }
    }

    [SerializeField]
    private float mass = 0.0459f;
    public float Mass {
        set { mass = value; }
        get { return mass; }
    }

    [SerializeField]
    private float dragCoefficient = 0.25f;
    public float DragCoefficient {
        set { dragCoefficient = value; }
        get { return dragCoefficient; }
    }
}
