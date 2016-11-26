using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InsideScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void GoBack () {
		SceneManager.LoadScene("Main");		
	}
}
