using UnityEngine;
using System.Collections;

public class gasMaskPickup : MonoBehaviour {

	public GameObject dialogue;

	// Use this for initialization
	void Start () {
		dialogue.SetActive( false );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void showDialogue(){
		dialogue.SetActive( true );
	}
}
