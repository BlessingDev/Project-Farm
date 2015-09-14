using UnityEngine;
using System.Collections;

public class ChangeMaterialWithWeather : MonoBehaviour
{
    public MeshRenderer _meshRenderer = null;
    public Material _springMat = null;
    public Material _summerMat = null;
    public Material _fallMat = null;
    public Material _winterMat = null;

    public ChangeMaterial _changeMat = null;

    public void Start()
    {
        ChangeMaterialWithWeatherManager.Instane._objList.Add(this);
    }

    public void SetMat()
    {
        Material _targetMat = null;

        switch (Timer.Instance.Season)
        {
            case Season.Spring:
                _targetMat = _springMat;
                break;

            case Season.Summer:
                _targetMat = _summerMat;
                break;

            case Season.Fall:
                _targetMat = _fallMat;
                break;

            case Season.Winter:
                _targetMat = _winterMat;
                break;
        }

        if (_meshRenderer != null &&
            _targetMat != null)
        {
            if (_meshRenderer.material != _targetMat)
            {
                if (_changeMat != null)
                {
                    _changeMat._originMat = _targetMat;
                }

                _meshRenderer.material = _targetMat;
            }
        }
    }
}
