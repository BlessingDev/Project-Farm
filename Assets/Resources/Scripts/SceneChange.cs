using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {
	public int SceneNum = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public void ChangScene()
	{
		Application.LoadLevel(SceneNum);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
