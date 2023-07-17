using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemModel
{
    public ParticleSystemBox[] particleSystemBoxes { get; private set; }

    public ParticleSystemModel(ParticleSystemBox[] particleSystemBoxes)
    {
        this.particleSystemBoxes = particleSystemBoxes;
    }
}
