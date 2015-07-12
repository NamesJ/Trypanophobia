using UnityEngine;
using System.Collections;

public class smokeBob : MonoBehaviour {

	private float startingY;
	
	public bool direction;
	private float speed;
	public float maxBob;

	// Use this for initialization
	void Start () {
		startingY = transform.position.y;
		speed = Random.Range( 0.01f, 0.1f );
	}
	
	// Update is called once per frame
	void Update () {
		float currentY = transform.position.y;
		//go up
		if ( Mathf.Abs( currentY - startingY ) >= maxBob ){
			direction = !direction;
		}
		move();
	}
	
	void move(){
		float currentX = transform.position.x;
		if ( direction == true ){
			//move up
			transform.position = new Vector2( currentX, transform.position.y + ( speed / 100 ) );
		} else {
			//move down
			transform.position = new Vector2( currentX, transform.position.y - ( speed / 100 ) );
		}
	}
}
