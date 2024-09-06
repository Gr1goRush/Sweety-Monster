using UnityEngine;

[RequireComponent(typeof(AnimatedText))]
public class BalanceText : MonoBehaviour
{
    [SerializeField, HideInInspector] private AnimatedText mText;

    private void OnValidate()
    {
        mText ??= GetComponent<AnimatedText>();
    }

    private void Awake()
    {
        PlayerBalance.OnBalanceUpdated += UpdateView;
    }
    private void OnDestroy()
    {
        PlayerBalance.OnBalanceUpdated -= UpdateView;
    }

    private void Start()
    {
        UpdateView(PlayerBalance.Money);
    }

    public void UpdateView(int Money)
    {
        mText.text = PlayerBalance.Money.ToString();
        Debug.Log("=============");
        Debug.Log(PlayerBalance.Money);
        Debug.Log(PlayerBalance.Money.ToString());
        Debug.Log("=============");
    }
}
