using UnityEngine;
using System.Collections;

public class machineGun : MonoBehaviour {

	public float maxTime;
	public int maxBurst;
	public int minBurst;
	public bool right;
	public float shotsPerMinute;
	
	Animator anim;
	private float shotDelay;
	private int burst;
	private bool recoil;
	private float muzzleTime;
	private SpriteRenderer muzzelFlash;
	private float countDown;
	AudioSource audio;
	private GameObject bulletSpawnPoint;
	private Vector2 spawnPoint;
	
	// Use this for initialization
	void Awake() {
		audio = GetComponent<AudioSource>();
	}
	
	void Start () {
		anim = GetComponent<Animator>();
		bulletSpawnPoint = transform.Find( "Spawn" ).gameObject;
		spawnPoint = bulletSpawnPoint.transform.position;
		GameObject muzzle = transform.Find( "MuzzleFlash" ).gameObject;
		muzzelFlash = muzzle.GetComponent<SpriteRenderer>();
		recoil = false;
		shotDelay = ( shotsPerMinute / 60f ) * Time.deltaTime;
		anim.SetBool( "Right", right );
		resetCountDown();
		resetBurst();
	}
	
	// Update is called once per frame
	void Update () {
		setAnimation();
		recoil = false;
		muzzelFlash.enabled = false;
		if ( shotDelay <= 0 ){
			if ( burst <= 0 ){
				if ( countDown <= 0 ){
					resetBurst();
					resetCountDown();
				} else {
					countDown -= Time.deltaTime;
				}
				if ( muzzleTime <= 0 ){
					//muzzelFlash.enabled = false;
				} else {
					muzzleTime -= Time.deltaTime;
				}
				
			} else {
				fire();
			}
		} else {
			shotDelay -= Time.deltaTime;
		}
	}
	
	void resetBurst(){
		burst = Random.Range( minBurst, maxBurst );
	}
	
	void setAnimation(){
		anim.SetBool( "Recoil", recoil );
	}
	
	void resetCountDown(){
		countDown = Random.Range( 1f, maxTime );
		muzzleTime = Time.deltaTime * 4f;
	}
	
	void fire(){
		burst--;
		recoil = true;
		muzzelFlash.enabled = true;
		setAnimation();
		if ( burst % 2 == 0 ){
			audio.Play();
		}
		shotDelay = ( shotsPerMinute / 60f ) * Time.deltaTime;
	}
}
