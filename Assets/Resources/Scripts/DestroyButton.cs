using UnityEngine;
using System.Collections;

public class DestroyButton : PlantButton
{
    public override void OnClick()
    {
        mPicker.enabled = false;
        mPicker._selectedObject.GetComponent<Block>().DestroyOnObject();

    }
}
