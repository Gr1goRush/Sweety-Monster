using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSettingsProvider : MonoBehaviour
{
    [SerializeField] private ToggleIcon _vibroToggleIcon;
    [SerializeField] private ToggleIcon _musicToggleIcon;
    [SerializeField] private ToggleIcon _soundToggleIcon;

    private void Start()
    {
        UpdateView();
    }

    private void OnEnable()
    {
        Settings.OnSettingsChanged += UpdateView;
    }
    private void OnDisable()
    {
        Settings.OnSettingsChanged -= UpdateView;
    }

    public void SwitchVibroState()
    {
        Settings.VibroEnabled = !Settings.VibroEnabled;
    }

    public void SwitchMusicState()
    {
        Settings.MusicEnabled = !Settings.MusicEnabled;
    }

    public void SwitchSoundState()
    {
        Settings.SoundsEnabled = !Settings.SoundsEnabled;
    }

    public void UpdateView()
    {
        _vibroToggleIcon.SetEnabled(Settings.VibroEnabled);
        _musicToggleIcon.SetEnabled(Settings.MusicEnabled);
        _soundToggleIcon.SetEnabled(Settings.SoundsEnabled);
    }

    public void SetPause(bool state)
    {
        Settings.GameIsPaused = state;
    }
}
