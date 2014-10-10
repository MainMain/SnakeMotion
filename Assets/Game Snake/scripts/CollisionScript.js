#pragma strict
var capsuleSound : AudioClip;
var looseSound : AudioClip;
var couleurs : Transform; 
var looseGame : String;
var theEnd : String;
var winSound : AudioClip; 
var score = 0;
var guiScore : GUIText; 
private var cage : GameObject; 
cage = gameObject.Find("iron_cage"); 
private var Corps1 : GameObject; 
Corps1 = gameObject.Find("Corps1");
private var Corps2 : GameObject; 
Corps2 = gameObject.Find("Corps2");
private var Corps3 : GameObject; 
Corps3 = gameObject.Find("Corps3");
private var Corps4 : GameObject;
Corps4 = gameObject.Find("Corps4");
private var Corps5 : GameObject;
Corps5 = gameObject.Find("Corps5");
private var Corps6 : GameObject;
Corps6= gameObject.Find("Corps6");
private var Corps7 : GameObject;
Corps7 = gameObject.Find("Corps7");
private var Corps8 : GameObject;
Corps8= gameObject.Find("Corps8");
private var Corps9 : GameObject;
Corps9 = gameObject.Find("Corps9");
private var Corps10 : GameObject;
Corps10 = gameObject.Find("Corps10");
private var tete : GameObject;
tete = gameObject.Find("Tête");
private var key : GameObject;
key = gameObject.Find("key");

private var Corps: int = 0; 

Corps1.SetActive(false);
Corps2.SetActive(false);
Corps3.SetActive(false);
Corps4.SetActive(false);
Corps5.SetActive(false);
Corps6.SetActive(false);
Corps7.SetActive(false);
Corps8.SetActive(false);
Corps9.SetActive(false);
Corps10.SetActive(false);
key.SetActive(false);

function Start (){
guiScore.text = "Score: 0"; 
}

function Update() {
if (Corps == 1 ){
Corps1.SetActive(true);
}
if (Corps == 2 ){
Corps2.SetActive(true);
}
if (Corps == 3 ){
Corps3.SetActive(true);
}
if (Corps == 4 ){
Corps4.SetActive(true);
}
if (Corps == 5 ){
Corps5.SetActive(true);
}
if (Corps == 6 ){
Corps6.SetActive(true);
}
if (Corps == 7 ){
Corps7.SetActive(true);
}
if (Corps == 8 ){
Corps8.SetActive(true);
}
if (Corps == 9 ){
Corps9.SetActive(true);
}
if (Corps == 10 ){
Corps10.SetActive(true);
}
if (score >= 10){
key.SetActive(true);
}
}

function OnTriggerEnter (objetInfo : Collider) {
if (objetInfo.gameObject.tag == "caps")
	{
	audio.PlayOneShot(capsuleSound);
	Instantiate(couleurs, transform.position, transform.rotation);
	Destroy(objetInfo.gameObject);
	score += 1;
	guiScore.text = "Score: " + score; 	
	Corps += 1;
	}
else if (objetInfo.gameObject.tag == "water")
	{
	audio.PlayOneShot(looseSound);
	Destroy(tete);
	yield WaitForSeconds(4.0);
	Application.LoadLevel(looseGame);
	}	
else if (objetInfo.gameObject.tag == "fin")
	{
	audio.PlayOneShot(winSound);
	yield WaitForSeconds (3.0); 
	Application.LoadLevel(theEnd);
	}
}