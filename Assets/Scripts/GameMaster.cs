using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	[SerializeField]
	private GameObject __GameSettings;
	
	// Use this for initialization
	void Awake () {
		if(!GameObject.Find("__GameSettings"))
		{
			GameObject gs = Instantiate(__GameSettings, Vector3.zero,Quaternion.identity) as GameObject;
			gs.name = "__GameSettings";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
