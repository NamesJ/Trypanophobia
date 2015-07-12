using UnityEngine;
using System.Collections;

public class hypo : MonoBehaviour {

	Animator anim;
	private float waitTime = 6f;

	// Use this for initialization
	void Awake(){
		anim = GetComponent<Animator>();
	}
	
	void Start () {
		anim.SetBool( "Run", false );
	}
	
	// Update is called once per frame
	void Update () {
		if ( waitTime <= 0 ){
			reset();
		} else {
			waitTime -= Time.deltaTime;
		}
	}
	
	void reset(){
		anim.SetBool( "Run", false );
	}
	
	public void march(){
		if ( anim == null ){
			anim = GetComponent<Animator>();
		}
		anim.SetBool( "Run", true );
	}
}
