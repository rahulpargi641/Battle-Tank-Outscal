using UnityEngine;
using System;

public class GameAudioController
{
    GameAudioModel soundModel;
    Sound[] sounds;

    bool isMute;

    float originalPitch;

    public GameAudioController(GameAudioModel soundModel)
    {
        this.soundModel = soundModel;
    }

    public GameAudioController()
    {
    }

    public void OnStart()
    {
        originalPitch = soundModel.MovementAudioSrc.pitch;
    }

    private AudioClip GetSoundClip(SoundTypes soundType)
    {
        Sound item = Array.Find(sounds, item => item.sound == soundType);
        if (item != null)
            return item.audioClip;
        else
            return null;
    }

    public void PlayEngineSound(SoundTypes sound)
    {
        if (isMute) return;

        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundModel.MovementAudioSrc.clip = clip;
            soundModel.MovementAudioSrc.Play();
        }
        else
        {
            Debug.LogError("Clip not found for sound types" + sound);
        }
    }

    public void PlayBgMusic(SoundTypes sound)
    {
        if (isMute) return;

        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundModel.BacgroundMusicAudioSrc.clip = clip;
            soundModel.BacgroundMusicAudioSrc.Play();
        }
        else
        {
            Debug.LogError("Clip not found for sound types" + sound);
        }
    }

    public void Mute(bool status)
    {
        isMute = status;
    }

    [Serializable]
    public class Sound
    {
        public SoundTypes sound;
        public AudioClip audioClip;
    }

    public void Stop(SoundTypes soundType)
    {
        // Stop the currently playing sound if it matches the specified type
        //if (audioSource.isPlaying && audioSource.clip != null && audioSource.clip.name == soundType.ToString())
        //{
        //    audioSource.Stop();
        //}
    }
}
