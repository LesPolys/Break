using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour {
	float timeCounter = 0;
	public float speed;
	public float radius;

	public delegate void EatenAction(int i);
	public static event EatenAction OnEaten;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime * speed;
		float x = Mathf.Cos (timeCounter) * radius;
		float y = Mathf.Sin (timeCounter) * radius;
		transform.position = new Vector3 (x, y, 0.0f);


		/*
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed = -1 * speed;
        }*/

	}


	public void OnTriggerEnter(Collider collider){
		if(collider.gameObject.tag == "GoodSide"){

			if (OnEaten != null) {
				OnEaten (1);
			}

			Destroy (collider.transform.parent.gameObject);
		}

		if(collider.gameObject.tag == "BadSide"){

			if (OnEaten != null) {
				OnEaten (-1);
			}

			Destroy (collider.transform.parent.gameObject);
		}

	}


	public void ChangeDirection(){
		speed = -1 * speed;
	}

	public void OnTouchDown(){
		ChangeDirection ();
	}

	public void OnTouchMoved(){
		ChangeDirection ();
	}
}
