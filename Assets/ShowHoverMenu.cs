using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ShowHoverMenu : MonoBehaviour {

	public List<Texture2D> textureSphere;
	public float fadeDuration = 1;

	bool inSight = false;
	bool isChanging = false;
	float count = 0;
	float countLerp = 0;
	Animator reticleAnimator; 
	BlackScreen blkScreen;
	GameObject sphereScreen;

	private Color color = new Color(0,0,0,0);
	private int i = 1;

	// Use this for initialization
	void Start () {
		reticleAnimator = GameObject.Find ("Reticle").GetComponentInChildren<Animator> ();
		blkScreen = GameObject.Find ("BlackScreen").GetComponent<BlackScreen>();
		sphereScreen = GameObject.Find ("sphere");	
		transform.GetChild(1).gameObject.SetActive(false); // explicitly set the menu as inactive so as to hide.

	}
	//**** And decrease it when you're not looking at it ****\\
	void DecreaseChildSize(){
		reticleAnimator.SetBool ("LookSomething", false);
		if(transform.GetChild(0).localScale.x > 0)
			transform.GetChild(0).localScale -= new Vector3(2*Time.deltaTime,2*Time.deltaTime,2*Time.deltaTime);
	}
		
	// Update is called once per frame
	void Update(){
		if (count>0){
			count -= Time.deltaTime;
			inSight = true;
		} else inSight = false;

		if(!inSight){
			DecreaseChildSize();
		}
	}

	//**** Increase the circle size when you look at it ****\\
	public void IncreaseChildSize(){
		if(!isChanging){
			if (transform.GetChild (0).localScale.x <= 0.9f) {
				transform.GetChild (0).localScale += new Vector3 (.5f * Time.deltaTime, .5f * Time.deltaTime, .5f * Time.deltaTime);
				reticleAnimator.SetBool ("LookSomething", true);
			} else {
//				StartCoroutine (FadeChangeRoom ());
				transform.GetChild(1).gameObject.SetActive(true); // set the menu as active 
				transform.GetChild(0).gameObject.SetActive(false); // no more hover animation now.
//				transform.GetChild(1).hideFlags.None;
				reticleAnimator.SetBool ("LookSomething", false);
			}
			count = 0.5f;
		}
	}
}
