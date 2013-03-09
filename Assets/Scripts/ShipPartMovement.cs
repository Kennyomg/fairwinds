using UnityEngine;
using System.Collections;

public class ShipPartMovement : MonoBehaviour {
	
	[SerializeField]
	private Transform myTransform;
	[SerializeField]
	private bool move = false;
	[SerializeField]
	float scrollSpeed;
	
	// Use this for initialization
	void Awake(){
		myTransform = transform;
		//gameObject.name = "ShipPart1";
	}
	
	// Update is called once per frame
	void Update () {
		GameObject go = GameObject.FindGameObjectWithTag("LS");
		GameObject sui = GameObject.FindGameObjectWithTag("SUI");
		ListShip ls = (ListShip)go.GetComponent("ListShip");
		ShipGeneratorClass sgc = (ShipGeneratorClass)sui.GetComponent("ShipGeneratorClass");
		scrollSpeed = ls.ScrollSpeed;
		this.gameObject.tag="Schip";
		move = ls.Move;
		
		
		if (move == true){
		Vector3 temp = myTransform.localPosition;
		temp.y = ((myTransform.localPosition.y - scrollSpeed));
		myTransform.localPosition = temp;
			if(temp.y <= -2.0f){
				//sgc.ShipCount--;
				playerControls player = GameObject.FindWithTag("Player").GetComponent<playerControls>();
				player.transform.parent = null;
				//Destroy(this.gameObject);
			}
		}
	}
}
