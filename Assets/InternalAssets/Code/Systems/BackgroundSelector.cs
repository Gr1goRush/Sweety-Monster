using UnityEngine;
using UnityEngine.UI;

public class BackgroundSelector : MonoBehaviour
{
    [SerializeField] private Image _backGround;

    [SerializeField] private Sprite[] _spritesArray;

    public void SelectBackground(int id)
    {
        _backGround.sprite = _spritesArray[id];
    }
}
