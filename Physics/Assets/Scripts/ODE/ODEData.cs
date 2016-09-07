using UnityEngine;

public abstract class ODEData<E>
    where E : ODEData<E>        //E is a type of ODEData. This avoids the issue of ever having to put the data into an array
{
    public abstract E calculateNextState(E[] derivatives);
}
