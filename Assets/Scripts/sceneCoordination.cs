using UnityEngine;
using System.Collections;

public class sceneCoordination : MonoBehaviour {

	public GameObject panel;
	public GameObject[] dialogues;
	public GameObject player;
	public GameObject shader;
	public GameObject credits;
	public GameObject button;

	public float dialogueWaitTime;
	public float dialogueShowTime;
	public float waitTime;
	private float originalDialogueWaitTime;
	private int current;
	private bool animationPlaying = false;
	
	// Use this for initialization
	void Start () {
		button.SetActive( false );
		panel.SetActive( false );
		waitTime = dialogueWaitTime;
		dialogues[0].SetActive( false );
		dialogues[1].SetActive( false );
		current = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ( dialogueWaitTime <= 0 ){
			if ( waitTime <= 0 ){
				playNextDialogue();
			} else {
				waitTime -= Time.deltaTime;
			}
		} else {
			dialogueWaitTime -= Time.deltaTime;
		}
		if ( animationPlaying == true ){
			if ( waitTime <= 0 ){
				playerAnimationFinished();
			} else {
				waitTime -= Time.deltaTime;
			}
		}
		
	}
	
	void playerAnimationFinished(){
		fadeShaderIn();
		rollCredits();
	}
	
	void fadeShaderIn(){
		shader.GetComponent<Animator>().SetBool( "Run", true );
		StartCoroutine( waitToShowButton() );
	}
	
	void rollCredits(){
		credits.GetComponent<Animator>().SetBool( "Run", true );
	}
	
	IEnumerator waitToShowButton(){
		//about a minute + a few seconds
		yield return new WaitForSeconds(64);
		showButton();
	}
	
	void showButton(){
		button.SetActive( true );
	}
	
	void playNextDialogue(){
		panel.SetActive( true );
		if ( current != 0 ){
			dialogues[ current - 1].SetActive( false );
		}
		if ( current < dialogues.Length ){
			dialogues[ current ].SetActive( true );
			current++;
		} else {
			hideDialogue();
			playPlayerAnimation();
		}
		if ( current == 2 ){
			waitTime = dialogueShowTime / 2f;
		} else {
			waitTime = dialogueShowTime;
		}
	}
	
	void hideDialogue(){
		panel.SetActive( false );
	}
	
	void playPlayerAnimation(){
		player.GetComponent<AnimatedPlayer>().runAnimation();
		animationPlaying = true;
		waitTime = dialogueShowTime;
	}
}
