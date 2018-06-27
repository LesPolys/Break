using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour {


	LineRenderer lr;

	public RectTransform stage1;
	public RectTransform stage2;
	public float speed;


	void Awake()
	{
		lr = GetComponent<LineRenderer>();
	}

	void Start()
	{
		lr.SetVertexCount(2);
		lr.SetWidth(0.3f, 0.3f);
		StartCoroutine(AnimateLineBetween(stage1, stage2));
	}


	IEnumerator AnimateLineBetween(RectTransform a, RectTransform b)
	{
		// set first point
		lr.SetPosition(0, a.anchoredPosition3D);
		// initialize second point
		lr.SetPosition(1, a.anchoredPosition3D);

		// the distance (and direction) between the two points
		Vector3 distance = b.anchoredPosition3D - a.anchoredPosition3D;
		for (float i = 0; i < 1; i += speed / 200)
		{
			// each frame, advance a fraction of the way
			lr.SetPosition(1, distance * i);
			yield return null;
		}
	}
}
