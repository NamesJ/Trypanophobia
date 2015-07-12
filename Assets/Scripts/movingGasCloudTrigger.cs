using UnityEngine;
using System.Collections;

public class movingGasCloudTrigger : MonoBehaviour {

	public GameObject gasCloud;
	private movingGasCloud gasCloudScript;
	
	// Use this for initialization
	void Start () {
		gasCloudScript = gasCloud.GetComponent<movingGasCloud>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void trigger(){
		gasCloudScript.run();
	}
}
