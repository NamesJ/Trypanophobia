using UnityEngine;
using System.Collections;

public class hyposDialogueTrigger : MonoBehaviour {

	private bool actionHasOccured;

	// Use this for initialization
	void Start () {
		actionHasOccured = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void trigger(){
		actionHasOccured = true;
	}
	
	public bool actionOccured(){
		return actionHasOccured;
	}
}
