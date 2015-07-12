using UnityEngine;
using System.Collections;

public class IntroNextLevel : MonoBehaviour {

	public GameObject loadingScrene;
	public GameObject shader;

	// Use this for initialization
	void Start () {
		loadingScrene.SetActive( false );
		shader.SetActive( false );
	}
	
	// Update is called once per frame
	void Update () {
	
		if ( Input.GetButtonDown( "CallDialogue" ) ){
			Application.LoadLevel( 1 );
			showLoadingScreen();
		}
	
	}
	
	void showLoadingScreen(){
		shader.SetActive( true );
		loadingScrene.SetActive( true );
	}
}
