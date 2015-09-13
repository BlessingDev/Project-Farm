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

    IEnumerator CoUpdate()
    {
        while(true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                int layerMask = (1 << LayerMask.NameToLayer(layerName));

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) 
                {
                    // Work
                    _selectedObject = hit.collider.gameObject;
                    posError = - _selectedObject.transform.position + Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mPicking = true;
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
