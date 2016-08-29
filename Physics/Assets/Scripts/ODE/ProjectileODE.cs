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

        ProjectileODEData tmp =
            new ProjectileODEData(initial);

        if(derivative != null) {
            tmp.Position += derivative.Position * deltaTime;
            tmp.Velocity += derivative.Velocity * deltaTime;
        }

        ProjectileODEData derivativeResult =
            new ProjectileODEData(tmp);
        derivativeResult.Position = tmp.Velocity;
        derivativeResult.Velocity = acceleration(tmp, time + deltaTime);

        return derivativeResult; ;
    }

    Vector3 acceleration(ProjectileODEData state, float time) {
        Vector3 airVelocity = CustomPhysics.AirVelocity(state.Velocity);
        Vector3 drag = -airVelocity.normalized * airVelocity.sqrMagnitude *
            CustomPhysics.AirDensity * state.Area * state.DragCoefficient / (state.Mass * 2.0f);

        return CustomPhysics.Gravity + drag;
    }
}
