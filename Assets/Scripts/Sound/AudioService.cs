using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoSingletonGeneric<AudioService>
{
    [SerializeField] AudioSourceBox[] soundSources;
    [SerializeField] AudioClipBox[] soundClips;

    private AudioController audioController;
    
    private void Start()
    {
        AudioModel audioModel = new AudioModel(soundClips, soundSources);
        audioController = new AudioController(audioModel);
        audioController.OnStart();
    }

    // Methods for accessing sound-related functionality

    public void PlayEngineSound(float movementInput, float turnInput)
    {
        // Logic for playing the engine sound
        audioController.PlayEngineSound(movementInput, turnInput);
    }

    public void PlayTankExplosionSound()
    {
        audioController.PlayTankExplosionSound();
    }

    public void PlayShotChargingSound()
    {
        audioController.PlayShootingSound(SoundType.ShotCharging);
    }

    public void PlayShotFiringSound()
    {
        audioController.PlayShootingSound(SoundType.ShotFiring);
    }

    public void PlayShellExplosionSound()
    {
        audioController.PlayShellExplosionSound();
    }


    public void Mute(bool status)
    {
        // Logic for muting or unmuting the sound
        audioController.Mute(status);
    }

    public void Stop(SoundType soundType)
    {
        // Logic for stopping the specified sound
        audioController.Stop(soundType);
    }
}
