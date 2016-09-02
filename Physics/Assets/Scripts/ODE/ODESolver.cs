using UnityEngine;
using System.Collections;
using System;

public class ODESolver {
    public static E RungeKutta4<E>(ODE<E> ode, float time)
        where E : ODEData<E>
    {
        E initial = ode.Initial;

        E[] derivatives = new E[4];

        derivatives[0] = ode.Evaluate(initial, initial, time, 0.0f);
        derivatives[1] = ode.Evaluate(initial, derivatives[0], time, 0.5f * Time.fixedDeltaTime);
        derivatives[2] = ode.Evaluate(initial, derivatives[1], time, 0.5f * Time.fixedDeltaTime);
        derivatives[3] = ode.Evaluate(initial, derivatives[2], time, Time.fixedDeltaTime);


        return initial.calculateNextState(derivatives);
    }
}