using System;
using UnityEngine;

public class AudioController
{
    private AudioModel audioModel;
 
    public AudioController(AudioModel audioModel)
    {
        this.audioModel = audioModel;
    }

    public void OnStart()
    {
        AudioSource movementAudioSrc = GetAudioSource(AudioSourceType.MovementAudioSrc);
        audioModel.OriginalPitch = movementAudioSrc.pitch;
    }

    public void PlayEngineSound(float movementInput, float turnInput)
    {
        if (audioModel.IsMute) return;
    
        AudioClip engineIdling = GetAudioClip(SoundType.EngineIdle);
        AudioClip engineDriving = GetAudioClip(SoundType.EngineDriving);
        AudioSource movementAudioSrc = GetAudioSource(AudioSourceType.MovementAudioSrc);

        if (engineIdling != null && engineIdling &&movementAudioSrc != null)
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

    public void PlayShootingSound(SoundType soundType)
    {
        if (audioModel.IsMute) return;

        AudioSource shootingAudioSrc = GetAudioSource(AudioSourceType.ShootingAudioSrc);
        AudioClip explosionClip = GetAudioClip(soundType);
        if (shootingAudioSrc && explosionClip)
        {
            shootingAudioSrc.clip = explosionClip;
            shootingAudioSrc.Play();
        }
        else
        {
            Debug.LogError("Audio source or audio clip not found for Tank Explosion: ");
        }
    }

    internal void PlayTankExplosionSound()
    {
        if (audioModel.IsMute) return;

        AudioSource explosionAudioSrc = GetAudioSource(AudioSourceType.TankExplosionAudioSrc);
        AudioClip explosionClip = GetAudioClip(SoundType.TankExplosion);
        if(explosionAudioSrc && explosionClip)
        {
            explosionAudioSrc.clip = explosionClip;
            explosionAudioSrc.Play();
        }
        else
        {
            Debug.LogError("Audio source or audio clip not found for Tank Explosion: ");
        }
    }

    private float GetVariablePitch(AudioSource movementAudioSrc)
    {
       return UnityEngine.Random.Range(audioModel.OriginalPitch - audioModel.PitchRange, audioModel.OriginalPitch + audioModel.PitchRange);
    }

    public void Mute(bool status)
    {
        audioModel.IsMute = status;
    }

    public void Stop(SoundType soundType)
    {
        audioModel.Stop(soundType);
    }


    public AudioClip GetAudioClip(SoundType soundType)
    {
        AudioClipBox audioCLipBox = FindAudioClipBox(soundType);
        if (audioCLipBox != null)
        {
            return audioCLipBox.audioClip;
        }
        else
        {
            Debug.LogError("Audio clip not found for sound type: " + soundType);
            return null;
        }
    }

    public AudioSource GetAudioSource(AudioSourceType soundType)
    {
        AudioSourceBox audioSourceBox = FindAudioSourceBox(soundType);
        if (audioSourceBox != null)
        {
            return audioSourceBox.audioSource;
        }
        else
        {
            Debug.LogError("Audio Source not found for sound type: " + soundType);
            return null;
        }
    }

    private AudioClipBox FindAudioClipBox(SoundType soundType)
    {
        return Array.Find(audioModel.audioClipBoxes, soundClip => soundClip.soundType == soundType);
    }

    private AudioSourceBox FindAudioSourceBox(AudioSourceType soundType)
    {
        return Array.Find(audioModel.audioSourceBoxes, soundSource => soundSource.audioSourceType == soundType);
    }
}
