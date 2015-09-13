using UnityEngine;
using System.Collections;

public class PlantButton : MonoBehaviour
{
    public PickingBlock mPicker = null;
    public CircularButton mButton = null;

    public void OnClick()
    {
        mPicker.enabled = false;
        mPicker._selectedObject.GetComponent<Block>().Plant();
        mButton.invokeDiable();
    }

    public void OnRelease()
    {
        Debug.Log("release");
        mPicker.enabled = true;
    }
}
