using UnityEngine;
using System.Collections;

public class TerminateThis : MonoBehaviour
{
    public float mTime = 0f;
    public bool mDestroyFromStart = false;

	// Use this for initialization
	void Start ()
    {
        if (mDestroyFromStart)
            DestroyTrigger();
	}
	
    public void DestroyTrigger()
    {
        Destroy(this.gameObject, mTime);
    }
}
