using UnityEngine;
using System.Collections;

public class ChangeMaterial : MonoBehaviour {
    public MeshRenderer _targetObject;
    Material _originMat;
    [SerializeField]
    Material _changeMat;

    bool _isChanged = false;

    void Start()
    {
        _originMat = _targetObject.material;
    }

    public void Change()
    {
        Debug.Log("mat change");

        switch (_isChanged)
        {
            case false:
                _targetObject.material = _changeMat;
                break;

            case true:
                _targetObject.material = _originMat;
                break;
        }

        _isChanged = !_isChanged;
    }
}
