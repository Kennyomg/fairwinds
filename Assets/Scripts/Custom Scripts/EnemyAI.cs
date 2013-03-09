using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using tk2dRuntime;
[RequireComponent(typeof (CharacterController))]

public class EnemyAI : MonoBehaviour {
	private Transform target;
	[SerializeField]
	private List<Transform> platforms;
	private float gravity = 15.0f;
	private Transform myTransform;
	Vector3 moveDirection = Vector3.zero;
	bool facingLeft = false;
	public Transform selectedTarget;
	void Awake(){
		myTransform = transform;
	}
	
	// Use this for initialization
	void Start () {
		selectedTarget = null;
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		
		platforms = new List<Transform>();
	}
	
	public void AddPlatforms(){
		platforms.Clear ();
		GameObject[] pf = GameObject.FindGameObjectsWithTag("Platform");
		
		foreach(GameObject platform in pf){
			AddTarget(platform.transform);	
		}
	}
	public void AddTarget(Transform platform){
		platforms.Add(platform);
	}
	private void sortTargetsByDistance(){
		platforms.Sort(delegate(Transform t1, Transform t2){
			return(Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position)));
		});
	}
	private void TargetEnemy(){
		if(selectedTarget == null){
			sortTargetsByDistance();	
			selectedTarget = platforms[0];
		} else {
			DeslectTarget();
			sortTargetsByDistance();	
			selectedTarget = platforms[0];
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		AddPlatforms();
		TargetEnemy();
		if(selectedTarget == null){
			TargetEnemy();
		}
		
		// Apply gravity
		if(selectedTarget != null){
			if(selectedTarget.position == transform.position){
				transform.parent = selectedTarget.transform;
			}
			else{
				transform.parent = null;
				moveDirection.y -= gravity * Time.deltaTime;
				controller.Move(moveDirection * Time.deltaTime);
			}
		}
		else{
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
		}
		// look at target
		Vector3 temp = transform.localScale;

		
		if(target.position.x > myTransform.position.x && facingLeft == true){
			temp.x = -transform.localScale.x;
			facingLeft = false;
		}
		else if(target.position.x < myTransform.position.x && facingLeft == false)
		{
			temp.x = -transform.localScale.x;
			facingLeft = true;
		}
		transform.localScale = temp;
		
	}
	private void SelectTarget(){
		selectedTarget = platforms[0];
	}
	
	private void DeslectTarget(){	
		selectedTarget = null;
	}
		
}