using System.Collections;
using UnityEngine;

public class MusicPlayer : CustomAudioBehaviour
{
    private void Start()
    {
        audioSource.mute = !Settings.MusicEnabled;
    }

    public void SmoothChangeMusic(AudioClip clip)
    {
        StartCoroutine(SmoothChangeMusicRoutine(clip));
    }

    private IEnumerator SmoothChangeMusicRoutine(AudioClip clip)
    {
        for (int i = 0; i < 150; i++)
        {
            audioSource.volume -= 0.01f/3;
            yield return new WaitForEndOfFrame();
        }
        audioSource.clip = clip;
        audioSource.Play();
        for (int i = 0; i < 150; i++)
        {
            audioSource.volume += 0.01f/3;
            yield return new WaitForEndOfFrame();
        }
    }

    protected override void OnSettingsUpdated()
    {
        audioSource.mute = !Settings.MusicEnabled;
    }
}
