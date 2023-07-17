using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEvent
{
    public ParticleEventType EventType { get; private set; }
    public Vector3 Position { get; private set; }

    public ParticleEvent(ParticleEventType eventType, Vector3 position)
    {
        EventType = eventType;
        Position = position;
    }
}
