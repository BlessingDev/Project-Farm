using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickingBlock : MonoBehaviour
{
    // Test Code
    public GameObject _selectedObject = null;
    public string layerName = "Block";
    public List<string> blockLayerName = new List<string>();

    private ControlableUI conUI = null;
    private Vector3 posError;
    private bool mPicking = false;

    public Vector3 GetPosError
    {
        get
        {
            return posError;
        }
    }

    public bool isPicking
    {
        get
        {
            return mPicking;
        }
    }

    void Start()
    {
        conUI = GetComponent<ControlableUI>();
        StartCoroutine("CoUpdate");
    }

    public void OnDisable()
    {
        Debug.Log("pickingBlock disabled");
        StopAllCoroutines();
    }

    public void OnEnable()
    {
        Debug.Log("pickingBlock enalbed");
        Start();
    }

    IEnumerator CoUpdate()
    {
        while(true)
        {
            bool chk = true;
            if (conUI != null && !conUI.isAble)
                chk = false;

            if(chk)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    int layerMask = (1 << LayerMask.NameToLayer(layerName));

                    float disturbDis = Mathf.Infinity;
                    float hitDis = 0f;

                    foreach (var iter in blockLayerName)
                    {
                        if (Physics.Raycast(ray, out hit, Mathf.Infinity, (1 << LayerMask.NameToLayer(iter))))
                        {
                            float dis = Vector3.Distance(Camera.main.transform.position, hit.point);
                            if (dis < disturbDis)
                                disturbDis = dis;
                        }
                    }

                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                    {
                        hitDis = Vector3.Distance(Camera.main.transform.position, hit.point);

                        if (hitDis <= disturbDis)
                        {
                            // Work
                            Debug.Log("picked " + layerName);
                            _selectedObject = hit.collider.gameObject;
                            posError = -_selectedObject.transform.position + Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            mPicking = true;
                        }
                        else
                        {
                            mPicking = false;
                        }
                    }
                    else
                    {
                        mPicking = false;
                    }
                }
            }

            yield return null;
        }
    }
}
