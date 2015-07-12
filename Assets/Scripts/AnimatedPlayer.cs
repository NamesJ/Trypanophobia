using UnityEngine;
using System.Collections;

public class AnimatedPlayer : MonoBehaviour {
	
	public GameObject door;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D( Collider2D collider ){
		GameObject otherObject = collider.gameObject;
		if ( otherObject.name == "DoorTrigger" ){
			door.GetComponent<Animator>().SetBool( "Run", true );
		}
	}
	
	public void runAnimation(){
		GetComponent<Animator>().SetBool( "Run", true );
	}
}
