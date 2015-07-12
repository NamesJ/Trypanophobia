using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class dialogue : MonoBehaviour {

	public string[] scene;
	private GameObject dialoguePanel;
	private loadDialogue dialogueScript;

	// Use this for initialization
	void Awake () {
		dialoguePanel = GameObject.Find( "Panel" );
		dialogueScript = dialoguePanel.GetComponent<loadDialogue>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void setupScene(){
		dialogueScript.loadScene( scene );
		dialogueScript.showDialogue();
		disableTrigger();
	}
	
	void disableTrigger(){
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
	}
	
}
