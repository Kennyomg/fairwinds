using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public GameObject target;
	private float attackTimer;
	private float cooldown;
	
	// Use this for initialization
	void Start () {
		attackTimer = 0;
		cooldown = 1.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.FindGameObjectWithTag("Enemy");
		
		if(attackTimer > 0){
			attackTimer -= Time.deltaTime;
		}
		if(attackTimer < 0){
			attackTimer = 0;
		}
		
		
		if(Input.GetKeyDown(KeyCode.F)){
			if(attackTimer == 0){
				Attack();		
				attackTimer = cooldown;
			}
		}
	}
	
	private void Attack(){
		float distance = Vector3.Distance(target.transform.position,transform.position);
		// Debug.Log(distance);
		
		Vector3 dir = (target.transform.position - transform.position).normalized;
		
		float direction = Vector3.Dot(dir,transform.forward);
		
		if(distance <= 2.5f && direction >= 0){
		EnemyHealth eh = (EnemyHealth)target.GetComponent("EnemyHealth");	
		eh.adjustCurrentHealth(-50);
		}
	}
}
