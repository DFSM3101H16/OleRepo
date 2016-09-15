using UnityEngine;
using System;
using System.Collections;

class SpringODEData : ODEData<SpringODEData> {
    private CustomRigidbody rb;
    public Vector3 Position { set; get; }
    public Vector3 Velocity { set; get; }
    public float Mass { get { return rb.Properties.Mass; } }
    public Vector3 SpringPosition { set; get; }
    public float SpringConstant { get; set; }
    public float DampingFactor { get; set; }

    public SpringODEData(CustomRigidbody rb, Vector3 springPosition, float springConstant, float dampingFactor) {
        SpringPosition = springPosition;
        Position = rb.transform.position;
        Velocity = rb.Properties.Velocity;
    }

    public SpringODEData(SpringODEData initial) {
        Velocity = initial.Velocity;
        Position = initial.Position;
        rb = initial.rb;
        SpringConstant = initial.SpringConstant;
        SpringPosition = initial.SpringPosition;
        DampingFactor = initial.DampingFactor;
    }

    public override SpringODEData calculateNextState(SpringODEData[] derivatives) {
        return null;
    }
}
