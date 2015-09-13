using UnityEngine;
using System.Collections;

public class PlantButton : MonoBehaviour
{
    public PickingBlock mPicker = null;

    public void OnClick()
    {
        mPicker._selectedObject.GetComponent<Block>().Plant();
    }
}
