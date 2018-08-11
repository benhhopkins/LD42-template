using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InputController : MonoBehaviour {

	public float m_dragSpeed = 1;
	public float m_scrollSpeed = 0.1f;
	public float m_scrollArea = 0.95f;
	public float m_scrollOutsideArea = 0.2f;

	private Camera m_camera;

	void Start () {
		m_camera = GetComponent<Camera>();

		Cursor.lockState = CursorLockMode.Confined;
	}
	
	void Update () {

		// no input if mouse is out
		Vector3 mousePoint = m_camera.ScreenToViewportPoint(Input.mousePosition);
		if(mousePoint.x < 0 - m_scrollOutsideArea || mousePoint.x > 1 + m_scrollOutsideArea ||
			mousePoint.y < 0 - m_scrollOutsideArea || mousePoint.y > 1 + m_scrollOutsideArea)
			return;

		// get mouse state
		bool leftDown = Input.GetMouseButtonDown(0);  
        bool rightDown = Input.GetMouseButtonDown(1);

		bool leftHeld = Input.GetMouseButton(0);  
        bool rightHeld = Input.GetMouseButton(1);
		bool middleHeld = Input.GetMouseButton(2);

		float moveX = Input.GetAxis("Mouse X");  
        float moveY = Input.GetAxis("Mouse Y");

		// camera scrolling
		bool scrolling = false;
		Vector3 oldPosition = transform.position;
		if(middleHeld) {
			transform.position += new Vector3(m_dragSpeed * -moveX, m_dragSpeed * -moveY, 0);
		}
		else {
			if(Input.mousePosition.x > Screen.width * m_scrollArea)
				transform.position += new Vector3(m_scrollSpeed, 0, 0);
			else if(Input.mousePosition.x < Screen.width * (1 - m_scrollArea))
				transform.position -= new Vector3(m_scrollSpeed, 0, 0);

			if(Input.mousePosition.y > Screen.height * m_scrollArea)
				transform.position += new Vector3(0, m_scrollSpeed, 0);
			else if(Input.mousePosition.y < Screen.height * (1 - m_scrollArea))
				transform.position -= new Vector3(0, m_scrollSpeed, 0);

			float scrollX = Input.GetAxis("Horizontal");
			float scrollY = Input.GetAxis("Vertical");
			transform.position += new Vector3(m_scrollSpeed * scrollX, 0, 0);
			transform.position += new Vector3(0, m_scrollSpeed * scrollY, 0);
		}

		if(oldPosition != transform.position)
			scrolling = true;

		// send mouse events
		Vector3 mouseWorldPosition = m_camera.ScreenToWorldPoint(Input.mousePosition);
		mouseWorldPosition.z = 0;

		if(moveX != 0 || moveY != 0 || scrolling) {
			GameManager.I.MouseMove(mouseWorldPosition);
		}

		if(leftDown) {
			GameManager.I.LeftClick(mouseWorldPosition);
		}

		if(rightDown) {
			GameManager.I.RightClick(mouseWorldPosition);
		}
	}
}
