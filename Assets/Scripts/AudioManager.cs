using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager _AudioManager;

    public AudioSource _AudioSource;

    public AudioClip Die, Wing, Pass;

    private void Awake()
    {
        _AudioManager = this;
    }

    public void PlaySound(AudioClip clip, bool play)
    {
        if (clip != null && play)
        {
            _AudioSource.PlayOneShot(clip);
        }

    }
}
