using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CircularButton : MonoBehaviour
{
    private TweenPosition[] mTweenPoses = null;

	// Use this for initialization
	void Start ()
    {
        mTweenPoses = transform.GetComponentsInChildren<TweenPosition>();

        for (int i = 0; i < mTweenPoses.Length; i++)
        {
            mTweenPoses[i].gameObject.SetActive(false);
        }
	}
	
    public void OnTouch()
    {
        for(int i = 0; i < mTweenPoses.Length; i++)
        {
            if(!mTweenPoses[i].isActiveAndEnabled)
                mTweenPoses[i].gameObject.SetActive(true);

            mTweenPoses[i].ResetToBeginning();
        }
    }

    public void Disable()
    {
        for (int i = 0; i < mTweenPoses.Length; i++)
        {
            mTweenPoses[i].gameObject.SetActive(false);
        }
    }
}
