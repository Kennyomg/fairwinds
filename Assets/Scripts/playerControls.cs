using UnityEngine;
using System.Collections;
using SmoothMoves;
[RequireComponent(typeof (CharacterController))]

public class playerControls : MonoBehaviour {
	
	//Fields
	private string meter;
	[SerializeField]
	private float jumpSpeed = 3.0f;
	[SerializeField]
	private float gravity = 15.0f;
	[SerializeField]
	private float scrollSpeed;
	[SerializeField]
	private bool godMode = false;
	[SerializeField]
	private bool facingLeft = true;
	[SerializeField]
	private bool walk = false;
	[SerializeField]
	private Animation anim;
	[SerializeField]
	private float yPos;
	private GameObject player, col;
	private CharacterController controller;
	
    public GameObject Player{
		get{ return this.player; }
	}
	public float YPos{
		get{ return this.yPos; }
	}
	
	Vector3 moveDirection = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		anim = gameObject.GetComponentInChildren<Animation>();
		anim.Play("idle");
		player = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject go = GameObject.FindGameObjectWithTag("LS");
		ListShip ls = (ListShip)go.GetComponent("ListShip");
		scrollSpeed = ls.ScrollSpeed;
		col = GameObject.FindGameObjectWithTag("Platform");
		if(godMode == false){
			if (Input.GetKey (KeyCode.G)&&Input.GetKey (KeyCode.H)&&Input.GetKey (KeyCode.J)){
				godMode = true;
			}
			if (controller.isGrounded) {
				//print("stuck");
	            transform.parent = col.transform;
		        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		        moveDirection = transform.TransformDirection(moveDirection);
		        
				if (Input.GetButton ("Jump")) {
		           	moveDirection.y = jumpSpeed;
					//print("not stuck");
	            	transform.parent = null;
					
					if(walk == true){
						anim.Stop();
						anim.Play("jump airborne");
						walk = false;
					}else{
						anim.Stop();
						anim.Play ("jump airborne");
						walk = true;
					}
					
		        }
			}else{
				moveDirection.x = Input.GetAxis ("Horizontal");
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection.y -= (gravity * Time.deltaTime);
			}
		}else{
			if (Input.GetKey (KeyCode.G)&&Input.GetKey (KeyCode.H)&&Input.GetKey (KeyCode.J)){
				godMode = false;
			}
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis ("Vertical"), 0);
		    moveDirection = transform.TransformDirection(moveDirection);
		}
		
		// Move the controller
	    controller.Move(moveDirection * Time.deltaTime);
		Vector3 temp = transform.localScale;
		if(Input.GetKeyDown(KeyCode.A) && facingLeft == false){
			temp.x = -transform.localScale.x;
			facingLeft = true;
		}
		else if(Input.GetKeyDown(KeyCode.D) && facingLeft == true)
		{
			temp.x = -transform.localScale.x;
			facingLeft = false;
		}
		if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && (transform.parent != null)){
			if(walk == false){
				anim.Stop();
				anim.Play("run");
				walk = true;
			}
		}
		else if(transform.parent != null){
			if(walk == true){
				anim.Stop();
				anim.Play("idle");
				walk = false;
			}
		}
		if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && transform.parent == null){
			walk = false;
		}
		else if(transform.parent == null){
			walk = true;
		}
		
		transform.localScale = temp;
		
		
		yPos = transform.localPosition.y;
		int d = (int)yPos;
		meter = d.ToString();
	}
	void OnTriggerStay(Collider other) {
		if (other.transform.tag == "Dead")
        {
			GameSettings gs = GameObject.Find("__GameSettings").GetComponent<GameSettings>();
			gs.SaveScores();
			Application.LoadLevel("MenuScene");
		}
	}
	void OnGUI ()
	{
		if(transform.localPosition.y > 1.5f){
			GUI.Box(new Rect(((transform.position.x * 100) + (Screen.width/2)),(Screen.height - 20),30,20), meter);
		}
	}

	
}
