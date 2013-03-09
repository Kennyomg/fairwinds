using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	private GameObject target;
	private float attackTimer;
	private float cooldown;
	[SerializeField]
	private GameObject projectile;
	private GameObject banana;
	// Use this for initialization
	void Start () {
		attackTimer = 0;
		cooldown = 1.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.FindGameObjectWithTag("Player");
		
		if(attackTimer > 0){
			attackTimer -= Time.deltaTime;
		}
		if(attackTimer < 0){
			attackTimer = 0;
		}
		
		
		if(attackTimer == 0){
			//Attack();		
			attackTimer = cooldown;
		}
	}
	
	private void Attack(){
		float distance = Vector3.Distance(target.transform.position,transform.position);
		
		Vector3 dir = (target.transform.position - transform.position).normalized;
		
		float direction = Vector3.Dot(dir,transform.forward);
		
		if(distance <= 1.5f && direction >= 0){
			banana = Instantiate(projectile,new Vector3(transform.position.x,transform.position.y,-0.06563302f),Quaternion.identity) as GameObject;
			banana.name = "Banana";	
		}
	}
}
