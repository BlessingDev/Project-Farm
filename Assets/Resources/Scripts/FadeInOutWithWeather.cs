using UnityEngine;
using System.Collections;

public class FadeInOutWithWeather : MonoBehaviour {
    public Season _targetSeason;
    public ParticleSystem _particle;
    private float _emissionRate = 0f;
    public MeshRenderer _meshRenderer;
    public float _smoothValue = 0.17f;
    private SeasonData _seasonData;

    public float _delta = 0f;

    void Start()
    {
        for(int idx = 0; idx < Timer.Instance._seasonData.Length; ++idx)
        {
            if(_targetSeason == Timer.Instance._seasonData[idx]._seasonType)
            {
                _seasonData = Timer.Instance._seasonData[idx];
                break;
            }
        }

        if(_particle != null)
        {
            _emissionRate = _particle.emissionRate;
        }

        StartCoroutine("CoUpdate");
    }

    IEnumerator CoUpdate()
    {
        while(true)
        {
            if(Timer.Instance.Season == _targetSeason)
            {
                if(_particle != null)
                {
                    _particle.emissionRate = Mathf.Lerp(0f, 
                        _emissionRate, 
                        Mathf.Clamp01((Timer.Instance.ProgressOfYear - _seasonData._minRange
                        / (_seasonData._maxRange - _seasonData._minRange))));
                }
            }
            else
            {
                if (_particle != null)
                {
                    _particle.emissionRate = Mathf.Lerp(_particle.emissionRate,
                        0f, _smoothValue);
                }
            }

            yield return null;
        }
    }
}
