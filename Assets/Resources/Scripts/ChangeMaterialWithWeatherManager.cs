using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeMaterialWithWeatherManager : MonoBehaviour {
    static ChangeMaterialWithWeatherManager _instance = null;
    public List<ChangeMaterialWithWeather> _objList;

    Season _prevSeason = Season.Unknown;
    
    public static ChangeMaterialWithWeatherManager Instane
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        StartCoroutine("CoUpdate");
    }

    IEnumerator CoUpdate()
    {
        while(true)
        {
            if (_prevSeason != Timer.Instance.Season) 
            {
                if (_objList.Count > 0)
                {
                    for (int idx = 0; idx < _objList.Count; ++idx)
                    {
                        _objList[idx].SetMat();
                    }

                    _prevSeason = Timer.Instance.Season;
                }
            }
            yield return null;
        }
    }

}
