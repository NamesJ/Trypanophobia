using UnityEngine;
using System.Collections;

public class action : MonoBehaviour {
	
	//I know that occurred is misspelled but I'm on a short deadline
	//I will fix it later

	private bool actionTrigger;
	public GameObject[] otherObjects;
	private int actionsRequired;

	// Use this for initialization
	void Start () {
		actionTrigger = false;
		actionsRequired = otherObjects.Length;
	}
	
	// Update is called once per frame
	void Update () {
		int actionsThatHaveOccured = 0;
		foreach( GameObject child in otherObjects ){
			if ( child.tag == "FallenSoldier" ){
				if ( child.GetComponent<fallenSoldier>().actionOccured() ){
					actionsThatHaveOccured++;
				}
			}
			if ( child.name == "PosterTrigger" ){
				if ( child.GetComponent<hyposDialogueTrigger>().actionOccured() ){
					actionsThatHaveOccured++;
				}
			}
		}
		if ( actionsThatHaveOccured == actionsRequired ){
			trigger();
		}
	}
	
	void trigger(){
		actionTrigger = true;
	}
	
	public bool actionHasOccured(){
		return actionTrigger;
	}
}
