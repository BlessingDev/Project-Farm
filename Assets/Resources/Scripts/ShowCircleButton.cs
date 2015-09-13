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
                //Debug.Log("mButton is able");
                Vector3 screenPos = Camera.main.WorldToScreenPoint(mPicker._selectedObject.transform.position);

                mButtons.transform.position = screenPos;
            }

            if(mPicker.isPicking && mPicker._selectedObject != mBefPicked)
            {
                Debug.Log("mPicker is picked");
                mBefPicked = mPicker._selectedObject;
                mButtons.OnTouch();
            }

            if(!mPicker.isPicking)
            {
                //Debug.Log("mPicker is not picked and mouse is down");
                mBefPicked = null;
                mButtons.invokeDiable();
            }

            yield return null;
        }
    }
}
