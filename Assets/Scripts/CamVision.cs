using UnityEngine;
using System.Collections;

public class CamVision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Debug.DrawRay (transform.position, transform.forward * 50, Color.blue, 100);
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward * 50, out hit)) {
			print(hit.transform.tag);
			if (hit.transform.tag == "ScaleTarget") {
				hit.transform.GetComponent<ChangeRoom>().IncreaseChildSize();		
			}
			if (hit.transform.tag == "BackPoint") {
				hit.transform.GetComponent<InsideScene>().GoBack();		
			}
			if (hit.transform.tag == "CityPoint") {
				hit.transform.GetComponent<ShowHoverMenu>().IncreaseChildSize();		
			}
			if(hit.transform.tag == "AnimTarget")
				hit.transform.GetComponent<PlayAnimOnSight>().OnSightEnter();
		}
	}
}
