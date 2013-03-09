using UnityEngine;
using System.Collections;

public class HSGUIScript : MonoBehaviour {

	[SerializeField]
	private float killCount,scrollSpeed;
	[SerializeField]
	private string score;
	
	public float KillCount{
		get {return killCount;}
		set {killCount = value;}
	}
	public float ScrollSpeed{
		get {return scrollSpeed;}
		set {scrollSpeed = value;}
	}
	public string Score{
		get {return score;}
		set {score = value;}
	}
	
	// Use this for initialization
	void Start () {
		
		LoadScores ();
	}
	void OnGUI(){
		GUILayout.BeginVertical();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Kill Count            = ");
		GUILayout.Label(killCount.ToString());
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Ship sunken in meters = ");
		GUILayout.Label(scrollSpeed.ToString());
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Total Score           = ");
		GUILayout.Label(score);
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2,75,50), "Back")){
			Application.LoadLevel("MenuScene");
		}
		GUILayout.EndHorizontal();
		GUILayout.EndVertical();
	}
	// Update is called once per frame
	void Update () {
	}
	public void LoadScores(){
		GameSettings gs = GameObject.Find("__GameSettings").GetComponent<GameSettings>();
		gs.LoadScores();	
	}
}
