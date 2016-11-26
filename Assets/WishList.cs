using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WishList : MonoBehaviour {
	public string item;
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
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ApplicationData.getWishList ().Contains (item)) {
				transform.GetChild (0).GetComponent<Text> ().text = "Added to WishList";
			} else {
				transform.GetChild (0).GetComponent<Text> ().text = "WishList";
		}
		if (count>0){
			count -= Time.deltaTime;
			inSight = true;
		} else inSight = false;

		if(!inSight){
			DecreaseChildSize();
		}


	}

	public void addToWishList() {
		IList list = ApplicationData.getWishList();
		if (!list.Contains(item))
		{
			list.Add(item);
		}
	}

	//**** Increase the circle size when you look at it ****\\
	public void IncreaseChildSize(){
		if(!isChanging){
			if (transform.GetChild (0).localScale.x <= 1.2f) {
//				transform.GetChild (0).localScale += new Vector3 (.2f * Time.deltaTime, .2f * Time.deltaTime, .5f * Time.deltaTime);
				transform.GetChild (0).localScale += new Vector3 (.2f * Time.deltaTime, .2f * Time.deltaTime, .5f * Time.deltaTime);
				reticleAnimator.SetBool ("LookSomething", true);
			} else {
				IList list = ApplicationData.getWishList();
				if (!list.Contains(item))
				{
					list.Add(item);
				}

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

}
