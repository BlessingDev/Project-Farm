using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SeasonText : MonoBehaviour
{
    private Timer timer = null;
    private Text text = null;

	// Use this for initialization
	void Start ()
    {
        timer = Timer.Instance;
        text = GetComponent<Text>();

        StartCoroutine(textUpdate());
	}
	
    IEnumerator textUpdate()
    {
        while(true)
        {
            Season data = timer.Season;

            switch(data)
            {
                case Season.Spring:
                    text.text = "Spring";

                    break;
                case Season.Summer:
                    text.text = "Summer";

                    break;
                case Season.Fall:
                    text.text = "Autumn";

                    break;
                case Season.Winter:
                    text.text = "Winter";

                    break;
            }

            yield return null;
        }
    }
}
