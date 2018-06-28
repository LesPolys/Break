using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSpawner : MonoBehaviour {

	public GameObject dotPrefab;
	public float timeBetweenDots;

	public float[] possibleRadius;
	public GameObject[] tadpoles;

	[Range(0,4)]
	public float minAcceptableDistance;

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

			Vector3 tempPos = Random.insideUnitCircle.normalized * possibleRadius[tempIndex];
			while(Vector3.Distance(tempPos, tadpoles[tempIndex].transform.position) < minAcceptableDistance){
				tempPos = Random.insideUnitCircle.normalized * possibleRadius[tempIndex];
			}


			temp.transform.position = tempPos;

			Vector3 relativePos = new Vector3(0.0f,0.0f,0.0f) - temp.transform.position;
			Quaternion rotation = Quaternion.LookRotation(relativePos, temp.transform.forward);
			temp.transform.rotation = rotation;

			if (Random.Range (0, 2) > 0) {
				temp.transform.Rotate (new Vector3 (0, 0, 180));
			}

			temp.GetComponent<Edible> ().setMat (tempIndex);
		
		}
		yield return null;
	}


}
