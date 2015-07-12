using UnityEngine;
using System.Collections;

public class gasMask : MonoBehaviour {

	public bool movingLeft;
	public bool movingRight;
	public bool gasMaskOn;
	public bool crouched;
	
	private Animator anim;
	private SpriteRenderer spRend;

	// Use this for initialization
	void Start () {
		movingLeft = false;
		movingRight = false;
		gasMaskOn = false;
		crouched = false;
		
		anim = gameObject.GetComponent<Animator>();
		spRend = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		setAnimator();
		setSprite();
		orientGasMask();
		//setSpritePosition();
	}
	
	public void setOrientation( bool l, bool r){
		movingLeft = l;
		movingRight = r;
	}
	
	public void setCrouch( bool c ){
		crouched = c;
	}
	
	void orientGasMask(){
		anim.SetBool( "Left", movingLeft );
		anim.SetBool( "Right", movingRight );
	}
	
	void setSprite(){
		if ( gasMaskOn ){
			spRend.enabled = true;
		} else {
			spRend.enabled = false;
		}
	}
	
	void setAnimator(){
		//Gasmask orientation
		anim.SetBool( "GasMaskOn", gasMaskOn );
		anim.SetBool( "Left", movingLeft );
		anim.SetBool( "Right", movingRight );
		anim.SetBool( "Crouched", crouched );
	}
	
	/*
	void setSpritePosition(){
		//THIS NEEDS TO BE WORKED ON!
		//if player is crouched lower
		if ( crouched ){
			transform.position = new Vector2
				(
					transform.position.x,
					crouchPosition
				);
		} else {
			transform.position = new Vector2
				(
					regular.x,
					regular.y
				);
		}
		//else raise it to normal position
	}
	*/
	
	public void setGaskMaskState(bool gasMaskState){
		gasMaskOn = gasMaskState;
	}
	
}
