using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameAudioService : MonoSingletonGeneric<GameAudioService>
{
    [SerializeField] SoundScriptableObject soundScriptableObject;
    private GameAudioController gameAudioController;

    public GameAudioService()
    {
        GameAudioModel soundModel = new GameAudioModel(soundScriptableObject);
        gameAudioController = new GameAudioController(soundModel);
    }

    public void PlayEngineSound()
    {
        gameAudioController.PlayEngineSound(SoundTypes.EngineDriving);
    }



    private void Start()
    {
        gameAudioController.OnStart();
    }
}
