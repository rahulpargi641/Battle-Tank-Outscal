using System;

public class AudioModel
{
    public  AudioClipBox[] audioClipBoxes { get; private set; }
    public AudioSourceBox[] audioSourceBoxes { get; private set; }

    public bool IsMute { get; set; }
    public float OriginalPitch { get; set; }
    public float PitchRange { get; private set; }

    public AudioModel(AudioClipBox[] soundClips, AudioSourceBox[] soundSources)
    {
        this.audioClipBoxes = soundClips;
        this.audioSourceBoxes = soundSources;

        IsMute = false;
        PitchRange = 0.2f;
    }

    internal void Stop(SoundType soundType)
    {
        throw new NotImplementedException();
    }
}
