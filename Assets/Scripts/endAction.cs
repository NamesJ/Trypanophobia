using UnityEngine;
using System.Collections;

public class endAction : MonoBehaviour {

	public AudioClip posterAudioClip;
	public GameObject[] otherAudioSources;
	public float minTime;
	public float maxTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void assemblePosters(){
		foreach( Transform child in gameObject.transform ){
			StartCoroutine( showPosterCoroutine( child.gameObject ) );
		}
	}
	
	IEnumerator showPosterCoroutine( GameObject child ){
		yield return new WaitForSeconds(
			Random.Range( minTime, maxTime )
		);
		showPoster( child );
	}
	
	void showPoster( GameObject child ){
		child.SetActive( true );
	}
	
	void triggerSpecialSong(){
		foreach( GameObject source in otherAudioSources ){
			source.GetComponent<AudioSource>().volume = Mathf.Lerp(
				1.0f,
				0.1f,
				5f
			);
		}
		GameObject.Find( "Music" ).GetComponent<musicPlayer>().playSpecificClip( posterAudioClip );
	}
	
	public void trigger(){
		triggerSpecialSong();
		assemblePosters();
	}
}
