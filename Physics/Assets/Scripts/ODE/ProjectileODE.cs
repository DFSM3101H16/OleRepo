using UnityEngine;
using System.Collections;
using System;

public class ProjectileODE : ODE<ProjectileODEData> {

    public ProjectileODE(ProjectileODEData initial) : base(initial) {
    }

    public override ProjectileODEData Evaluate(ProjectileODEData initial, 
                ProjectileODEData derivative, 
                float time, 
                float deltaTime) {

        ProjectileODEData tmp = new ProjectileODEData(initial);     //Create a new instance, don't modify data from parameter

        //Euler method
        tmp.Position += derivative.Position * deltaTime;
        tmp.Velocity += derivative.Velocity * deltaTime;

        ProjectileODEData derivativeResult =
            new ProjectileODEData(tmp);


        //Calculate drag
        Vector3 airVelocity = CustomPhysics.AirVelocity(tmp.Velocity);      //Speed relative to surrounding air
        Vector3 dragForce = 0.5f * (-airVelocity.normalized * airVelocity.sqrMagnitude) *        //(m/s)^2
            CustomPhysics.AirDensity * tmp.Area *   //kg/m^3 * m^2 =    kg/m
            tmp.DragCoefficient;                    //kg/m * m^2/s^2 =  kg*m/s^2 = N

        Vector3 drag = dragForce / tmp.Mass; // N/kg = m/s^2

        //Calculate new derivative (dx/dt = v, dv/dt = a)
        derivativeResult.Position = tmp.Velocity;
        derivativeResult.Velocity = drag + CustomPhysics.Gravity;

        return derivativeResult;
    }
}
