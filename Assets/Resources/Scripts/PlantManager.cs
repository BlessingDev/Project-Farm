using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlantManager : MonoBehaviour
{
    [Serializable]
    public struct PlantInfo
    {
        public string mPlantName;
        public GameObject mPlant;
    }

    public List<PlantInfo> mPlantInfo = new List<PlantInfo>();
    public GameObject mRotatingObject = null;

    private List<Plant> mPlants = new List<Plant>();
    static private PlantManager instance = null;

    public static PlantManager GetInstance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlantManager>();
            }

            if (instance == null)
            {
                GameObject obj = new GameObject();
                instance = obj.AddComponent<PlantManager>();
            }

            return instance;
        }
    }

	// Use this for initialization
	void Start ()
    {
	    
	}
	
    public void PlantDestroyed(Plant plant)
    {
        Debug.Log("plant " + plant + " Destroyed");
        mPlants.Remove(plant);
        Destroy(plant);
    }

    public void PlantRandomDestroy()
    {
        int randIndex = (int)UnityEngine.Random.Range(0, mPlants.Count);

        PlantDestroyed(mPlants[randIndex]);
    }

    public void PlantRandomDestroy(string plantName)
    {
        List<Plant> classified = new List<Plant>();

        foreach (var iter in mPlants)
        {
            if(iter.mPlantName.Equals(plantName))
            {
                classified.Add(iter);
            }
        }

        int randIndex = UnityEngine.Random.Range(0, classified.Count);

        PlantDestroyed(classified[randIndex]);
    }

    public GameObject Plant(string plantName)
    {
        foreach(var iter in mPlantInfo)
        {
            if(iter.mPlantName.Equals(plantName))
            {
                GameObject obj = Instantiate(iter.mPlant) as GameObject;
                obj.transform.SetParent(mRotatingObject.transform);

                return obj;
            }
        }

        return null;
    }
}
