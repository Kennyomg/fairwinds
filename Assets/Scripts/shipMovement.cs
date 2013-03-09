using UnityEngine;
using System.Collections;

public class shipMovement : MonoBehaviour
{
	//Fields
	//private ListShip s = new ListShip();
	[SerializeField]
	private Transform myTransform;
	[SerializeField]
	private bool move = false;
	[SerializeField]
	float scrollSpeed;
		
	void Awake(){
		myTransform = transform;
		gameObject.name = "ShipPart1";
	}
	void Start(){

	}
	
	
	
	// Update is called once per frame
	void Update()
	{
		GameObject go = GameObject.FindGameObjectWithTag("LS");
		ListShip ls = (ListShip)go.GetComponent("ListShip");
		scrollSpeed = ls.ScrollSpeed;
		
		this.gameObject.tag="Schip";
		if (myTransform.localPosition.x >= 0.4f){
			move = ls.Move;
			if (move == true){
			Vector3 temp = myTransform.localPosition;
			temp.y = ((myTransform.localPosition.y - scrollSpeed));
			myTransform.localPosition = temp;
				if(temp.y == -2.0f || temp.y < -2.0f){
					ls.DestroyedCount += 1;
					playerControls player = GameObject.FindWithTag("Player").GetComponent<playerControls>();
					player.transform.parent = null;
					Destroy(this.gameObject);
				}
			}
		}
		if (myTransform.localPosition.x < 0.04f)
		{
			Vector3 temp = myTransform.localPosition;
			temp.x = (myTransform.localPosition.x + 0.01f);
			myTransform.localPosition = temp;
		}
		
	}

	
}

