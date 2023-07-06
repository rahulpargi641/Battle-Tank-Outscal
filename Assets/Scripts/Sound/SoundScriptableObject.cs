using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundLibrary", menuName = "ScriptableObjects/SoundScriptableObject")]
public class SoundScriptableObject : ScriptableObject
{
    public AudioSource MovementAudioSrc;
    //public AudioSource ExplosionAudioSrc;
    //public AudioSource ShootingAudioSrc;
    //public AudioSource BacgroundMusicAudioSrc;


    public Sound[] Sounds;
}
