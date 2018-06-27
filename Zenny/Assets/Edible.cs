using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edible : MonoBehaviour {

	public Material[] mats;
	Renderer theRenderer;
	void Awake(){
		theRenderer = GetComponent<Renderer> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setMat(int i){
		theRenderer.material = mats [i];
	}

	public void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag == "Tadpole"){
			Destroy (gameObject);
		}
	}
}
