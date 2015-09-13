using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudGenerator : MonoBehaviour
{
    public GameObject cloudParticle = null;
    public GameObject rotatingObject = null;
    public float topY = 0f;
    public float bottomY = 0f;
    public float spawnTurm = 1.0f;
    public float turmError = 0.1f;
    public float speedPerFrame = 0.01f;

    private List<GameObject> clouds = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        spawnCloud();
        StartCoroutine(cloudUpdate());
	}
	
    float getRandomTime()
    {
        float error = Random.Range(0f, turmError);

        return spawnTurm + turmError;
    }

    void spawnCloud()
    {
        GameObject cloud = Instantiate(cloudParticle) as GameObject;
        cloud.transform.SetParent(rotatingObject.transform);

        float randomY = Random.Range(bottomY, topY);

        cloud.transform.localPosition = new Vector3(cloud.transform.localPosition.x, randomY);

        clouds.Add(cloud);

        Invoke("spawnCloud", getRandomTime());
    }

    IEnumerator cloudUpdate()
    {
        foreach(var iter in clouds)
        {
            Vector3 chLocal = iter.transform.localPosition;

            chLocal.x += speedPerFrame;

            iter.transform.localPosition = chLocal;
        }

        yield return null;
    }
}
