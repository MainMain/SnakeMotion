using UnityEngine;
using System.Collections;

/**
 * Class pour le clique du premier lien du menu
 **/
public class MouseSnakeMenu2 : MonoBehaviour {
	
	TextMesh[] texts;
	public AudioClip sound;
	
	void Start(){
		texts = GetComponentsInChildren<TextMesh>();
	}
	
	void OnMouseEnter(){
		foreach (TextMesh child in texts)
		{
			child.color = Color.red;
		}
	}
	
	void OnMouseExit(){
		foreach (TextMesh child in texts)
		{
			child.color = Color.white;
		}
	}
	
	void OnMouseDown() {
		Application.LoadLevel(13); 
		AudioSource.PlayClipAtPoint(sound, transform.position);
	}
}