using UnityEngine;
using System.Collections;

public class EnableObjectWithWeather : MonoBehaviour {
    public Season _targetSeason = Season.Summer;
    public GameObject _targetObject = null;
    bool _wasChanged = false;
            
    void Start()
    {
        StartCoroutine("CoUpdate");
    }

    IEnumerator CoUpdate()
    {
        while(true)
        {
            if(Timer.Instance.Season == _targetSeason)
            {
                if (!_targetObject.activeSelf)
                {
                    _targetObject.SetActive(true);
                }
            }
            else
            {
                if(_targetObject.activeSelf)
                {
                    _targetObject.SetActive(false);
                }
            }
            
            yield return null;
        }
    }
}
