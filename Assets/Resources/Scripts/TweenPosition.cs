using UnityEngine;
using System.Collections;

public class TweenPosition : MonoBehaviour
{
    public float duration = 1.0f;
    public Vector3 from;
    public Vector3 to = Vector3.zero;

    private float curTime = 0.0f;
	
    public bool isFinished
    {
        get
        {
            if (curTime / duration > 1f)
                return true;
            else
                return false;
        }
    }

	// Update is called once per frame
	void Update ()
    {
        curTime += Time.deltaTime;

        float rate = curTime / duration;

        Vector3 newPos = Vector3.Lerp(from, to, rate);

        this.transform.localPosition = newPos;
	}
}
