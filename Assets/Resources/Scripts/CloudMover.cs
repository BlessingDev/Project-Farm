using UnityEngine;
using System.Collections;

public class CloudMover : MonoBehaviour
{
    public CloudGenerator mGenerator = null;

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

                mGenerator.removeAndDestroy(mPicker._selectedObject);
            }

            yield return null;
        }
    }
}
