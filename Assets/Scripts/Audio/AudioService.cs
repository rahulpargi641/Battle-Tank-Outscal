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

        if (engineIdling != null && engineDriving != null && movementAudioSrc != null)
        {
            if (IsIdle(movementInput, turnInput))
                SwitchAudioClip(engineDriving, engineIdling);
            else
                SwitchAudioClip(engineIdling, engineDriving);
        }
        else
        {
            Debug.LogError("Audio Source or clip not found for Engine Sound: ");
        }
    }

    private bool IsIdle(float movementInput, float turnInput)
    {
        return Mathf.Abs(movementInput) < 0.1f && Mathf.Abs(turnInput) < 0.1f;
    }

    private void SwitchAudioClip(AudioClip fromClip, AudioClip toClip)
    {
        if (movementAudioSrc.clip == fromClip)
        {
            movementAudioSrc.clip = toClip;
            movementAudioSrc.pitch = GetVariablePitch(movementAudioSrc);
            movementAudioSrc.Play();
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
