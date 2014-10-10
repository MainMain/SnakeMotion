#pragma strict
private var cage : GameObject; 
cage = gameObject.Find("iron_cage"); 
var boom : Transform; 
private var key : GameObject;
key = gameObject.Find("key");
private var boomexplo : GameObject;
boomexplo = gameObject.Find("boomexplo");

function Start () {

}

function OnTriggerEnter (objetInfo : Collider) {
if (objetInfo.gameObject.tag == "tete"){
	Destroy(cage);
	key.transform.position.y -=50;
	Instantiate(boom, boomexplo.transform.position, boomexplo.transform.rotation);
	}
}