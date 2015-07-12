using UnityEngine;
using System.Collections;

public class BedRoomDialogue : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GameObject.Find( "Player" ).GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}
