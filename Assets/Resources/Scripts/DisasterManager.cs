using UnityEngine;
using System.Collections;

public class DisasterManager : MonoBehaviour
{


	// Use this for initialization
	void Start ()
    {
        StartCoroutine(updateDisaster());
	}
	
    IEnumerator updateDisaster()
    {
        while(true)
        {

            yield return null;
        }
    }
    
	// Update is called once per frame
	void Update ()
    {
	
	}
}
