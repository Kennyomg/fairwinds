using UnityEngine;
using System.Collections;

public class gameOverState : MonoBehaviour {
	GameSettings gs;
	Camera mainCamera;
	[SerializeField]
	GUITexture myGUITexture;
	
	// Use this for initialization
	void Start () {
		gs = GameObject.Find("__GameSettings").GetComponent<GameSettings>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.R)){ Application.LoadLevel("MenuScene");}
		if(Input.GetKey(KeyCode.Escape)){ Application.Quit();}
		gs.SetBackgroundResolution(mainCamera,myGUITexture);
	}
}
