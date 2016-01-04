using UnityEngine;
using System.Collections;

public class SpaceCraft : MonoBehaviour {
	public UnityEngine.UI.Text debug;

	float power = 100;

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

		rb.AddForce(this.transform.forward * power);
	}

	void Steer (bool is_right) {
		Rigidbody craft_body = this.gameObject.GetComponent<Rigidbody>();


		if (is_right){
			craft_body.AddTorque(new Vector3(0, 600, 0));
		} else {
			craft_body.AddTorque(new Vector3(0, -600, 0));
		}
	}

	void Accelerate (bool is_break) {
		Rigidbody craft_body = this.gameObject.GetComponent<Rigidbody>();
		if (is_break){
			craft_body.velocity = craft_body.velocity * 0.9f;
			power *= 0.1f;
		} else {
			power += 1;
		}
	}
}
