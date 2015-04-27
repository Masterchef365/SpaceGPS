using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	void Update () {
		if (Input.GetMouseButton (0)) {
			Vector3 newRot = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) + transform.rotation.eulerAngles;
			transform.rotation = Quaternion.Euler (newRot);
		}
		float speed;
		if (Input.GetKey("left shift")){
			speed = 2f;
		} else {
			speed = 1f;
		}
		
		if (Input.GetKey ("w")) {
			transform.Translate(Vector3.forward*speed, Space.Self);
		}
		else
		{
			if (Input.GetKey ("s")) {
				transform.Translate(Vector3.back*speed, Space.Self);
			}
		}
		
		if (Input.GetKey ("a")) {
			transform.Translate(Vector3.left*speed,Space.Self);
		}
		else
		{
			if (Input.GetKey ("d")) {
				transform.Translate(Vector3.right*speed,Space.Self);
			}
		}
		
		if (Input.GetKey ("space")) {
			transform.Translate(Vector3.up*speed,Space.Self);
		}
		else
		{
			if (Input.GetKey ("left ctrl")) {
				transform.Translate(Vector3.down*speed,Space.Self);
			}
		}
	}
}