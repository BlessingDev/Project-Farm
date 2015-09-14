using UnityEngine;
using System.Collections;

public enum Season
{
    Spring,
    Summer,
    Fall,
    Winter,
    Unknown
}

[System.Serializable]
public class SeasonData
{
    public Season _seasonType;

    // Range in Year progress
    public float _minRange;
    public float _maxRange;
}

public class Timer : MonoBehaviour
{
    public SeasonData[] _seasonData;

    private static Timer _instance = null;

    public float _globalElasedTime = 0f;
    public float _elasedTime = 0f;
    public float _pausedTime = 0f;

    // Hours per 1 Year
    public float _hoursPerYear = 8760f;

    public int _passedYears = 0;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        // First Initialize ///////////////////////////////////////////
        _globalElasedTime = PlayerPrefs.GetFloat("globalelasedtime", 0f);
        _elasedTime = PlayerPrefs.GetFloat("timerelasedtime", 0f);
        _passedYears = PlayerPrefs.GetInt("passedYears", 0);
        ///////////////////////////////////////////////////////////////

        StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine("TimerUpdate");
    }

    public void StopTimer()
    {
        _globalElasedTime = 0f;
        _elasedTime = 0f;
        StopCoroutine("TimerUpdate");
    }

    public void PauseTimer()
    {
        StartCoroutine("PausedTimeUpdate");
        StopCoroutine("TimerUpdate");
    }

    public void UnPauseTimer()
    {
        StartCoroutine("TimeUpdate");
        StopCoroutine("PausedTimeUpdate");
    }

    public static Timer Instance
    {
        get
        {
            if(Debug.isDebugBuild &&
                _instance == null)
            {
                Debug.Log("Timer Instance is NULL");
            }

            return _instance;
        }
    }

    IEnumerator TimerUpdate()
    {
        while(true)
        {
            _globalElasedTime += Time.deltaTime;
            _elasedTime += Time.deltaTime;

            if (((_elasedTime / 3600f) / _hoursPerYear) >= 1f)
            {
                ++_passedYears;
                _elasedTime = 0f;
            }

            yield return null;
        }
    }

    IEnumerator PausedTimeUpdate()
    {
        while(true)
        {
            _pausedTime += Time.deltaTime;
            yield return null;
        }
    }

    public float PausedTime
    {
        get
        {
            return _pausedTime;
        }
    }

    public float Year
    {
        get
        {
            return (float)_passedYears + ((_elasedTime / 3600f) / _hoursPerYear);
        }
    }

    public float ProgressOfYear
    {
        get
        {
            // (Seconds / (1 Min * 1 Hour)) == (Hours)
            // Return Range: 0.0f ~ 1.0f
            return ((_elasedTime / 3600f) / _hoursPerYear);
        }
    }

    public float GlobalTime
    {
        get
        {
            return _globalElasedTime;
        }
    }

    public Season Season
    {
        get
        {
            float progressOfYear = ProgressOfYear;

            for(int idx = 0; idx < _seasonData.Length; ++idx)
            {
                if(_seasonData[idx]._minRange <= _seasonData[idx]._maxRange)
                {
                    if (_seasonData[idx]._minRange <= progressOfYear &&
                    _seasonData[idx]._maxRange > progressOfYear)
                    {
                        return _seasonData[idx]._seasonType;
                    }
                }
                else
                {
                    if(_seasonData[idx]._minRange >= progressOfYear ||
                        _seasonData[idx]._maxRange <= progressOfYear)
                    {
                        return _seasonData[idx]._seasonType;
                    }
                }
            }

            return Season.Summer;
        }
    }

    public float LeftTimeForYear
    {
        get
        {
            return ((_hoursPerYear * 3600f) - _elasedTime);
        }
    }

    public float LeftTime(Season targetSeason)
    {
        for(int idx=  0; idx < Timer.Instance._seasonData.Length; ++idx)
        {
            if(targetSeason == Timer.Instance._seasonData[idx]._seasonType)
            {
                float maxTimePerYear = _hoursPerYear * 3600f;
                return (maxTimePerYear - _elasedTime) + (maxTimePerYear * Timer.Instance._seasonData[idx]._minRange);
            }
        }

        return 0f;
    }
}