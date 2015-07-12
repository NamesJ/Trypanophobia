using UnityEngine;
using System.Collections;

public class movingGasCloud : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void run(){
		anim.SetBool( "Run", true );
	}
}
