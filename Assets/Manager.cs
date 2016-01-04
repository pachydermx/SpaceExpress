﻿using UnityEngine;
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
			space_craft.SendMessage("Accelerate", false);
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			space_craft.SendMessage("Accelerate", true);
		}

		// Steering
		if (Input.GetKey(KeyCode.LeftArrow)){
			space_craft.SendMessage("Steer", false);
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			space_craft.SendMessage("Steer", true);
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


}
