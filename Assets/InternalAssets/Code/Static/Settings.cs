using System;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static event Action OnSettingsChanged;

    private static bool _soundsEnabled = true;
    private static bool _musicEnabled = true;
    private static bool _vibroEnabled = true;

    public static bool GameIsPaused;

    public static bool SoundsEnabled
    {
        get
        {
            return _soundsEnabled;
        }
        set
        {
            _soundsEnabled = value;
            OnSettingsChanged?.Invoke();
        }
    }
    public static bool MusicEnabled
    {
        get
        {
            return _musicEnabled;
        }
        set
        {
            _musicEnabled = value;
            OnSettingsChanged?.Invoke();
        }
    }
    public static bool VibroEnabled
    {
        get
        {
            return _vibroEnabled;
        }
        set
        {
            _vibroEnabled = value;
            OnSettingsChanged?.Invoke();
        }
    }


}
