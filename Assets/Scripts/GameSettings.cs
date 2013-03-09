using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {
	
	void Awake (){
		DontDestroyOnLoad(this);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.R)){ Application.LoadLevel("MenuScene");}
	}
	public void SaveScores(){
		scoreuiClass suClass = GameObject.Find("ScoreUI").GetComponent<scoreuiClass>();
		
		PlayerPrefs.SetFloat("Kill Count", suClass.KillCount);
		PlayerPrefs.SetFloat("Ship ScrollSpeed", (suClass.ScrollSpeed * 1000f));
		PlayerPrefs.SetString("Score", suClass.Score);
	}
	public void LoadScores(){
		MenuLoader hs = GameObject.FindGameObjectWithTag("ML").GetComponent<MenuLoader>();
		
		hs.KillCount = PlayerPrefs.GetFloat("Kill Count", 0f);
		hs.ScrollSpeed = PlayerPrefs.GetFloat("Ship ScrollSpeed", 0f);
		hs.Score = PlayerPrefs.GetString("Score", "None yet");
	}
	public void SetBackgroundResolution(Camera mainCamera, GUITexture myGUITexture){
		Rect temp = myGUITexture.pixelInset;
		temp.height = mainCamera.GetScreenHeight();
		temp.width = mainCamera.GetScreenWidth();
		temp.y = -(mainCamera.GetScreenHeight()/2);
		temp.x = -(mainCamera.GetScreenWidth()/2);
		myGUITexture.pixelInset = temp;
	}
}
