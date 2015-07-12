using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class actionDialogue : MonoBehaviour {

	/*
		This has an action
		This has a loadDialogue
	*/
	
	public GameObject nextActionDialogue;
	public bool firstActionDialogue;
	private action Action;
	public GameObject endObject;
	public string[] scene;
	private GameObject dialoguePanel;
	private loadDialogue dialogueScript;
	private bool sceneSetUp;

	// Use this for initialization
	void Awake () {
		gameObject.SetActive( firstActionDialogue );
		dialoguePanel = GameObject.Find( "Panel" );
		dialogueScript = dialoguePanel.GetComponent<loadDialogue>();
		GameObject actionObject = transform.Find( "Action" ).gameObject;
		Action = actionObject.GetComponent<action>();
		sceneSetUp = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ( sceneSetUp ){
			if ( dialogueScript.done() ){
				endingAction();
			}
		}
	}
	
	public void setupScene(){
		if ( Action.actionHasOccured() ){
			dialogueScript.loadScene( scene );
			dialogueScript.showDialogue();
			sceneSetUp = true;
			disableTrigger();
			setupNextActionDialogue();
		}
	}
	
	void disableTrigger(){
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
	}
	
	void endingAction(){
		if ( endObject != null ){
			endObject.GetComponent<endAction>().trigger();
		}
	}
	
	void setupNextActionDialogue(){
		nextActionDialogue.SetActive( true );
	}
	
}
