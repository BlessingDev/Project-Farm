using UnityEngine;
using System.Collections;

public class TweenValue : Tween
{
    public float start = 0f;
    public float end = 0f;

    public float curValue
    {
        get
        {
            float rate = curTime / duration;

            Vector2 curVal = Vector2.Lerp(new Vector2(0, start), new Vector2(duration, end), rate);

            return curVal.y;
        }
    }
}
