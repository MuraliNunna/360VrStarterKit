using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PersistState : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!SceneManager.GetActiveScene ().name.Equals ("Main")) {
			gameObject.SetActive (false);
		} else {
			gameObject.SetActive(true);
		}
	}

	void Awake ()
	{
		DontDestroyOnLoad(gameObject);
	}
}
