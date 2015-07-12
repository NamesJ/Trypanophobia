using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	//public
	public GameObject dialoguePanel;
	private loadDialogue dialogueBox;
	
	public float walkSpeed;
	public float jumpForce;
	public float maxSpeed;

	//private
	
	private GameObject GasMask;
	private gasMask GasMaskScript;
	private Animator anim;
	
	private bool alive;
	private bool playerCanMove;
	private bool playerIsGrounded;
	private bool gasMaskOn;
	private bool playerIsCrouched;
	private bool playerCanDialogue;
	public bool hasGasMask;
	private bool hasCanteen;
	
	private bool movingLeft;
	private bool movingRight;
	private bool jumping;
	
	//spawnPosition
	private Vector2 spawnPosition;
	
	private Vector2 jump;
	
	//Component References
	private Rigidbody2D rb;
	
	// Use this for initialization
	void Start () {
		dialogueBox = dialoguePanel.GetComponent<loadDialogue>();
		spawnPosition = gameObject.transform.position;
		GasMask = transform.Find( "GasMask" ).gameObject;
		GasMaskScript = GasMask.GetComponent<gasMask>();
		anim = gameObject.GetComponent<Animator>();
		
		alive = true;
		playerCanMove = true;
		playerIsGrounded = true;
		gasMaskOn = false;
		playerIsCrouched = false;
		movingLeft = false;
		movingRight = false;
		hasGasMask = false;
		hasCanteen = false;
		
		jump = new Vector2( 0f, jumpForce );
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		checkAlive();
		checkInput();
		setAnimation();
		//checkMaxSpeed();
		//Debug.Log( playerIsGrounded );
	}
	
	void OnCollisionEnter2D( Collision2D collision ){
		GameObject otherObject = collision.gameObject;
		if ( otherObject.tag == "Ground" ){
			playerIsGrounded = true;
		}
		if ( otherObject.tag == "RazorWire" ){
			alive = false;
		}
	}
	
	void OnCollisionExit2D( Collision2D collision ){
		GameObject otherObject = collision.gameObject;
		if ( otherObject.tag == "Ground" ){
			playerIsGrounded = false;
		}
	}
	
	void OnCollisionStay2D( Collision2D collision ){
		GameObject otherObject = collision.gameObject;
		if ( otherObject.tag == "Ground" ){
			playerIsGrounded = true;
		}
	}
	
	void OnTriggerStay2D( Collider2D collider ){
		GameObject otherObject = collider.gameObject;
		if ( otherObject.tag == "FallenSoldier" ){
			if ( hasCanteen ){
				if ( Input.GetButtonDown( "CallDialogue" ) ){
					otherObject.GetComponent<fallenSoldier>().trigger();
				}
			}
		}
		if ( otherObject.tag == "DialoguePoint" ){
			otherObject.GetComponent<dialogue>().setupScene();
		}
		if ( otherObject.name == "PosterTrigger" ){
			otherObject.GetComponent<hyposDialogueTrigger>().trigger();
		}
		if ( otherObject.name == "MachineGunnerActionDialogue1Trigger" ){
			otherObject.GetComponent<mGunDialogueTrigger>().trigger();
		}
	}
	
	void OnTriggerEnter2D( Collider2D collider ){
		GameObject otherObject = collider.gameObject;
		if ( otherObject.tag == "Gas" ){
			if ( gasMaskOn == false ){
				alive = false;
			}
		}
		if ( otherObject.tag == "CheckPoint" ){
			spawnPosition = otherObject.GetComponent<checkPoint>().getSpawnPosition();
		}
		if ( otherObject.tag == "DialoguePoint" ){
			otherObject.GetComponent<dialogue>().setupScene();
		}
		if ( otherObject.tag == "ActionDialogue" ){
			otherObject.GetComponent<actionDialogue>().setupScene();
		}
		if ( otherObject.tag == "GasMask" ){
			hasGasMask = true;
			otherObject.SetActive( false );
			otherObject.GetComponent<gasMaskPickup>().showDialogue();
		}
		if (otherObject.tag == "Canteen" ){
			hasCanteen = true;
			otherObject.SetActive( false );
			otherObject.GetComponent<gasMaskPickup>().showDialogue();
		}
		if ( otherObject.tag == "EventTrigger" ){
			if ( otherObject.GetComponent<showArmy>() != null ){
				otherObject.GetComponent<showArmy>().trigger();
			}
			if ( otherObject.GetComponent<movingGasCloudTrigger>() != null){
				otherObject.GetComponent<movingGasCloudTrigger>().trigger();
			}
		}
	}
	
	void setAnimation(){
		//Player walk animation
		anim.SetBool( "Left", movingLeft );
		anim.SetBool( "Right", movingRight );
		anim.SetBool( "Jumping", jumping );
		anim.SetBool( "Crouch", playerIsCrouched );
		anim.SetBool( "Alive", alive );
		
		//GasMask orientation
		GasMaskScript.setGaskMaskState( gasMaskOn );
		GasMaskScript.setOrientation( movingLeft, movingRight );
		GasMaskScript.setCrouch( playerIsCrouched );
	}
	
	void checkAlive(){
		if ( !alive ){
			die();
			StartCoroutine( respawnCoroutine() );
		}
	}
	
	void checkInput() {
		if ( playerCanMove ){
			if ( Input.GetButton( "Left" ) ){
				//move( left );
				movingLeft = true;
			} else {
				movingLeft = false;
			}
			if ( Input.GetButton( "Right" ) ){
				//move( right );
				movingRight = true;
			} else {
				movingRight = false;
			}
			
			if ( playerIsGrounded ){
				if ( Input.GetButtonDown( "Jump" ) ){
					jumping = true;
					jumpUp();
				} else {
					jumping = false;
				}
			}
			
		} else {
			movingLeft = false;
			movingRight = false;
		}
		if ( Input.GetButtonDown( "Crouch" ) ){
			crouch();
		}
		if ( hasGasMask ){
			if ( Input.GetButtonDown( "GasMask" ) ){
				gasMaskInteract();
			}
		}
		if ( playerCanDialogue ){
			if ( Input.GetButtonDown( "CallDialogue" ) ){
				dialogueBox.GetComponent<loadDialogue>().nextLine();
			}
		}
	}
	
	void checkMaxSpeed(){
		if ( Mathf.Abs( rb.velocity.x ) >= maxSpeed ){
			playerCanMove = false;
		} else {
			playerCanMove = true;
		}
	}
	
	void crouch(){
		playerCanMove = !playerCanMove;
		playerIsCrouched = !playerIsCrouched;
	}
	
	void jumpUp(){
		rb.AddForce( jump );
		/*
		Vector2 newPosition = transform.localPosition;
		newPosition.y = Mathf.Lerp
			(
				transform.localPosition.y, 
				transform.localPosition.y + 0.1f, 
				Time.deltaTime * 120f
			); 
		transform.position = newPosition;
		*/
	}
	
	void move( Vector2 direction ){
		rb.AddForce( direction );
	}
	
	void gasMaskInteract(){
		gasMaskOn = !gasMaskOn;
		GasMask.GetComponent<gasMask>().setGaskMaskState( gasMaskOn );
	}
	
	IEnumerator respawnCoroutine(){
		yield return new WaitForSeconds(3);
		respawn();
	}
	
	void respawn(){
		alive = true;
		//Switch to  idle animation
		transform.position = spawnPosition;
		playerCanMove = true;
	}
	
	void die(){
		playerCanMove = false;
	}
	
	
	//public methods
	
	public void setMovement( bool move ){
		playerCanMove = move;
		playerIsGrounded = true; //this was giving some weird behavior
	}
	
	public void setDialogueInteract( bool dInteract ){
		playerCanDialogue = dInteract;
	}
}
