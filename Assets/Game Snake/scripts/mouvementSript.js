#pragma strict

var ViteseMouvement = 4.0; 
var VitesseRotation = 3.0; 

function Update () {
var controller: CharacterController = GetComponent(CharacterController);
transform.Rotate(0,Input.GetAxis("Horizontal")* VitesseRotation, 0);

var enAvant = transform.TransformDirection(Vector3.forward);
var VitesseDeplacement= ViteseMouvement * Input.GetAxis("Vertical");

controller.SimpleMove(enAvant * VitesseDeplacement);

}

@script RequireComponent(CharacterController)
