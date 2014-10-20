using UnityEngine;
using System.Collections;

public class mousePan : MonoBehaviour
{

	Transform mainCamera;
	Vector3 mouseLastPosition;

	float mouseSensivity = 225.0f;

	// Use this for initialization
	void Awake ()
	{
		mainCamera = Camera.main.GetComponent<Transform>() as Transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// First click
		if(Input.GetMouseButtonDown(1))
		{
			mouseLastPosition = Input.mousePosition;
		}

		// Holding down
		if(Input.GetMouseButton(1))
		{
			pan();
		}

		// Zoom
		if (Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			zoom();
		}
	}

	void pan()
	{
		Vector3 delta = Input.mousePosition - mouseLastPosition;
		delta = -delta; // Invert camera movement


		Vector3 cameraPos = Camera.main.ScreenToViewportPoint(delta);
		Vector3 move = new Vector3(cameraPos.x * mouseSensivity, 0, cameraPos.y * mouseSensivity);

		transform.Translate(move, Space.World);
		//transform.position = Vector3.Lerp(transform.position, move, 0.2f * Time.deltaTime);
		mouseLastPosition = Input.mousePosition;
	}

	void zoom()
	{

		float wheel = Input.GetAxis("Mouse ScrollWheel");
		Vector3 move = wheel * mouseSensivity * transform.forward;

		if (wheel > 0) // forward
		{
			//transform.position = Vector3.Lerp(transform.position, transform.position + transform.forward, 0.5f * Time.deltaTime);
			transform.Translate(-move *-1, Space.World);
		}
		if (wheel < 0) //backward
		{
			transform.Translate(-move *-1, Space.World);
		}
	}

}
