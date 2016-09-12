using UnityEngine;
using System.Collections;
using System;

class SpringODE : ODE<SpringODEData> {

    public SpringODE(SpringODEData initial) : base(initial) {
    }

    public override SpringODEData Evaluate(SpringODEData initial, SpringODEData derivative, float time, float deltaTime) {
        SpringODEData tmp = new SpringODEData(initial);     //Create a new instance, don't modify data from parameter

        tmp.Velocity += derivative.Velocity * deltaTime;
        tmp.Position += derivative.Position * deltaTime;

        return null;
    }
}
