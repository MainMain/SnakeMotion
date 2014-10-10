using UnityEngine;
using System.Collections;

/**
 * Enumération du choix du tracking de mains
 **/
public enum PositionMainSnake {Simple, SurPlace, DeuxMain}

/**
 * Class de la page d'option
 * Pour le moment les options sont : 
 * - la vitesse de la balle avec "movementSpeed"
 * - le choix du tracking avec "toolbarInt" et "toolbarString"
 **/
public class OptionSnake : MonoBehaviour {

	public static float movementSpeed = 6.0f;
	public static float slider = 4.0f;
	public static float sensibilite = 4.0f;

	public static int toolbarInt = 0;
	public static string[] toolbarString = {"Une main", "Deux mains"};

	public static PositionMainSnake choice;
	public GUISkin optionSkin;

	void OnGUI(){
		GUI.skin = optionSkin;
		GUI.BeginGroup(new Rect(Screen.width/2-190,Screen.height/2-155,500,500));
		GUI.Label(new Rect (0, 50, 400, 50), "Choix du mouvement : ");
		toolbarInt = GUI.Toolbar (new Rect (0, 110, 400, 50), toolbarInt, toolbarString);
		GUI.Label(new Rect (0, 170, 4700, 50), "Sensibilité : "  + (int)slider);
		GUI.Label(new Rect (0, 230, 50, 50), " 1 ");
		slider = GUI.HorizontalSlider(new Rect (50, 250, 300, 50), slider, 1.0f, 10.0f);
		GUI.Label(new Rect (360, 230, 310, 50), " 10 ");
		GUI.EndGroup ();

		if (GUI.changed){
			if(toolbarInt == 0){
				choice = PositionMainSnake.Simple;
			}else if(toolbarInt == 1){
				choice = PositionMainSnake.DeuxMain;
			}
			sensibilite = (int)slider;
		}



	}

}
