using UnityEngine;
using System.Collections;

public class fallenSoldier : MonoBehaviour {

	private GameObject dialogueTrigger;
	public Sprite[] bodyTypes;
	Animator anim;
	
	private bool glow;

	// Use this for initialization
	void Start () {
		dialogueTrigger = transform.Find( "DialogueTrigger" ).gameObject;
		GetComponent<SpriteRenderer>().sprite = bodyTypes[ Random.Range( 0, bodyTypes.Length ) ];
		dialogueTrigger.SetActive( false );
		anim = GetComponent<Animator>();
		glow = true;
	}
	
	// Update is called once per frame
	void Update () {
		setAnimation();
	}
	
	void setAnimation(){
		anim.SetBool( "Glow", glow );
	}
	
	public void trigger(){
		dialogueTrigger.SetActive( true );
		glow = false;
	}
	
	public bool actionOccured(){
		return !glow;
	}
}
