using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour {
	// done by following this tutorial: [https://www.youtube.com/watch?v=2XNP6Qf2gDU]

	public Animator anim;
	public bool isFading = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	public void AnimationComplete(){
		isFading = false;
	}

	public IEnumerator FadeToClear (){
		isFading = true;
		anim.SetTrigger ("FadeIn");
		while (isFading) {
			yield return null; // don't move forward with the code until this is done
		}
	}

	public IEnumerator FadeToBlack (){
		isFading = true;
		anim.SetTrigger ("FadeOut");
		while (isFading) {
			yield return null; // don't move forward with the code until this is done
		}
	}
}
