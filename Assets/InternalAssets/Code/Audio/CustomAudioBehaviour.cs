using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CustomAudioBehaviour : MonoBehaviour
{
    [SerializeField, HideInInspector] protected AudioSource audioSource;

    private void OnEnable()
    {
        Settings.OnSettingsChanged += OnSettingsUpdated;
    }
    private void OnDisable()
    {
        Settings.OnSettingsChanged -= OnSettingsUpdated;
    }

    protected virtual void OnValidate()
    {
        audioSource ??= GetComponent<AudioSource>();
    }


    protected virtual void OnSettingsUpdated()
    {

    }
}
