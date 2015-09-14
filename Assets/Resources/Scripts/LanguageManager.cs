using UnityEngine;
using System.IO;
using System.Collections;

public enum SupportLanguage
{
    English,
    Korean,
    Malay,
    Japanese,
    Chinese
}

public class LanguageManager
{
    private static LanguageManager _instance = null;
    private SupportLanguage _selectedLang = SupportLanguage.English;

    private LanguageManager()
    {

    }

    public static LanguageManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new LanguageManager();
            }

            return _instance;
        }
    }

    public SupportLanguage Language
    {
        get
        {
            return _selectedLang;
        }
        set
        {
            _selectedLang = value;
        }
    }

    // ill be (#langDirPath)\(#Set Lang)\(#FileName)
    public string[] ReadTextWithLangSet(string langDirPath, string fileName, char[] tokens)
    {
        TextAsset textAsset =
            Resources.Load(langDirPath + "/" + _selectedLang.ToString() + "/" + fileName) as TextAsset;

        Debug.Log(langDirPath + "/" + _selectedLang.ToString() + "/" + fileName);
        string data = textAsset.text;

        return (data.Split(tokens, System.StringSplitOptions.RemoveEmptyEntries));
    }

}
