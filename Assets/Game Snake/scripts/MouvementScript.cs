using UnityEngine;
using System.Collections;
using Leap;

[RequireComponent(typeof(CharacterController))]
public class MouvementScript : MonoBehaviour {

	//Récuperation du mouvement en vecteur
	public Vector handPosition;
	
	//Paramétres du mouvement
	private float moveInputX;
	private float moveInputZ;

	private Controller controller;

	private CharacterController charac;
	public static CsvExport export;


	// Use this for initialization
	void Awake() {
		charac = GetComponent<CharacterController>();
	}

	void Start(){
		controller = new Controller();
		export = new CsvExport();
	}
	
	void FixedUpdate()
	{
		if(controller.IsConnected){
			//En fonction du choix de tracking de ou des mainson ajoute
			//De la force à la balle
			if(OptionSnake.choice == PositionMainSnake.Simple && StyleJeuSimple().Count == 2){
				moveInputX = (float)StyleJeuSimple()[0]/15 * OptionSnake.sensibilite;
				moveInputZ = (float)StyleJeuSimple()[1]/15 * OptionSnake.sensibilite;
			}else if(OptionSnake.choice == PositionMainSnake.DeuxMain && StyleJeuDeuxMains().Count == 2){
				moveInputX = (float)StyleJeuDeuxMains()[0]/15 * OptionSnake.sensibilite;
				moveInputZ = (float)StyleJeuDeuxMains()[1]/15 * OptionSnake.sensibilite;
			}
			transform.Rotate(0,moveInputX*OptionSnake.movementSpeed,0);
			charac.SimpleMove(transform.TransformDirection(Vector3.forward) * OptionSnake.movementSpeed * moveInputZ);
		}else{
			Debug.Log("Controller : "+controller);
		}
	}
	
	void Update(){
		if(Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1.0f ){
			Time.timeScale = 0.0f;
		}else if(Time.timeScale == 0.0f && Input.GetKeyDown(KeyCode.Space)){
			Time.timeScale = 1.0f;
		}
		if(Input.GetKeyDown(KeyCode.M)){
			Destroy(gameObject); 
			Application.LoadLevel(12);
			SaveExport();
		}
	}

	void OnApplicationQuit(){
		SaveExport();
	}
	
	public static void SaveExport(){
		System.IO.Directory.CreateDirectory(Application.dataPath+@"\ExportDataCSV");
		export.ExportToFile(Application.dataPath+@"\ExportDataCSV\Snake"+System.DateTime.Now.ToString("dd.MM.yyyy-HH.mm.ss")+".csv");
	}

	/**
	 * Controle la balle avec des deplacements gauche,
	 * droite et profondeur
	 * return listFloat
	 */
	ArrayList StyleJeuSimple(){
		Frame frame = controller.Frame();
		Hand hand = frame.Hands.Rightmost;
		handPosition = hand.PalmPosition;
		ArrayList listFloat = new ArrayList();
		float moveSimpleX = 0;
		float moveSimpleZ = 0;

		export.AddRow();
		export["Time in ms"] = Time.timeSinceLevelLoad;
		export["Pos hand in x"] = handPosition.x;
		export["Pos hand in z"] = handPosition.z;
		
		if(hand.IsValid){
			if(moveSimpleX == (handPosition.x)/10 * Time.deltaTime * 3){
				moveSimpleX = 0;
			}else{
				moveSimpleX = (handPosition.x)/10 * Time.deltaTime * 3;
			}
			
			if (moveSimpleZ == (-handPosition.z) / 10 * Time.deltaTime * 3){
				moveSimpleZ = 0;
			}else{
				moveSimpleZ = (-handPosition.z) / 10 * Time.deltaTime * 3;
			}
		}
		listFloat.Add(moveSimpleX);
		listFloat.Add(moveSimpleZ);
		
		return listFloat;
	}

	/**
	 * Controle la balle avec un movement de 2 mains, 
	 * le mouvement de la balle est calculé en fonction de la difference
	 * de hauteur des 2 mains et de la distance par rapport à l'axe z
	 * return moveDeuxMain
	 */
	ArrayList StyleJeuDeuxMains(){
		Frame frame = controller.Frame();
		Hand handR = frame.Hands.Rightmost;
		Hand handL = frame.Hands.Leftmost;
		Vector handPositionR = handR.PalmPosition;
		Vector handPositionL = handL.PalmPosition;
		ArrayList listFloat = new ArrayList();
		
		float moveDeuxMainDG = 0;
		float moveDeuxMainZ = 0;

		export.AddRow();
		export["Time in ms"] = Time.timeSinceLevelLoad;
		export["Pos handR in z"] = handPositionR.z;
		export["Pos handL in z"] = handPositionL.z;
		export["Pos handR in y"] = handPositionR.y;
		export["Pos handL in y"] = handPositionL.y;
		export["Delta L - R"] = handPositionL.y - handPositionR.y;

		if(handR.IsValid && handL.IsValid){
			moveDeuxMainDG = CalculDiff(handPositionR,handPositionL);
			moveDeuxMainZ = PosMainsZ(handPositionR,handPositionL);
		}else{
			Debug.Log("Veuillez mettre vos 2 mains");
		}
		listFloat.Add(moveDeuxMainDG);
		listFloat.Add(moveDeuxMainZ);
		
		return listFloat;
	}
	
	/**
	 * Renvoie la position de la main la plus 
	 * éloigné par rapport à l'axe Z
	 */ 
	float PosMainsZ(Vector posR, Vector posL){
		float pos = -(posR.z + posL.z)/15 * Time.deltaTime * 3;  
		return pos; 
	}
	
	/**
	 * Calcule la difference de hauteur des deux
	 * mains
	 * return diff
	 */ 
	float CalculDiff(Vector posR, Vector posL){
		
		float diff = (posL.y - posR.y)/15  * Time.deltaTime * 3; //Permet le reglage de la sensibilité du mouvement
		return diff;
	}

	void OnGUI(){
		if(GUI.Button (new Rect (UnityEngine.Screen.width - 130, 0, 130, 50), "Menu (M)")) {
			SaveExport();
			Application.LoadLevel("MenuSnake");
		}

	}
}
