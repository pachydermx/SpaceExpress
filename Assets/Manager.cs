using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
	public GameObject space_craft;

	public Camera first_person_camera;
	public Camera first_person_camera_reverse;

	public Camera third_person_camera;
	public Camera third_person_camera_reverse;

	private Camera current_camera;

	// Use this for initialization
	void Start () {
		current_camera = third_person_camera;
	}
	
	// Update is called once per frame
	void Update () {
		// Camera
		if (Input.GetKeyDown(KeyCode.C)){
			SwitchCamera();
		}

		// Accelerate
		if (Input.GetKey(KeyCode.UpArrow)){
			Accelerate(false);
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			Accelerate(true);
		}

		// Steering
		if (Input.GetKey(KeyCode.LeftArrow)){
			Steer(false);
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			Steer(true);
		}
	}

	void SwitchCamera () {
		if (current_camera == this.first_person_camera){
			first_person_camera.gameObject.SetActive(false);
			third_person_camera.gameObject.SetActive(true);
			current_camera = third_person_camera;
		} else {
			third_person_camera.gameObject.SetActive(false);
			first_person_camera.gameObject.SetActive(true);
			current_camera = first_person_camera;
		}
	}

	void Accelerate (bool is_break) {
		Rigidbody craft_body = space_craft.GetComponent<Rigidbody>();
		if (is_break){
			craft_body.AddForce(new Vector3(0, 0, -100));
		} else {
			craft_body.AddForce(new Vector3(0, 0, 100));
		}
	}

	void Steer (bool is_right) {
		Rigidbody craft_body = space_craft.GetComponent<Rigidbody>();
		if (is_right){
			craft_body.AddTorque(new Vector3(0, 100, 0));
		} else {
			craft_body.AddTorque(new Vector3(0, -100, 0));
		}
	}
}
