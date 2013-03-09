using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 100;
	public int curHealth = 100;
	
	private float healthBarLength = 0;
	
	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI (){
		//GUI.Box(new Rect(10,10,healthBarLength,20), curHealth + "/" + maxHealth);	
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
		
		healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
}
