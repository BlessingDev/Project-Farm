using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour
{
    private TweenPosition tweenPos;

	// Use this for initialization
	void Start ()
    {
        tweenPos = GetComponent<TweenPosition>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (tweenPos.isFinished)
            Destroy(this.gameObject);
	}
}
