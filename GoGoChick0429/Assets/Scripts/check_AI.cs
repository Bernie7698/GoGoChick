using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_AI : MonoBehaviour {

	void Update(){
		if (transform.position.y < -2) {
			MainAI.Score -= 1;
			MainAI.lift -= 1;
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "chick_yellow(Clone)" ||
		   col.gameObject.name == "chick_red(Clone)") {
			FixedJoint Fixed_Joint = gameObject.AddComponent<FixedJoint>();
			Fixed_Joint.connectedBody = col.rigidbody;
		}
	}
}
