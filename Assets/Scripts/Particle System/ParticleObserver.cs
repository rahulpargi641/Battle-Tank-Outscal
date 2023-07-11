using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ParticleObserver
{
    void HandleParticleEvent(ParticleEvent particleEvent);
}
