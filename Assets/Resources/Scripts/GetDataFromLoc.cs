using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetDataFromLoc : MonoBehaviour
{
    public string FileName = "";
    public int index = 0;

    private Text text = null;

	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();

        var data = LanguageManager.Instance.ReadTextWithLangSet("Localisation", FileName, new char[] { '\n', '\r' });

        text.text = data[index];
	}
}
