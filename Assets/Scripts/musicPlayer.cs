using UnityEngine;
using System.Collections;

public class musicPlayer : MonoBehaviour {

	public AudioClip[] musicClips;
	AudioSource audio;
	private int clip;

	// Use this for initialization
	void Awake(){
		audio = GetComponent<AudioSource>();
	}
	
	void Start () {
		clip = Random.Range( 0, musicClips.Length );
	}
	
	// Update is called once per frame
	void Update () {
		if ( audio.isPlaying == false ){
			playNextClip();
		}
	}
	
	void playNextClip(){
		clip++;
		if ( clip >= musicClips.Length ){
			clip = 0;
		}
		audio.clip = musicClips[ clip ];
		audio.Play();
	}
	
	public void playSpecificClip( AudioClip specialClip ){
		audio.clip = specialClip;
		audio.Play();
		clip = 0; //Just in case some stuff goes awry due to unexpectedness (i know, iknow)
	}
	
	public void skipClip(){
		playNextClip();
	}
}
