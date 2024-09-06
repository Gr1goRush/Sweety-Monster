using UnityEngine;
using UnityEngine.UI;

public class ToggleIcon : MonoBehaviour
{
    [SerializeField, HideInInspector] private Image image;

    public Sprite EnabledSprite;
    public Sprite DisabledSprite;

    private void OnValidate()
    {
        image ??= GetComponent<Image>();
    }

    public void SetEnabled(bool state)
    {
        image.sprite = state ? EnabledSprite : DisabledSprite;
    }
}
