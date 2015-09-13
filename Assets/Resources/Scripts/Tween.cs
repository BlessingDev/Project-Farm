using UnityEngine;
using System.Collections;

public class Tween : MonoBehaviour
{
    public float duration = 0f;

    protected float curTime = 0f;

	// Use this for initialization
	protected void Start ()
    {
        StartCoroutine(updateTime());
	}

    protected virtual IEnumerator updateTime()
    {
        while(true)
        {
            addCurTime();

            yield return null;
        }
    }

    protected void addCurTime()
    {
        curTime += Time.deltaTime;
    }

    public virtual void ResetToBeginning()
    {
        Debug.Log("reset");
        enabled = true;
        curTime = 0.0f;
        StartCoroutine(updateTime());
    }

    void OnDisable()
    {
        Debug.Log("disabled");
        StopAllCoroutines();
    }
}
