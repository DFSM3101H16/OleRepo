using System;
using UnityEngine;

public class ProjectileODEData : ODEData<ProjectileODEData> {
    readonly CustomRigidbody rb;
    public Vector3 Velocity {
        set; get;
    }
    public Vector3 Position {
        set; get;
    }

    public float Mass {
        private set; get;
    }

    public float Radius {
        private set; get;
    } 

    public float Area {
        private set {}
        get { return Radius * Radius * Mathf.PI; }
    }

    public float DragCoefficient {
        private set; get;
    }

    public ProjectileODEData(ProjectileODEData original) {
        Position = original.Position;
        Velocity = original.Velocity;
        Mass = original.Mass;
        Radius = original.Radius;
        DragCoefficient= original.DragCoefficient;
    }

    public ProjectileODEData(CustomRigidbody rb) {
        this.rb = rb;
        Position = rb.transform.position;
        Velocity = rb.Properties.Velocity;
        Mass = rb.Properties.Mass;
        Radius = rb.Properties.Radius;
        DragCoefficient = rb.Properties.DragCoefficient;
    }

    public override ProjectileODEData calculateNextState(ProjectileODEData[] derivatives) {
        //More runge-kutta  
        //k1 = derivatives[0]
        //k2 = derivatives[1]
        //k3 = derivatives[2]
        //k4 = derivatives[3]
        //yn+1 =  yn + h * (1/6*k1 + 2/6*k2 + 2/6*k3 + 1/6*k4)
        //tn+1 = tn + h

        ProjectileODEData result = new ProjectileODEData(this);

        Vector3 dxdt = (derivatives[0].Position + 2.0f * derivatives[1].Position + 2.0f * derivatives[2].Position + derivatives[3].Position) / 6.0f;
        Vector3 dvdt = (derivatives[0].Velocity + 2.0f * derivatives[1].Velocity + 2.0f * derivatives[2].Velocity + derivatives[3].Velocity) / 6.0f;

        result.Position += Time.fixedDeltaTime * dxdt;
        result.Velocity += Time.fixedDeltaTime * dvdt;

        return result;
    }
}
