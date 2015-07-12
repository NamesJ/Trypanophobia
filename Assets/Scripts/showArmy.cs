using UnityEngine;
using System.Collections;

public class showArmy : MonoBehaviour {

	private bool triggered;
	public GameObject enemy;
	private enemyArmy enemyArmyScript;
	private Vector3 playerPosition;
	private Vector3 oldCameraPosition;
	private Vector3 cameraPosition;
	public float timeToHold;
	private GameObject newCamera;
	private GameObject mainCamera;
	private player playerScript;

	// Use this for initialization
	void Start () {
		triggered = false;
		enemyArmyScript = enemy.GetComponent<enemyArmy>();
		GameObject _player = GameObject.Find( "Player" );
		playerScript = _player.GetComponent<player>();
		playerPosition = _player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if ( triggered ){
			if ( timeToHold <= 0 ){
				reset();
			} else {
				timeToHold -= Time.deltaTime;
			}
			enemyArmyScript.march();
		}
	}
	
	void setupCamera(){
		mainCamera = GameObject.Find( "Main Camera" );
		oldCameraPosition = new Vector3
		(
			gameObject.transform.position.x,
			gameObject.transform.position.y,
			-10f
		);
		cameraPosition = new Vector3
			(
				-4.66f,
				oldCameraPosition.y,
				oldCameraPosition.z
			);
		mainCamera.transform.position = cameraPosition;
	}
	
	public void trigger(){
		setupCamera();
		//Disable the users movement
		playerScript.setMovement( false );
		triggered = true;
	}
	
	void reset(){
		mainCamera.transform.position = oldCameraPosition;
		//Enable the user movement
		playerScript.setMovement( true );
		//Destroy this object so it won't be called again
		gameObject.SetActive( false );
	}
}
