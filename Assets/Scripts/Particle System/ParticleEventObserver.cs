using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ParticleEventObserver
{
    void HandleParticleEvent(ParticleEvent particleEvent);
}
