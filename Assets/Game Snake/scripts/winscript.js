
function OnGUI () {
	if (GUI.Button(Rect(Screen.width/2 - 200, Screen.height/2 - 200, 400, 50), "Replay the game")){
	Application.LoadLevel("snakescene");
	}
	
	else if (GUI.Button(Rect(Screen.width/2 - 200, Screen.height/2 - 100, 400, 50), "Exit")){
	Application.LoadLevel("MenuSnake");
	}
	}