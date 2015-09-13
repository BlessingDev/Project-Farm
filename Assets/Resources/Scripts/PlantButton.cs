using UnityEngine;
using System.Collections;

public class PlantButton : MonoBehaviour
{
    public PickingBlock mPicker = null;
    public CircularButton mButton = null;

    public void OnPointerEnter()
    {
        mPicker.enabled = false;
    }

    public void OnClick()
    {
        Debug.Log("clicke");
        mPicker.enabled = false;
        mPicker._selectedObject.GetComponent<Block>().Plant();
    }

    public void OnRelease()
    {
        Debug.Log("release");
        mPicker.enabled = true;
    }
}
