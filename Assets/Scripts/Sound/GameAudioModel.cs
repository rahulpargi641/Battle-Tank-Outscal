using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioModel
{
    public AudioSource MovementAudioSrc { private set; get; }
    public AudioSource ExplosionAudioSrc;
    public AudioSource ShootingAudioSrc;
    public AudioSource BacgroundMusicAudioSrc;

    public float m_PitchRange = 0.2f;


    public Sound[] sounds;

    public GameAudioController SoundController { set; private get; }

    public GameAudioModel(SoundScriptableObject soundScriptableObject)
    {
        this.MovementAudioSrc = soundScriptableObject.MovementAudioSrc;
        //this.ExplosionAudioSrc = soundScriptableObject.ExplosionAudioSrc;
        //this.ShootingAudioSrc = soundScriptableObject.ShootingAudioSrc;
        //this.BacgroundMusicAudioSrc = soundScriptableObject.BacgroundMusicAudioSrc;

        this.sounds = soundScriptableObject.Sounds;

    }
}
