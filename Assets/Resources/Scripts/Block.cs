using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    //위에 놓여 있는 오브젝트
    public GameObject mObjectOn = null;

    void Start()
    {

    }

    public void Plant()
    {
        if(mObjectOn == null)
        {
            GameObject obj = PlantManager.GetInstance.Plant("Plant");
            if (obj != null)
            {
                obj.transform.position = transform.position;

                obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, obj.transform.localPosition.y + 0.5f, obj.transform.localPosition.z);

                mObjectOn = obj;
            }
            else
            {
                Debug.LogWarning("obj is null");
            }
        }
    }

    public void Destroy()
    {

    }
}
