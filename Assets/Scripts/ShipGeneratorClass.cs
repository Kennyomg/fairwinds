using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipGeneratorClass : MonoBehaviour {

	//Velden om alle onderdelen als GameObject te laden
	//alle velden voor de positie and de spacing
	[SerializeField]
	private List<GameObject> baseParts;
	[SerializeField]
	private List<GameObject> climbableParts;
	[SerializeField]
	private List<GameObject> platforms;
	[SerializeField]
	private List<GameObject> objects;
	[SerializeField]
	private int[] rNumbers;
	[SerializeField]
	private GameObject shipPartCanvas;
	private Vector3 pos;
	private Vector3 posLeft;
	private Vector3 posRight;
	private Vector3 offsetLeft;
	private Vector3 offsetRight;
	private int shipCount,shipCountMax;
	bool bo = true;
	bool c = true;
	bool basePartLeftBroken = false;
	bool basePartRightBroken = false;
	
	public int ShipCount{
		get { return this.shipCount; }
		set { this.shipCount = value; }
	}
	
	
	// Use this for initialization
	void Start () {
		pos = new Vector3(-1.2f,1.75f,0f);
		posLeft = new Vector3(-0.2f,1.75f,0f);
		posRight = new Vector3(0.8f,1.75f,0f);
		offsetLeft = new Vector3(0f,0f,0f);
		offsetRight = new Vector3(0f,0f,0f);
		shipCount = 0;
		shipCountMax = 200;
		
	}
	
	// Update is called once per frame
	void Update () {
		//Als een schip onderdeel verdwijnt roep de functie GenerateShip() aan
		
		while(shipCount < shipCountMax){
			shipCount++;
			GenerateShip();
			pos.y += 0.3f;
			posLeft.y += 1.0f;
			posRight.y += 1.0f;
		}
	}
	
	public void GenerateShip(){
		//Maak een random getal kiezer voor elke catagory voor elke positie en daarna een switch case maken voor elk object voor elke category voor elke positie
		//Instantiate the base
		//Pos for the attachment objects = the pos of the base +/- for the object is for the left side or the right side
		GameObject shipPart = Instantiate(shipPartCanvas, pos,Quaternion.identity) as GameObject;
		shipPart.name = "shipPart";
		int a = Random.Range(0,4); //Hoeveel objecten links
		int b = Random.Range(intChecker(a) ,4);//Hoeveel objecten rechts
		print ("a: " + a);
		print ("b: " + b + " intChecker: " + intChecker (a));
		if(basePartLeftBroken == false && basePartRightBroken == false){
			int bPBreakValue = Random.Range (0,20);
			if( bPBreakValue < 4){
				GameObject centralBeamLeft = Instantiate (baseParts[0],posLeft,Quaternion.identity) as GameObject;
				centralBeamLeft.transform.parent = shipPart.transform;
				centralBeamLeft.name = "centralBeamLeft";
				basePartRightBroken = true;
				a = Random.Range(1,4);
				generateShipPartsLeft(centralBeamLeft,a,b);
				//En spawn gebroken rechter basePart
			}else if(bPBreakValue > 16){
				GameObject centralBeamRight = Instantiate (baseParts[0],posRight,Quaternion.identity) as GameObject;
				centralBeamRight.transform.parent = shipPart.transform;
				centralBeamRight.name = "centralBeamRight";
				basePartLeftBroken = true;
				b = Random.Range(1,4);
				generateShipPartsRight(centralBeamRight,a,b);
				//En spawn gebroken linker basePart
			}else{
				GameObject centralBeamLeft = Instantiate (baseParts[0],posLeft,Quaternion.identity) as GameObject;
				centralBeamLeft.transform.parent = shipPart.transform;
				centralBeamLeft.name = "centralBeamLeft";
				GameObject centralBeamRight = Instantiate (baseParts[0],posRight,Quaternion.identity) as GameObject;
				centralBeamRight.transform.parent = shipPart.transform;
				centralBeamRight.name = "centralBeamRight";
				generateShipPartsLeft(centralBeamLeft,a,b);
				generateShipPartsRight(centralBeamRight,a,b);
			}
		}else if(basePartLeftBroken == false && basePartRightBroken == true){
			int bPRegenValue = Random.Range (1,10);
			if(bPRegenValue < 8){
				GameObject centralBeamRight = Instantiate (baseParts[0],posRight,Quaternion.identity) as GameObject;
				centralBeamRight.transform.parent = shipPart.transform;
				centralBeamRight.name = "centralBeamRight";
				basePartRightBroken = false;
				generateShipPartsRight(centralBeamRight,a,b);
			}
			GameObject centralBeamLeft = Instantiate (baseParts[0],posLeft,Quaternion.identity) as GameObject;
			centralBeamLeft.transform.parent = shipPart.transform;
			centralBeamLeft.name = "centralBeamLeft";
			a = Random.Range(1,4);
			generateShipPartsLeft(centralBeamLeft,a,b);
		}else if(basePartLeftBroken == true && basePartRightBroken == false){
			int bPRegenValue = Random.Range (1,10);
			if(bPRegenValue < 8){
				GameObject centralBeamLeft = Instantiate (baseParts[0],posLeft,Quaternion.identity) as GameObject;
				centralBeamLeft.transform.parent = shipPart.transform;
				centralBeamLeft.name = "centralBeamLeft";
				basePartLeftBroken = false;
				generateShipPartsLeft(centralBeamLeft,a,b);
			}
			GameObject centralBeamRight = Instantiate (baseParts[0],posRight,Quaternion.identity) as GameObject;
			centralBeamRight.transform.parent = shipPart.transform;
			centralBeamRight.name = "centralBeamRight";
			b = Random.Range(1,4);
			generateShipPartsRight(centralBeamRight,a,b);
		}
		bo=false;
	}
	private void generateShipPartsLeft(GameObject centralBeamLeft,int a,int b){
		offsetLeft = Vector3.zero;
		if(basePartLeftBroken == false){
			offsetLeft.x -= 0.2f;
			offsetLeft.y -= 0.3f; 
			for (int j = 0; j < a; j++){
				rNumbers[j] = Random.Range(0,2);
				switch (rNumbers[j]) {
					case 0:
						//Instantiate the first gameobject
						GameObject platform1 = Instantiate(platforms[0], posLeft + offsetLeft, Quaternion.identity) as GameObject;
						platform1.transform.parent = centralBeamLeft.transform;
						platform1.name = "platform1";
						offsetLeft.y += 0.3f;
						Debug.Log(0);
					break;
					case 1:
						GameObject platform2 = Instantiate(platforms[1], posLeft + offsetLeft, Quaternion.identity) as GameObject;
						platform2.transform.parent = centralBeamLeft.transform;
						platform2.name = "platform2";
						offsetLeft.y += 0.3f;
						Debug.Log(1);
					break;
					case 2:
						//Instantiate(shipPart1, pos, rot);
						offsetLeft.y += 0.3f;
						Debug.Log(2);
					break;
					case 3:
						//Instantiate(shipPart1, pos, rot);
						Debug.Log(3);
					break;
					case 4:
						//Instantiate(shipPart1, pos, rot);
						Debug.Log(4);
					break;
					case 5:
						//Instantiate(shipPart1, pos, rot);
						Debug.Log(5);
					break;
					case 6:
						//Instantiate a platform
						//Roll a random number 0 to 3
						//0 = nothing on the platform, 1 = enemy, 2 = Moveable/breakable object, 3 = Consumable/pickupable
					if(c){
							//Instantiate(shipPart1, pos, rot);
							Debug.Log(6);
							c = false;
						}else{	
							Debug.Log("Computer says NO");
						}
					break;
					case 7:
						//Instantiate(shipPart1, pos, rot);
						Debug.Log(7);
					break;
					case 8:
						//Instantiate(shipPart1, pos, rot);
						Debug.Log(8);
					break;
					case 9:
						//Instantiate(shipPart1, pos, rot);
						Debug.Log(9);
					break;
					default:
						Debug.Log("Computer says NO");
					break;
				}
			}
		}
	}
	private void generateShipPartsRight(GameObject centralBeamRight, int a,int b){
		offsetRight = Vector3.zero;
		if(basePartRightBroken == false){
			offsetRight.x += 0.2f;
			offsetRight.y -= 0.3f; 
			for (int j = 0; j < b; j++){
				rNumbers[j] = Random.Range(0,2);
				switch (rNumbers[j]) {
					case 0:
						//Instantiate the first gameobject
						GameObject platform1 = Instantiate(platforms[0], posRight + offsetRight, Quaternion.identity) as GameObject;
						Vector3 temp = platform1.transform.localScale;
						temp.x *= -1f;
						platform1.transform.localScale = temp;
						platform1.transform.parent = centralBeamRight.transform;
						platform1.name = "platform1";
						offsetRight.y += 0.3f;
						Debug.Log(0);
					break;
					case 1:
						GameObject platform2 = Instantiate(platforms[1], posRight + offsetRight, Quaternion.identity) as GameObject;
						Vector3 temp2 = platform2.transform.localScale;
						temp2.x *= -1f;
						platform2.transform.localScale = temp2;
						platform2.transform.parent = centralBeamRight.transform;
						platform2.name = "platform2";
						offsetRight.y += 0.3f;
						Debug.Log(1);
					break;
					case 2:
						//Instantiate(shipPart1, pos, rot);
						Debug.Log(2);
					break;
					case 3:
						//Instantiate(shipPart1, pos, rot);
						Debug.Log(3);
					break;
					case 4:
						//Instantiate(shipPart1, pos, rot);
						Debug.Log(4);
					break;
					case 5:
						//Instantiate(shipPart1, pos, rot);
						Debug.Log(5);
					break;
					case 6:
						if(c){
							//Instantiate(shipPart1, pos, rot);
							Debug.Log(6);
							c = false;
						}else{	
							Debug.Log("Computer says NO");
						}
					break;
					case 7:
						//Instantiate(shipPart1, pos, rot);
						Debug.Log(7);
					break;
					case 8:
						//Instantiate(shipPart1, pos, rot);
						Debug.Log(8);
					break;
					case 9:
						//Instantiate(shipPart1, pos, rot);
						Debug.Log(9);
					break;
					default:
						Debug.Log("Computer says NO");
					break;
				}
			}
		}
	}
	//Als er geen objecten links word geplaatst word er minimaal 1 rechts geplaatst
	private int intChecker(int i){
		if (i == 0){
			return 1;
		}
		else{
			return 0;
		}
	}
}
