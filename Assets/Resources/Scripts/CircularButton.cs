using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CircularButton : MonoBehaviour
{
    private TweenPosition[] mTweenPoses = null;
    private bool abled = false;

    public bool isAbled
    {
        get
        {
            return abled;
        }
    }

	// Use this for initialization
	void Start ()
    {
        mTweenPoses = transform.GetComponentsInChildren<TweenPosition>();

        for (int i = 0; i < mTweenPoses.Length; i++)
        {
            if(!mTweenPoses[i].enabled)
                mTweenPoses[i].gameObject.SetActive(false);
        }
	}
	
    public void OnTouch()
    {
        abled = true;
        for(int i = 0; i < mTweenPoses.Length; i++)
        {
            if(!mTweenPoses[i].isActiveAndEnabled)
                mTweenPoses[i].gameObject.SetActive(true);

            mTweenPoses[i].ResetToBeginning();
        }
    }

    private void Disable()
    {
        abled = false;
        for (int i = 0; i < mTweenPoses.Length; i++)
        {
            mTweenPoses[i].gameObject.SetActive(false);
        }
    }

    public void invokeDiable()
    {
        Invoke("Disable", 0.1f);
    }
}
