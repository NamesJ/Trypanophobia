using UnityEngine;
using System.Collections;

public class checkPoint : MonoBehaviour {

	private GameObject SpawnPoint;

	private Vector2 spawnPosition;

	// Use this for initialization
	void Start () {
		SpawnPoint = transform.Find( "SpawnPoint" ).gameObject;
		spawnPosition = SpawnPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Vector2 getSpawnPosition(){
		return spawnPosition;
	}
}
