using UnityEngine;
using System.Collections;

public class gasSoldier : MonoBehaviour {

	Animator anim;
	private bool alive;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		setAnimation();
	}
	
	void setAnimation(){
		anim.SetBool( "Alive", alive );
		anim.SetBool( "LookLeft", true );
	}
	
	void OnTriggerEnter2D( Collider2D collider ){
		GameObject otherObject = collider.gameObject;
		if ( otherObject.tag == "Gas" ){
			alive = false;
			GetComponent<CircleCollider2D>().enabled = false;
		}
	}
}
