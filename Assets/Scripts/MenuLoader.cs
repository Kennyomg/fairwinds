using UnityEngine;
using System.Collections;

public class MenuLoader : MonoBehaviour {
	[SerializeField]
	GUIText myGUIText;
	[SerializeField]
	private float bubbleScaleX;
	[SerializeField]
	private float bubbleScaleY;
	[SerializeField]
	private float bubblePosX;
	[SerializeField]
	private float bubblePosY;
	[SerializeField]
	private float spacingX;
	[SerializeField]
	private float spacingY;
	[SerializeField]
	private float offsetY,offsetX,scaleY,scaleX;
	[SerializeField]
	private int numberOfButtons;
	[SerializeField]
	private string[] buttonText;
	[SerializeField]
	private GUIStyle myGUIStyle, secondGUIStyle,thirdGUIStyle,hsbgGUIStyle;
	[SerializeField]
	private GUITexture myGUITexture,GUITextureTitle;
	[SerializeField]
	private Camera mainCamera;
	[SerializeField]
	private bool highscoreActive = false;
	[SerializeField]
	private Texture highscoreBg;
	private float killCount,scrollSpeed;
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
	
	
	
	public void Start () {
		GameSettings gs = GameObject.Find("__GameSettings").GetComponent<GameSettings>();
		gs.SetBackgroundResolution(mainCamera,myGUITexture);
		gs.LoadScores();
		myGUIText.text = "<size=21><color=black>\n\n        Score = "+score+"\n        Kills :"+killCount+"\n        Meters :"+scrollSpeed+"</color></size>";
		Vector3 temp = myGUIText.transform.position;
		temp.x = 250;
		temp.y = 250;
		//myGUIText.transform.position = temp;
		myGUIText.enabled = false;
	}
	
	public void Update(){
		if(GUITextureTitle !=null){
			Rect temp = GUITextureTitle.pixelInset;
			temp.width = 373.6f;
			temp.height = scaleY;
			temp.x = -186.8f;
			temp.y = 120f;
			GUITextureTitle.pixelInset = temp;
		} 
	}
	
	public void OnGUI () {
		if(highscoreActive){
			GUI.Box(new Rect(((Screen.width/2)-300f),(Screen.height/2)-100f,600f,300f),myGUIText.text,hsbgGUIStyle);
			myGUIText.enabled = true;
			
	}
		this.GUIButtons();
	}
	
	public void GUIButtons(){
		if(GUI.Button(new Rect(bubblePosX,bubblePosY + (spacingY * 0),bubbleScaleX,bubbleScaleY), "", myGUIStyle)){
				Application.LoadLevel("PlayScene");
		}
		if(highscoreActive == false){
			if(GUI.Button(new Rect(bubblePosX + spacingX,bubblePosY + (spacingY * 1),bubbleScaleX,bubbleScaleY), "", secondGUIStyle)){
				highscoreActive = true;
			}
		}else{
			if(GUI.Button(new Rect(bubblePosX + spacingX,bubblePosY + (spacingY * 1),bubbleScaleY,bubbleScaleY), "", thirdGUIStyle)){
				highscoreActive = false;
				myGUIText.enabled = false;
			}
		}
		
	}
	

}