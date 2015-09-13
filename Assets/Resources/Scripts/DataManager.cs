using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PriceData
{
    public string _type;
    public int _price;
}

[System.Serializable]
public class ItemData : PriceData
{

}

[System.Serializable]
public class BlockData : PriceData
{
    // 재배 시작 계절
    public Season _cultureSeason;

    // 수확 시작 계절
    public Season _harvestSeason;

    public Object _blockPrefab;
}

public class DataManager : MonoBehaviour
{
    private static DataManager _instance = null;
    public List<PriceData> _priceDataList;

    void Awake()
    {
        _instance = this;
    }

    public static DataManager Instance
    {
        get
        {
            if(Debug.isDebugBuild &&
                _instance == null)
            {
                Debug.Log("DataManager was not Initialized");
            }

            return _instance;
        }
    }

}
