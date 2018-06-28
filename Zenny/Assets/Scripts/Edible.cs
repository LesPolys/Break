using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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





}
