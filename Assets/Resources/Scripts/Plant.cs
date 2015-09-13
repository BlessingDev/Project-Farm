using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Plant : MonoBehaviour
{
    [Serializable]
    public class PlantState
    {
        public float growthTime = 0.0f;
        public Texture2D texture = null;
    }

    public float maxGrowthScale = 1.5f;
    public float yearForMaxGrowth = 0.5f;
    public string mPlantName = "";
    public Block mBlock = null;
    public List<PlantState> states = new List<PlantState>();

    private float mPlantedTime;
    private SpriteRenderer mSprite;
    private Vector3 basicScale;

	// Use this for initialization
	void Start ()
    {
        mSprite = GetComponent<SpriteRenderer>();
        mPlantedTime = Timer.Instance.Year + Timer.Instance.ProgressOfYear;
        basicScale = transform.localScale;
        StartCoroutine(updatePlant());
	}
	
    IEnumerator updatePlant()
    {
        while(true)
        {
            float growth = (Timer.Instance.Year + Timer.Instance.ProgressOfYear) - mPlantedTime;

            Vector2 curYScale = Vector2.Lerp(new Vector2(0, basicScale.y), new Vector2(yearForMaxGrowth, maxGrowthScale), growth);

            Vector2 localScale = basicScale;
            localScale.y = curYScale.y;

            transform.localScale = localScale;

            foreach(var iter in states)
            {
                if(iter.growthTime <= (Timer.Instance.Year + Timer.Instance.ProgressOfYear) - mPlantedTime)
                {
                    mSprite.sprite = Sprite.Create(iter.texture, new Rect(0, 0, iter.texture.width, iter.texture.height), new Vector2(0.5f, 1.0f));
                    states.Remove(iter);
                    break;
                }
            }

            yield return null;
        }
    }

    public void Destroyed()
    {
        mBlock.mObjectOn = null;
    }
}
