using UnityEngine;
using System.Collections;

public class TweenPosition : Tween
{
    public Vector3 from;
    public Vector3 to = Vector3.zero;

    protected override IEnumerator updateTime()
    {
        while(true)
        {
            addCurTime();

            float rate = curTime / duration;

            Vector3 newPos = Vector3.Lerp(from, to, rate);

            this.transform.localPosition = newPos;

            if (rate > 1f)
            {
                StopCoroutine(updateTime());
                enabled = false;
            }

            yield return null;
        }
    }
}
