using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListShip : MonoBehaviour {
	[SerializeField]
	private GameObject shipBase,shipPart1,shipPart2;
	[SerializeField]
	private List<GameObject> ships;
	[SerializeField]
	Vector3 pos = Vector3.zero; // this is where the Cube will appear when it's instantiated
    Quaternion rot = Quaternion.identity; // Quaternion.identity essentially means "no rotation"
	public float posX, posY,spacingX,spacingY,scrollSpeed;
	[SerializeField]
	private bool move = false;
	private int destroyedCount;
	
	public int DestroyedCount{
        get { return this.destroyedCount; }
		set { this.destroyedCount = value; }
    }
	public float ScrollSpeed{
        get { return this.scrollSpeed; }
    }
	public bool Move{
        get { return this.move; }
    }
	
	void Start () {
		InstantiateShipsStart();
	}
	
	private void startScore(){
		if(Input.GetKeyDown(KeyCode.Space) && move == false)
		{
			move = true;
		}
		if(move){
			if( scrollSpeed < 0.06f){
				scrollSpeed += 0.000014f;
			}
			else
			{
				scrollSpeed = 0.06f;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		startScore();
		if(destroyedCount >= 1){
			ships.RemoveAt(0);
			destroyedCount = 0;
		}
		if(ships.Count < 15){
			pos.y = (-2f + (1.3235f * 15f));
			//Instantiate(shipPart1, pos, rot); // The Instantiate command takes a GameObject, a Vector3 for position and a Quaternion for rotation
			ships.Add(shipPart1);	
		}
	}
	
	void InstantiateShipsStart(){
		ships = new List<GameObject>();	
		pos.y = 0;
		pos.x += 0.4f;
		Instantiate(shipBase, pos, rot);
		ships.Add(shipPart1);
		pos.y = 1.86f;
		pos.x += 0.08f;
		scrollSpeed = 0.0001f;
		while(ships.Count < 50){
			//Instantiate(shipPart1, pos, rot); // The Instantiate command takes a GameObject, a Vector3 for position and a Quaternion for rotation
			pos.y += spacingY;
			ships.Add(shipPart1);
		}
	}
}
