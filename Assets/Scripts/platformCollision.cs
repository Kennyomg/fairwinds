using UnityEngine;
using System.Collections;

public class platformCollision : MonoBehaviour {
	[SerializeField]
	private Transform target;
	void start(){
		
		
	}
	private void Update(){
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		target = go.transform;
		BoxCollider boxCollider = GetComponent<BoxCollider>();
		
		if(target.position.y > transform.position.y){
			boxCollider.enabled = true;
		}
		else
		{
			boxCollider.enabled = false;
		}
	}
	
	
}
