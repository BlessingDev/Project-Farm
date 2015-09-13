using UnityEngine;
using System.Collections;

public class Gesture : MonoBehaviour
{
    public Camera _targetCamera;
    public GameObject _targetObject = null;
    public float _rotateSpeed = 3.0f;
    public float _zoomingSpeed = 5.0f;

    public float _minCameraFov = 20f;
    public float _maxCameraFov = 80f;

    public float _prevLength = 0f;

    private Vector2 _objectRotate = Vector2.zero;

    private Vector2 _prevMousePos = Vector2.zero;
    private Vector2 _currentMousePos = Vector2.zero;
    private Vector2 _deltaMousePos = Vector2.zero;

    void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine("CoUpdate");
    }

    IEnumerator CoUpdate()
    {
        while(true)
        {
            #region Mouse Gesture Detect Region
            // Rotate Object
            if(Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                
                switch(touch.phase)
                {
                    case TouchPhase.Moved:
                        _objectRotate.y = -(touch.deltaPosition.x * _rotateSpeed * Time.deltaTime);
                        _targetObject.transform.Rotate(_objectRotate, Space.Self);
                        break;

                    case TouchPhase.Ended:

                        break;
                }
            }

            // Zoming Camera
            else if(Input.touchCount >= 2)
            {
                Debug.Log("is on zoom");
                Touch touch1 = Input.GetTouch(0);
                Touch touch2 = Input.GetTouch(1);

                if(touch1.phase == TouchPhase.Began ||
                    touch2.phase == TouchPhase.Began)
                {
                    _prevLength = (touch1.position - touch2.position).sqrMagnitude;
                }

                if(touch1.phase == TouchPhase.Moved &&
                    touch2.phase == TouchPhase.Moved)
                {
                    float length = (touch1.position - touch2.position).sqrMagnitude;

                    float cameraFov = _targetCamera.fieldOfView;
                    if (length < _prevLength)
                    {
                        cameraFov = Mathf.Clamp(cameraFov + (_zoomingSpeed * Time.deltaTime), _minCameraFov, _maxCameraFov);
                    }
                    else
                    {
                        cameraFov = Mathf.Clamp(cameraFov + (-_zoomingSpeed * Time.deltaTime), _minCameraFov, _maxCameraFov);
                    }

                    _targetCamera.fieldOfView = cameraFov;
                    _prevLength = length;
                }
            }
            #endregion

            yield return null;
        }
    }

}
