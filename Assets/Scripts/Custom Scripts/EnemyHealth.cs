using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public int maxHealth = 100;
	public int curHealth = 100;
	
	private float healthBarLength;
	
	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI (){
	}
	
	public void adjustCurrentHealth(int adj){
		curHealth += adj;
		
		if(curHealth < 0){
			curHealth = 0;	
		}
		if(curHealth >= maxHealth){
			curHealth = maxHealth;
		}
		if(maxHealth < 1){
			maxHealth = 1;	
		}
		if(curHealth == 0){
			GameObject go = GameObject.FindGameObjectWithTag("SUI");
			scoreuiClass sc = (scoreuiClass)go.GetComponent("scoreuiClass");
			sc.KillCount += 1;
			Destroy(gameObject);
		}
		healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
}
