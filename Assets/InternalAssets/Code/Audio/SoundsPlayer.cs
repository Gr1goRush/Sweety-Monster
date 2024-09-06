using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPlayer : CustomAudioBehaviour
{
    public static SoundsPlayer Instance;
    private bool _canPlay;
    protected override void OnSettingsUpdated()
    {
        _canPlay = Settings.SoundsEnabled;
    }

    private void Start()
    {
        Instance = this;
        _canPlay = Settings.SoundsEnabled;
    }

    public void PlayShot(AudioClip clip)
    {
        if (!_canPlay) return;
        audioSource.pitch = 1;
        audioSource.PlayOneShot(clip);
    }

    public void PlayWithRandomPitch(AudioClip clip)
    {
        //Debug.Log("PLAY");
        if (!_canPlay) return;
        //Debug.Log("PLAYSUCCES");
        audioSource.pitch = Random.Range(0.3f, 1.4f);
        audioSource.PlayOneShot(clip);
    }
}
