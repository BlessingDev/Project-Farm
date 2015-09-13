using UnityEngine;
using System.Collections;

public class PlantButton : MonoBehaviour
{
    public PickingBlock mPicker = null;
    public CircularButton mButton = null;

    public virtual void OnPointerEnter()
    {
        mPicker.enabled = false;
    }

    public virtual void OnClick()
    {
        mPicker.enabled = false;
        mPicker._selectedObject.GetComponent<Block>().Plant();
    }

    public virtual void OnRelease()
    {
        Debug.Log("release");
        mPicker.enabled = true;
    }
}
