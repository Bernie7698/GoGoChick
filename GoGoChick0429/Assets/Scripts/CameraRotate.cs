using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void LeftButton(){
		transform.Rotate (0, 2, 0, Space.World);
	}
	public void RightButton(){
		transform.Rotate (0, -2, 0, Space.World);
	}
}
