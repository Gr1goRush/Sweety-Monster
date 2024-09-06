using UnityEngine;
using UnityEngine.Events;

public class MenuController : MonoBehaviour
{
    [SerializeField] private MenuWindow[] _windows;

    public UnityEvent OnNewWindowOpen;

    public void OpenWindow(int windowIndex)
    {
        OnNewWindowOpen.Invoke();
        CloseAllWindows();
        _windows[windowIndex].ToggleActive(true);
    }

    public void CloseAllWindows()
    {
        foreach (var window in _windows)
        {
            window.ToggleActive(false);
        }
    }
}
