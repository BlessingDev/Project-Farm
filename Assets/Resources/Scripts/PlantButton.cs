using UnityEngine;
using System.Collections;

public class PlantButton : MonoBehaviour
{
    public PickingBlock mPicker = null;
    public CircularButton mButton = null;

    protected ControlableUI conUI = null;

    protected virtual void Start()
    {
        conUI = GetComponent<ControlableUI>();
    }

    public virtual void OnPointerEnter()
    {
        bool chk = true;
        if (conUI != null && !conUI.isAble)
            chk = false;

        mPicker.enabled = false;
    }

    public virtual void OnClick()
    {
        bool chk = true;
        if (conUI != null && !conUI.isAble)
            chk = false;

        mPicker.enabled = false;
        mPicker._selectedObject.GetComponent<Block>().Plant();
    }

    public virtual void OnRelease()
    {
        bool chk = true;
        if (conUI != null && !conUI.isAble)
            chk = false;

        Debug.Log("release");
        mPicker.enabled = true;
    }
}
