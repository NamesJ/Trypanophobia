using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	public GameObject bullet;
	public float maxTime;
	public bool right;
	
	Animator anim;
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
		resetCountDown();
	}
	
	// Update is called once per frame
	void Update () {
		setAnimation();
		if ( countDown <= 0 ){
			fire();
		} else {
			countDown -= Time.deltaTime;
		}
		if ( muzzleTime <= 0 ){
			muzzelFlash.enabled = false;
		} else {
			muzzleTime -= Time.deltaTime;
		}
		recoil = false;
	}
	
	void setAnimation(){
			anim.SetBool( "Recoil", recoil );
			anim.SetBool( "Right", right );
	}
	
	void resetCountDown(){
		countDown = Random.Range( 1f, maxTime );
		muzzleTime = Time.deltaTime * 4f;
	}
	
	void fire(){
		recoil = true;
		muzzelFlash.enabled = true;
		setAnimation();
		audio.Play();
		resetCountDown();
	}
	
	void fireBullet(){
		GameObject b = Instantiate( bullet, spawnPoint, Quaternion.identity ) as GameObject;
		b.transform.parent = gameObject.transform;
	}
}
