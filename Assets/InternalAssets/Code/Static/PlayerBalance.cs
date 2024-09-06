using System;
using UnityEngine;

public static class PlayerBalance
{
    public static event Action<int> OnBalanceUpdated;
    public static event Action<int> OnAddMoney;
    private static readonly string key = "PlBalance";

    public static int Money => PlayerPrefs.GetInt(key);
    

    public static void AddMoney(int value)
    {
        int tmp = PlayerPrefs.GetInt(key);
        tmp += value;
        PlayerPrefs.SetInt(key, tmp);
        OnBalanceUpdated?.Invoke(Money);
        OnAddMoney?.Invoke(value);


    }

    public static void RemoveMoney(int value)
    {
        //if (Money - value < 0) return;

        int tmp = PlayerPrefs.GetInt(key);
        tmp -= value;
        PlayerPrefs.SetInt(key, tmp);
        OnBalanceUpdated?.Invoke(Money);


    }

    public static bool TryPurchase(int Cost)
    {
        if (Cost > Money)
        {
            return false;
        }
        else
        {
            RemoveMoney(Cost);
            return true;
        }
    }
}
