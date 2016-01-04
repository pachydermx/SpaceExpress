using UnityEngine;
using System.Collections;

public class SpaceCraft : MonoBehaviour {
	public UnityEngine.UI.Text debug;

	float power = 300;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();

		// remove draft
		float velocity = rb.velocity.magnitude;
		Vector3 front = this.transform.forward.normalized;
		rb.velocity = new Vector3(front.x * velocity, rb.velocity.y, front.z * velocity);
		debug.text = velocity + ".";

	}

	void Steer (bool is_right) {
		Rigidbody craft_body = this.gameObject.GetComponent<Rigidbody>();

		if (is_right){
			craft_body.AddTorque(this.transform.up * 600);
		} else {
			craft_body.AddTorque(this.transform.up * -600);
		}
	}

	void Accelerate (bool is_break) {
		Rigidbody craft_body = this.gameObject.GetComponent<Rigidbody>();
		if (is_break){
			craft_body.velocity = craft_body.velocity * 0.9f;
		} else {
			craft_body.AddForce(this.transform.forward * power);
		}
	}
}
