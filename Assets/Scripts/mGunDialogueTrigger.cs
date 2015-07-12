using UnityEngine;
using System.Collections;

public class mGunDialogueTrigger : MonoBehaviour {

	public GameObject mGunDialogue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void trigger(){
		mGunDialogue.SetActive( true );
	}
}
