using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	/* Should have an animation that automatically plays
	*  upon instantiation
	*/
	
	public float killTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		killTime -= Time.deltaTime;
		if ( killTime <= 0f ){
			Destroy( gameObject );
		}
	}

}
