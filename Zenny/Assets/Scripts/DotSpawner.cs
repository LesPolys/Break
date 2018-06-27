using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawner : MonoBehaviour {

	public GameObject dotPrefab;
	public float timeBetweenDots;

	public float[] possibleRadius;

	void Awake(){
		StartCoroutine (SpawnDot());
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnDot(){
		while (true) {

			yield return new WaitForSeconds(timeBetweenDots);
			GameObject temp = Instantiate (dotPrefab);
			int tempIndex = Random.Range (0, possibleRadius.Length);
			temp.transform.position = Random.insideUnitCircle.normalized * possibleRadius[tempIndex];
			temp.GetComponent<Edible> ().setMat (tempIndex);
		
		}
		yield return null;
	}


}
