using UnityEngine;
using System.Collections;

public class PickingBlock : MonoBehaviour
{
    // Test Code
    public GameObject _selectedObject = null;
    public string layerName = "Block";

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
        StartCoroutine("CoUpdate");
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    public void OnEnable()
    {
        Start();
    }

    IEnumerator CoUpdate()
    {
        while(true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                int layerMask = (1 << LayerMask.NameToLayer(layerName));

                float disturbDis = Mathf.Infinity;
                float hitDis = 0f;
                
                if(Physics.Raycast(ray, out hit, Mathf.Infinity, (1 << LayerMask.NameToLayer("Disturb"))))
                {
                    disturbDis = Vector3.Distance(Camera.main.transform.position, hit.point);
                }

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) 
                {
                    hitDis = Vector3.Distance(Camera.main.transform.position, hit.point);

                    if(hitDis <= disturbDis)
                    {
                        // Work
                        _selectedObject = hit.collider.gameObject;
                        posError = -_selectedObject.transform.position + Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        mPicking = true;
                    }
                }
                else
                {
                    mPicking = false;
                }
            }

            yield return null;
        }
    }
}
