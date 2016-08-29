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

    public float Area {
        private set; get;
    } 

    public float DragCoefficient {
        private set; get;
    }

    public ProjectileODEData(ProjectileODEData original) {
        Position = original.Position;
        Velocity = original.Velocity;
        Mass = original.Mass;
        Area = original.Area;
        DragCoefficient= original.DragCoefficient;
    }

    public ProjectileODEData(CustomRigidbody rb) {
        this.rb = rb;
        Position = rb.transform.position;
        Velocity = rb.Properties.Velocity;
        Mass = rb.Properties.Mass;
        Area = rb.Properties.Area;
        DragCoefficient = rb.Properties.DragCoefficient;
    }

    public override ProjectileODEData calculateNextState(ProjectileODEData[] derivatives) {
        ProjectileODEData result = new ProjectileODEData(this);

        Vector3 dxdt = (derivatives[0].Position + 2.0f * (derivatives[1].Position + derivatives[2].Position) + derivatives[3].Position) / 6.0f;
        Vector3 dvdt = (derivatives[0].Velocity + 2.0f * (derivatives[1].Velocity + derivatives[2].Velocity) + derivatives[3].Velocity) / 6.0f;

        result.Position += Time.fixedDeltaTime * dxdt;
        result.Velocity += Time.fixedDeltaTime * dvdt;

        return result;
    }
}
