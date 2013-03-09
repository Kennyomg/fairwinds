using UnityEngine;
using System.Collections;

public class ResolutionTester : MonoBehaviour {
	
	public float scaleX,scaleY;
	Transform myTransform;
	// Use this for initialization
	void Awake(){
		myTransform = transform;
	}
	
	void Start (){
		
	}
	void OnGUI(){
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.localScale = new Vector3((Screen.width * scaleX),(Screen.height * scaleY),1);
		
	}
}
