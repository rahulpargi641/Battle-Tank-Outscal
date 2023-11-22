using UnityEngine;


[System.Serializable]
public class Sound
{
    [SerializeField] SoundType soundType;
    [SerializeField] AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1f;

    [Range(0.1f, 3f)]
    public float pitch = 1f;

    public bool loop = false;

    private AudioSource audioSource;

    public SoundType SoundType => soundType;
    public AudioClip AudioClip => clip;

    public void Initialize(AudioSource audioSource)
    {
        this.audioSource = audioSource;
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.loop = loop;
    }

    public void Play()
    {
        if (audioSource != null)
            audioSource.Play();
    }

    public void Stop()
    {
        if (audioSource != null)
            audioSource.Stop();
    }

    public void Pause()
    {
        if (audioSource != null)
            audioSource.Pause();
    }

    public void UnPause()
    {
        if (audioSource != null)
            audioSource.UnPause();
    }

    public bool IsPlaying()
    {
        return audioSource != null && audioSource.isPlaying;
    }
}
