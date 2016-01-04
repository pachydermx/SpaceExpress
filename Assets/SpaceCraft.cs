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
		debug.text = velocity + ".";

	}

	void Steer (bool is_right) {
		Rigidbody craft_body = this.gameObject.GetComponent<Rigidbody>();

		// remove draft
		float velocity = craft_body.velocity.magnitude;
		Vector3 front = this.transform.forward.normalized;
		craft_body.velocity = new Vector3(front.x * velocity, craft_body.velocity.y, front.z * velocity);

		if (is_right){
			craft_body.AddTorque(this.transform.up * 600);
		} else {
			craft_body.AddTorque(this.transform.up * -600);
		}
	}

	void Accelerate (bool is_break) {
		Rigidbody craft_body = this.gameObject.GetComponent<Rigidbody>();
		if (is_break){
			if (craft_body.velocity.magnitude > 15) {
				craft_body.velocity = craft_body.velocity * 0.9f;
			} else {
				craft_body.AddForce(this.transform.forward * -power);
			}
		} else {
			craft_body.AddForce(this.transform.forward * power);
		}
	}
}
