using UnityEngine;
using System;
using System.Collections;

public class FadeOutScript : Transition {

	public float fadeSpeed;
	public GameObject fadeObject;

	private bool done;

	void Start () {
		done = false;
	}

	void Update () {
		if (!done) {
			Renderer renderer = fadeObject.GetComponent<Renderer>();
			Color newColor = renderer.material.color;

			newColor.a += fadeSpeed;

			if (newColor.a >= 1) {
				newColor.a = 1;
				renderer.material.color = newColor;
				if (callback != null) {
					callback();
				}
				done = true;
			} else {
				renderer.material.color = newColor;
			}
		}
	}

	public override void Discard () {
		Destroy(gameObject);
	}
}
