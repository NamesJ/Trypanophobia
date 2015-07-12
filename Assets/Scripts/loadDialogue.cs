using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class loadDialogue : MonoBehaviour {

	/* This should be applied to a panel containing a textbox
	*  
	*/

	private string endingLine; 
	private GameObject Player;
	private player playerScript;
	public int currentLine;
	public int currentScene;
	private string[] scene;
	private List<string[]> scenes;
	public Text dialogueBox;
	private bool isDone;
	

	// Use this for initialization
	void Start () {
		endingLine = "...";
		Player = GameObject.Find( "Player" );
		playerScript = Player.GetComponent<player>();
		
		//start off by not showing the dialogueBox
		gameObject.SetActive( false );
		isDone = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void setDialogue(){
		dialogueBox.text = scene[ currentLine ] + "\n\n -- \"E\" to continue... --";
	}
	
	//*Note: Dialogue trigger must call loadScene, then showDialogue
	// must also disable its own trigger after calling loadScene
	
	public void showDialogue(){
		isDone = false;
		//this should be called by dialogue trigger
		gameObject.SetActive( true );
		playerScript.setMovement( false );
		playerScript.setDialogueInteract( true );
		//Load the first piece of dialogue
		setDialogue();
	}
	
	public void hideDialogue(){
		//this should be called by dialogue trigger
		gameObject.SetActive( false );
		playerScript.setMovement( true );
		playerScript.setDialogueInteract( false );
	}
	
	public void loadScene( string[] newScene ){
		// dialogue trigger object will give this a dialogue array
		scene = newScene;
		currentLine = 0;
	}
	
	public void nextLine(){
		//this controller by player
		currentLine++;
		//special condition for endingLine
		if ( scene[ currentLine ] == endingLine ){
			loadNextLevel();
		}
		//////////////////////////////
		//special condition for posters
		if ( scene[ currentLine ] == "Me:" ){
			isDone = true;
		}
		//////////////////////////////
		if ( scene[ currentLine ] == "!END!" ){
			isDone = true;
			hideDialogue();
		} else {
			setDialogue();
		}
	}
	
	public bool done(){
		return isDone;
	}
	
	void loadNextLevel(){
		//Don't antagonize me. I know this shouldn't be here.
		int i = Application.loadedLevel;
		Application.LoadLevel( i + 1 );
	}
	
}
