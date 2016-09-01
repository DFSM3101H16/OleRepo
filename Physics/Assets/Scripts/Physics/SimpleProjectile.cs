using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : CustomRigidbody {
    void Start() {
    }

    void FixedUpdate() {
        var result = ODESolver.RungeKutta4(
                new ProjectileODE(
                        new ProjectileODEData(this)), 
                0);
        transform.position = result.Position;
        Properties.Velocity = result.Velocity;
        if(transform.position.y < 0) {
            Time.timeScale = 0;
            Debug.Log(Time.timeSinceLevelLoad);
        }
    }
}