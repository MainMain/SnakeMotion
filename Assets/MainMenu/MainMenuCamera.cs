using UnityEngine;
using System.Collections;

public class MainMenuCamera : MonoBehaviour {

	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;

	void Start(){
		transform.position = MainMenuSlide.target.transform.position + new Vector3(0,0,-6);
	}

	void Update(){
		transform.position =  Vector3.SmoothDamp(transform.position, MainMenuSlide.target.transform.position + new Vector3(0,0,-6), ref velocity, smoothTime);
	}
}
