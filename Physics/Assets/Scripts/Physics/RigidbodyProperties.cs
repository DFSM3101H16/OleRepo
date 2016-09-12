using System;
using UnityEngine;


/*
    Container class for all the properties of the custom rigidbody
*/

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

    private Vector3 rotationAxis = new Vector3(1, 0, 0);
    public Vector3 RotationAxis {
        set
        {
            rotationAxis = value;
            if (value.sqrMagnitude > 0) {
                rotationAxis.Normalize();
            }
        }
        get { return rotationAxis; }
    }

    [SerializeField]
    private Vector3 centerOfMass = new Vector3(0, 0, 0);
    public Vector3 CenterOfMass {
        set { centerOfMass = value; }
        get { return centerOfMass; }
    }

    [SerializeField]
    private float radius = 0.001432f;
    public float Radius {
        set { radius = value; }
        get { return radius; }
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
