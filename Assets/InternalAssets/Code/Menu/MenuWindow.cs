using UnityEngine;

public class MenuWindow : MonoBehaviour
{
    [SerializeField] private AnimatedImage[] _imageArray;
    [SerializeField] private AnimatedText[] _textArray;


    public void ToggleActive(bool state)
    {
        for (int i = 0; i < _imageArray.Length; i++)
        {
            _imageArray[i].ToggleActiveSmooth(state);
        }
        for (int i = 0; i < _textArray.Length; i++)
        {
            _textArray[i].ToggleActiveSmooth(state);
        }
    }
}
