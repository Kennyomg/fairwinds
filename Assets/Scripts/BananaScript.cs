using UnityEngine;
using System.Collections;

public class BananaScript : MonoBehaviour {
	private GameObject player;
//	[SerializeField]
//	private float speed;
	[SerializeField]
	float distanceX,distanceY;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindWithTag("Player");
		PlayerHealth ph = (PlayerHealth)player.GetComponent("PlayerHealth");
		distanceX = Vector3.Distance(player.transform.position,transform.position);
		distanceY = Vector3.Distance(player.transform.position,transform.position);
		Vector3 temp = transform.position;
		if (player.transform.position.y < transform.position.y){
			temp.y -= 0.001f;
		}else{
			temp.y += 0.001f;
		}
		if (player.transform.position.x < transform.position.x){
			temp.x -= 0.001f;
		}else{
			temp.x += 0.001f;
		}
		transform.position = temp;
		if(distanceX > -0.5f && distanceX < 0.5f && distanceY > -0.5f && distanceY < 0.5f){
			ph.adjustCurrentHealth(-10);
			Destroy (this);
		}
	}
}
