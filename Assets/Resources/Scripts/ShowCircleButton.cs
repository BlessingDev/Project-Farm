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
            if(mPicker.isPicking && mPicker._selectedObject != mBefPicked)
            {
                mBefPicked = mPicker._selectedObject;
                Vector3 screenPos = Camera.main.WorldToScreenPoint(mBefPicked.transform.position);

                mButtons.transform.position = screenPos;
                mButtons.OnTouch();
            }

            if(Input.GetMouseButtonDown(0) && !mPicker.isPicking)
            {
                //mButtons.Disable();
            }
            yield return null;
        }
    }
}
