using UnityEngine;
using System.Collections;

public abstract class ODE<E>
    where E : ODEData<E>
{

    public E Initial {
        private set;
        get;
    }

    public ODE(E initial) {
        this.Initial = initial;
    }

    public abstract E Evaluate(E state, E derivative, float time, float deltaTime);
}
