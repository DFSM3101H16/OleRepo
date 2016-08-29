using UnityEngine;


public abstract class ODEData<E>
    where E : ODEData<E>
{
    public abstract E calculateNextState(E[] derivatives);
}
