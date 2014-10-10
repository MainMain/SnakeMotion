var pickUp : AudioClip;
var arrowPrefab : GameObject;
var initialSpeed = 30.0;
var reloadTime = 0.5;
var arrowCount = 20;
private var lastShot = -10.0;
var launchPosition : GameObject;
var anim : GameObject;
var soundFire : AudioClip;
var waitTime : float = 0.1; 
var arrowGO : GameObject;
private var initSpeed : float;
var layerM : LayerMask;
var font : Font;
var color : Color;
var mainCamera : Camera;
var zoomSpeed : float;
var FOV : float = 30;

public function  Fire() {
	Debug.Log("FIRRREEEE");
	yield WaitForSeconds(waitTime);
	var arrow : GameObject = Instantiate (arrowPrefab, launchPosition.transform.position, launchPosition.transform.rotation);
	anim.animation["Shot"].speed = 3;
	anim.animation.Play("Shot");
	
	audio.clip = soundFire;
	audio.Play();
	arrowGO.renderer.enabled = false; 

	//Physics.IgnoreCollision(instantiatedProjectile.collider, transform.root.collider);
	
	lastShot = Time.time;
	yield WaitForSeconds(1);
	anim.animation["Shot"].speed = -3;
	anim.animation.Play("Shot");
	arrowGO.renderer.enabled = true;
}


