using UnityEngine;
using System.Collections;

public class randomSoundEffect : MonoBehaviour {

	public AudioClip[] soundEffects;
	public float minTime;
	public float maxTime;
	public AudioSource audio;
	
	private int clip;
	private float waitTime;

	// Use this for initialization
	void Start () {
		clip = 0;
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if ( audio.isPlaying == false){
			countDown();
		}
	}
	
	void countDown(){
		if ( waitTime <= 0f ){
			playSoundEffect();
		} else {
			waitTime -= Time.deltaTime;
		}
	}
	
	void playSoundEffect(){
		clip = Random.Range( 0, soundEffects.Length );
		audio.clip = soundEffects[ clip ];
		audio.Play();
		startNextWait();
	}
	
	void startNextWait(){
		waitTime = Random.Range( minTime, maxTime );
	}
}
