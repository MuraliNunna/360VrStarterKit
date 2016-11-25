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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
