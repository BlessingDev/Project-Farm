using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;

    public static UIManager GetInstance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    [Serializable]
    public class UILayer
    {
        public ControlableUI[] mUIs;
        public string mLayerName = "";
    }

    public List<UILayer> mUILayers = new List<UILayer>();

    public void enableLayer(string layerName, bool disableGameObject)
    {
        foreach(var iter in mUILayers)
        {
            if(iter.mLayerName.EndsWith(layerName))
            {
                for(int i = 0; i < iter.mUIs.Length; i++)
                {
                    if (disableGameObject)
                        iter.mUIs[i].gameObject.SetActive(true);
                    else
                        iter.mUIs[i].isAble = true;
                }
            }
        }
    }

    public void disableLayer(string layerName, bool enableGameObject)
    {
        foreach (var iter in mUILayers)
        {
            if (iter.mLayerName.EndsWith(layerName))
            {
                for (int i = 0; i < iter.mUIs.Length; i++)
                {
                    if (enableGameObject)
                        iter.mUIs[i].gameObject.SetActive(true);

                    iter.mUIs[i].isAble = true;
                }
            }
        }
    }
}
