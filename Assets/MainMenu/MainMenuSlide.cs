using UnityEngine;
using System.Collections;

public class MainMenuSlide : MonoBehaviour {

	public Texture textureIn;
	public Texture textureOut;


	private int numTotSlide = 8;
	public static GameObject target;

	void Start(){
	}

	void OnMouseEnter(){
		if(gameObject.name == "SphereLeft" || gameObject.name == "SphereRight"){
			renderer.material.mainTexture = textureIn;
		}
	}
	
	void OnMouseExit(){
		if(gameObject.name == "SphereLeft" || gameObject.name == "SphereRight"){
			renderer.material.mainTexture = textureOut;
		}
	}
	
	void OnMouseDown() {
		if(gameObject.name == "SphereLeft"){
			if(MainMenuScript.numSlide == 1){ MainMenuScript.numSlide = numTotSlide;
			}else if(MainMenuScript.numSlide > 1){ MainMenuScript.numSlide--;}
		}else if(gameObject.name == "SphereRight"){
			if(MainMenuScript.numSlide == numTotSlide){ MainMenuScript.numSlide = 1;
			}else if(MainMenuScript.numSlide < numTotSlide){ MainMenuScript.numSlide++;}
		}

		Debug.Log(MainMenuScript.numSlide);

		if(MainMenuScript.numSlide == 1){
			target = GameObject.Find("Cube1");
		}else if(MainMenuScript.numSlide == 2){
			target = GameObject.Find("Cube2");
		}else if(MainMenuScript.numSlide == 3){
			target = GameObject.Find("Cube3");
		}else if(MainMenuScript.numSlide == 4){
			target = GameObject.Find("Cube5");
		}else if(MainMenuScript.numSlide == 5){
			target = GameObject.Find("Cube6");
		}else if(MainMenuScript.numSlide == 6){
			target = GameObject.Find("Cube7");
		}else if(MainMenuScript.numSlide == 7){
			target = GameObject.Find("Cube8");
		}/*else if(MainMenuScript.numSlide == 8){
			target = GameObject.Find("Cube8");
		}*/


		if(gameObject.name == "Plane1"){
			Application.LoadLevel(1);
		}else if(gameObject.name == "Plane2"){
			Application.LoadLevel(4);
		}else if(gameObject.name == "Plane3"){
			Application.LoadLevel(7);
		}/*else if(gameObject.name == "Plane4"){
			Application.LoadLevel(10);
		}*/else if(gameObject.name == "Plane5"){
			Application.LoadLevel(11);
		}else if(gameObject.name == "Plane6"){
			Application.LoadLevel(12);
		}else if(gameObject.name == "Plane7"){
			Application.LoadLevel(17);
		}else if(gameObject.name == "Plane8"){
			Application.LoadLevel(20);
		}


	}
	
}
