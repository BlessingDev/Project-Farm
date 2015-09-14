using UnityEngine;
using System.Collections;

public class ChangeMaterial : MonoBehaviour {
    public MeshRenderer _targetObject;
    public Material _originMat;
    [SerializeField]
    Material _changeMat;

    bool _isChanged = false;

    public void Change()
    {
        Debug.Log("mat change");

        switch (_isChanged)
        {
            case false:
                _originMat = _targetObject.material;
                _targetObject.material = _changeMat;
                break;

            case true:
                _targetObject.material = _originMat;
                break;
        }

        _isChanged = !_isChanged;
    }
}
