using UnityEngine;
using System.Collections;

public class PickingBlock : MonoBehaviour
{
    // Test Code
    public GameObject _selectedObject = null;

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

                int layerMask = (1 << LayerMask.NameToLayer("Block"));

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) 
                {
                    // Work
                    _selectedObject = hit.collider.gameObject;
                }

            }
            yield return null;
        }
    }
}
