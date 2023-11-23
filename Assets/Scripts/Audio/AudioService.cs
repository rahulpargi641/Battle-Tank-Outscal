using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoSingletonGeneric<AudioService>
{
    [SerializeField] AudioSource movementAudioSrc; // audio source for playing engine idle and engine driving
    [SerializeField] List<Sound> sounds = new List<Sound>();

    private Dictionary<SoundType, Sound> soundDictionary = new Dictionary<SoundType, Sound>();

    private float originalPitch = 1f;
    private float pitchRange = 0.2f;

    protected override void Awake()
    {
        base.Awake();

        foreach (Sound sound in sounds)
        {
            sound.Initialize(gameObject.AddComponent<AudioSource>());
            soundDictionary[sound.SoundType] = sound;
        }
    }

    public void PlayEngineSound(float movementInput, float turnInput)
    {
        AudioClip engineIdling = soundDictionary[SoundType.EngineIdle].AudioClip;
        AudioClip engineDriving = soundDictionary[SoundType.EngineDriving].AudioClip;

        if (engineIdling != null && engineIdling && movementAudioSrc != null)
        {
            if (Mathf.Abs(movementInput) < 0.1f && Mathf.Abs(turnInput) < 0.1f)
            {
                if (movementAudioSrc.clip == engineDriving)
                {
                    movementAudioSrc.clip = engineIdling;
                    movementAudioSrc.pitch = GetVariablePitch(movementAudioSrc);
                    movementAudioSrc.Play();
                }
            }
            else
            {
                if (movementAudioSrc.clip == engineIdling)
                {
                    movementAudioSrc.clip = engineDriving;
                    movementAudioSrc.pitch = GetVariablePitch(movementAudioSrc);
                    movementAudioSrc.Play();
                }
            }
        }
        else
        {
            Debug.LogError("Audio Source or clip not found for Engine Sound: ");
        }
    }

    public void StopEngineSound()
    {
        movementAudioSrc.Stop();
    }

    public void PlaySound(SoundType soundType)
    {
        if (soundDictionary.ContainsKey(soundType))
            soundDictionary[soundType].Play();
    }

    public void StopSound(SoundType soundType)
    {
        if (soundDictionary.ContainsKey(soundType))
            soundDictionary[soundType].Stop();
    }

    private float GetVariablePitch(AudioSource movementAudioSrc)
    {
        return UnityEngine.Random.Range(originalPitch - pitchRange, originalPitch + pitchRange);
    }
}
