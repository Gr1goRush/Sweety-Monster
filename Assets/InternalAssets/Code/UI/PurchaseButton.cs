using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PurchaseButton : MonoBehaviour
{
    public static event Action<string, int> OnNewSelected;

    public UnityEvent OnPurchaseSucces;
    public UnityEvent OnPurchaseFailed;
    public UnityEvent OnSelected;

    [Tooltip("Ключ категории")]
    [SerializeField] private string _selectionKey;

    [Tooltip("Номер в категории")]
    [SerializeField] private int _selectedID;

    [Space(10f)]
    [SerializeField] private string _saveKey;

    [Space(10f)]
    [SerializeField] private int _itemCost;

    [Space(10f)]
    [SerializeField] private Sprite _lockedSprite;
    [SerializeField] private Sprite _unselectSprite;
    [SerializeField] private Sprite _selectedSprite;

    [Space(10f)]
    [SerializeField, HideInInspector] private Image _image;
    [SerializeField] private AnimatedText _costText;

    [SerializeField] private bool _isPurchased;

    [Space(30f)]
    public bool PurchasedFromStart = false;

    private void OnValidate()
    {
        _image ??= GetComponent<Image>();
        if (_costText != null) _costText.text = _itemCost.ToString();
    }

    private void OnEnable()
    {
        OnNewSelected += UpdateView;
    }

    private void OnDisable()
    {
        OnNewSelected -= UpdateView;
    }

    private void Start()
    {
        _isPurchased = PlayerPrefs.GetInt(_saveKey) == 1;
        if (_isPurchased)
        {
            UnlockView();
        }

        if (PurchasedFromStart)
        {
            UnlockCompletly();
            _image.sprite = _selectedSprite;
        }
    }

    public void Interact()
    {
        if (!_isPurchased)
        {
            if (PlayerBalance.TryPurchase(_itemCost))
            {
                UnlockCompletly();
                OnPurchaseSucces?.Invoke();
            }
            else
            {
                OnPurchaseFailed?.Invoke();
            }
        }
        else
        {
            OnNewSelected?.Invoke(_selectionKey, _selectedID);
            OnSelected?.Invoke();
        }
    }

    public void UpdateView(string SelectionKey, int SelectedID)
    {
        if (!_isPurchased || SelectionKey != _selectionKey) { return; }

        _image.sprite = SelectedID == _selectedID ? _selectedSprite : _unselectSprite;

    }

    public void UnlockView()
    {
        if (_isPurchased)
        {
            _costText.gameObject.SetActive(false);
            _costText.text = " ";
            _image.sprite = _unselectSprite;
        }
    }

    public void UnlockCompletly()
    {
        PlayerPrefs.SetInt(_saveKey, 1);
        _isPurchased = true;
        UnlockView();
    }
}
