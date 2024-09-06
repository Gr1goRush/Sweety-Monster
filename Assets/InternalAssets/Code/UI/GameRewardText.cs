using UnityEngine;

public class GameRewardText : MonoBehaviour
{
    [SerializeField, HideInInspector] private AnimatedText mText;

    private static int moneyCount = 0;
    public bool IsMain;
    public static int MoneyCount => moneyCount;
    public AnimatedText AssignedText => mText;
    private void OnValidate()
    {
        mText ??= GetComponent<AnimatedText>();
    }

    public void Clear()
    {
        moneyCount = 0;
        mText.text = "0";
    }

    private void Start()
    {
      
        moneyCount = 0;
        mText.text = "0";
        Debug.LogWarning("I SUBSCRIBED");
    }

    private void OnEnable()
    {
        mText.text = moneyCount.ToString();
    }

    public void UpdateView(int money)
    {
        if (IsMain)
        {
            moneyCount += money;
        }
        mText.text = moneyCount.ToString();
    }

}
