using UnityEngine;
using System.Collections;

public class posterController : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		gameObject.SetActive( true );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void setBob( bool b ){
		anim.SetBool( "Bob", b );
	}
}
