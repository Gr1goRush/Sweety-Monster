using UnityEngine;
using UnityEngine.UI;

public class RewardsTextOperator : MonoBehaviour
{
    [SerializeField] private GameRewardText[] _texts;
    [SerializeField] private Text EndGameText;

    private void OnEnable()
    {
        foreach (var text in _texts)
        {
            PlayerBalance.OnAddMoney += text.UpdateView;
        }
    }

    private void OnDisable()
    {
        foreach (var text in _texts)
        {
            PlayerBalance.OnAddMoney -= text.UpdateView;
        }
    }

    public void UpdateTexts()
    {
        EndGameText.text = GameRewardText.MoneyCount.ToString();
    }
}
