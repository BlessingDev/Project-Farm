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
            if(mButtons.isAbled && mPicker._selectedObject != null)
            {
                //Debug.Log("mButton is able");
                Vector3 screenPos = Camera.main.WorldToScreenPoint(mPicker._selectedObject.transform.position);

                mButtons.transform.position = screenPos;
            }

            if(mPicker.isPicking && mPicker._selectedObject != mBefPicked && mPicker._selectedObject != null)
            {
                Debug.Log("mPicker is picked");
                if (mBefPicked != null &&
                    mBefPicked.tag.Equals("Selectable"))
                {
                    mBefPicked.GetComponent<ChangeMaterial>().Change();
                }
                    

                mBefPicked = mPicker._selectedObject;
                mButtons.OnTouch();
                mPicker._selectedObject.GetComponent<ChangeMaterial>().Change();
            }

            if(!mPicker.isPicking && mPicker._selectedObject != null)
            {
                Debug.Log("mPicker is not picked and mouse is down");
                mPicker._selectedObject.GetComponent<ChangeMaterial>().Change();
                mPicker._selectedObject = null;
                mBefPicked = null;
                mButtons.invokeDiable();
            }

            yield return null;
        }
    }
}
