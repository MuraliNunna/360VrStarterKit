using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InsideScene : MonoBehaviour {

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

	void Start() {
		reticleAnimator = GameObject.Find ("Reticle").GetComponentInChildren<Animator> ();
//		blkScreen = GameObject.Find ("BlackScreen").GetComponent<BlackScreen>();
//		sphereScreen = GameObject.Find ("/sphere");
//		InsideScene = SceneManager.GetSceneByName("InsideScene");
	}
	//**** Increase the circle size when you look at it ****\\
	public void IncreaseChildSize(){
		if(!isChanging){
			if (transform.GetChild (0).localScale.x <= 1.2f) {
//				transform.GetChild (0).localScale += new Vector3 (.2f * Time.deltaTime, .2f * Time.deltaTime, .5f * Time.deltaTime);
				transform.GetChild (0).localScale += new Vector3 (.2f * Time.deltaTime, .2f * Time.deltaTime, .5f * Time.deltaTime);
				reticleAnimator.SetBool ("LookSomething", true);
			} else {
//				StartCoroutine (FadeChangeRoom ());
				SceneManager.LoadScene("Main");
				reticleAnimator.SetBool ("LookSomething", false);
			}
			count = 0.5f;
		}
	}
	//**** And decrease it when you're not looking at it ****\\
	void DecreaseChildSize(){
		reticleAnimator.SetBool ("LookSomething", false);
		if(transform.GetChild(0).localScale.x > 1.2f && transform.GetChild(1).localScale.x < 1.01f)
			transform.GetChild(0).localScale -= new Vector3(2*Time.deltaTime,2*Time.deltaTime,2*Time.deltaTime);
	}

	void Update(){
		if (count>0){
			count -= Time.deltaTime;
			inSight = true;
		} else inSight = false;

		if(!inSight){
			DecreaseChildSize();
		}
	}

}
