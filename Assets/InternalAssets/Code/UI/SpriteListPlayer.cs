using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SpriteListPlayer : MonoBehaviour
{
    [SerializeField, HideInInspector] private Image _image;
    public bool PlayOnAwake = true;
    public float LagMod;

    public int EventSample;
    public UnityEvent OnSampleAchieved;

    [SerializeField] private Sprite[] sprites;

    private void OnValidate()
    {
        _image ??= GetComponent<Image>();
    }

    private void Start()
    {
        if (PlayOnAwake)
        {
            StartCoroutine(AnimationRoutine());
        }
    }

    private IEnumerator AnimationRoutine()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            if (i == EventSample) OnSampleAchieved?.Invoke();
            _image.sprite = sprites[i];
            yield return new WaitForSeconds(Time.fixedDeltaTime * LagMod);
        }
    }
}
