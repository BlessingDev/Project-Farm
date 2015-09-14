using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    public GameObject mGrass = null;
    public GameObject mRotatingObject = null;
    public Vector2 mMapSize = new Vector2(5, 5);
    public List<Block> mBlocks = new List<Block>();

	// Use this for initialization
	void Start ()
    {
	    for(int i = 0; i < mMapSize.x; i++)
        {
            for(int j = 0; j < mMapSize.y; j++)
            {
                GameObject obj = Instantiate(mGrass, Vector3.zero, Quaternion.identity) as GameObject;
                obj.transform.SetParent(mRotatingObject.transform, true);
                obj.transform.localPosition = new Vector3(i - (int)(mMapSize.x / 2), 0, (int)(j - mMapSize.y / 2));
                mBlocks.Add(obj.GetComponent<Block>());
            }
        }
	}
}
