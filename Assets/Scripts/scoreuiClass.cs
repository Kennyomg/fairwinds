using UnityEngine;
using System.Collections;

public class scoreuiClass : MonoBehaviour
{
	
	[SerializeField]
	private string score;
	[SerializeField]
	private float f, scrollSpeed,scoreMulti;
	[SerializeField]
	private bool move = false;
	[SerializeField]
	private float killCount;
	[SerializeField]
	private int yPos, sM;
	
	public float KillCount{
		get { return this.killCount; }
		set { this.killCount = value; }
	}
	public float ScrollSpeed{
		get { return this.scrollSpeed; }
		set { this.scrollSpeed = value; }
	}
	public string Score{
		get { return this.score; }
		set { this.score = value; }
	}
	// Use this for initialization
	void Start () {
		scoreMulti = 0.0001f;
		
	}

	// Update is called once per frame
	void Update ()
	{
		GameObject go = GameObject.FindGameObjectWithTag("LS");
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		ListShip ls = (ListShip)go.GetComponent("ListShip");
		playerControls pc = (playerControls)player.GetComponent("playerControls");
		yPos = (int)pc.YPos;
		if(yPos <= 0){
		sM = 1000;	
		}else if(yPos == 1){
		sM = 1250;	
		}else if(yPos == 2){
		sM = 1500;	
		}else if(yPos == 3){
		sM = 1750;	
		}else if(yPos >= 4){
		sM = 2000;	
		}
		
		scrollSpeed = ls.ScrollSpeed;
		
		if(Input.GetKey(KeyCode.Space)){move = true;}
		if(move == true){
			scoreMulti += 0.00001f * sM;
			f = scoreMulti + (killCount * 10);
			int d = ((int)f);
			score = d.ToString();
		}
	}
	void OnGUI ()
	{
		if(move == true){
			GUI.Box(new Rect((Screen.width/2),10,30,20), score );
		}
	}
}

