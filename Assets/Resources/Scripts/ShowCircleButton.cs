using UnityEngine;
using System.Collections;

public class ShowCircleButton : MonoBehaviour
{
    public PickingBlock mPicker = null;
    public CircularButton mButtons = null;

    private GameObject mBefPicked = null;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(updatePicking());
	}
	
	IEnumerator updatePicking()
    {
        while(true)
        {
            if(mButtons.isAbled)
            {
                mBefPicked = mPicker._selectedObject;
                Vector3 screenPos = Camera.main.WorldToScreenPoint(mBefPicked.transform.position);

                mButtons.transform.position = screenPos;
            }

            if(mPicker.isPicking && mPicker._selectedObject != mBefPicked)
            {
                mButtons.OnTouch();
            }

            if(Input.GetMouseButtonDown(0) && !mPicker.isPicking)
            {
                Invoke("mButtons.Disable", 0.1f);
            }
            yield return null;
        }
    }
}
