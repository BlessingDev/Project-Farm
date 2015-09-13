using UnityEngine;
using System.Collections;

public class EconomyManager : MonoBehaviour
{
    public string _moneyKey = "Money";
    int _money = 0;

    void Start()
    {
        InitializeFromPlayerprefs();
    }

    void InitializeFromPlayerprefs()
    {
        _money = PlayerPrefs.GetInt(_moneyKey, 500);
    }

    public void AddMoney(string priceDataType)
    {
        for(int idx = 0; idx < DataManager.Instance._priceDataList.Count; ++idx)
        {
            if(priceDataType == DataManager.Instance._priceDataList[idx]._type)
            {
                _money += DataManager.Instance._priceDataList[idx]._price;
            }
        }

        PlayerPrefs.SetInt(_moneyKey, _money);
        PlayerPrefs.Save();
    }

    public void MinusMoney(string priceDataType)
    {
        for (int idx = 0; idx < DataManager.Instance._priceDataList.Count; ++idx)
        {
            if (priceDataType == DataManager.Instance._priceDataList[idx]._type)
            {
                _money -= DataManager.Instance._priceDataList[idx]._price;
            }
        }

        PlayerPrefs.SetInt(_moneyKey, _money);
        PlayerPrefs.Save();
    }

    public int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
        }
    }
}
