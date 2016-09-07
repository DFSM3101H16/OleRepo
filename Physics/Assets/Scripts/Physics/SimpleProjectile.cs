using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : CustomRigidbody {
    void Start() {
    }

    void FixedUpdate() {
        //Use runge-kutta to approximate the new position
        var result = ODESolver.RungeKutta4(
                new ProjectileODE(
                        new ProjectileODEData(this)), 
                0);

        //Update position and velocity
        transform.position = result.Position;
        Properties.Velocity = result.Velocity;

        //Stop time if position.y is less than 0
        if(transform.position.y < 0) {
            Time.timeScale = 0;
        }
    }
}