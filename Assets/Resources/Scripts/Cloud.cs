using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{
    TweenValue mTweenVal;
    private ParticleSystem mParticleSystem = null;

    void Start()
    {
        mTweenVal = GetComponent<TweenValue>();
        mParticleSystem = GetComponent<ParticleSystem>();
    }

	// Update is called once per frame
	public void destroyed(float destroyTime)
    {
        mTweenVal.duration = destroyTime;
        mTweenVal.start = mParticleSystem.emissionRate;
        mTweenVal.end = 0f;
        mTweenVal.ResetToBeginning();

        StartCoroutine(updateDestruction());
    }

    IEnumerator updateDestruction()
    {
        while(true)
        {
            mParticleSystem.emissionRate = (int)mTweenVal.curValue;

            if (mTweenVal.curValue < 0.1f)
            {
                Destroy(this.gameObject);
            }

            yield return null;
        }
    }
}
