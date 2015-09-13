using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour
{
    private PickingBlock mPicker = null;

	// Use this for initialization
	void Start ()
    {
        mPicker = GetComponent<PickingBlock>();

        StartCoroutine(updateMove());
	}
	
    IEnumerator updateMove()
    {
        while(true)
        {
            if (Input.GetMouseButtonDown(0) && mPicker.isPicking)
            {
                Debug.Log("picked!");
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (mPicker._selectedObject == null)
                    Debug.LogWarning("object null!");
                else
                    mPicker._selectedObject.transform.position = mouseWorldPos;
            }

            yield return null;
        }
    }
}
