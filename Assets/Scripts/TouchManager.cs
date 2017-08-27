using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : SingletonMonoBehaviour<TouchManager>
{
	private bool isPhone;

	public delegate void OnDownCallback ();

	public OnDownCallback OnDown;

	public delegate void OnDragCallback ();

	public OnDragCallback OnDrag;

	public delegate void OnUpCallback ();

	public OnUpCallback OnUp;

	public enum TouchType
	{
		DOWN = 0,
		DRAG,
		UP,
		NONE
	}

	public Vector2 startPosition;
	public Vector2 dragPosition;
	public Vector2 endPosition;

	[SerializeField]
	public TouchType touchType;
	// Use this for initialization
	void Start ()
	{
		isPhone = IsTouchPhone ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isPhone) {
			if (Input.touchCount > 0) {
				Touch touch = Input.touches [0];
				TouchPhase p = touch.phase;
				if (p == TouchPhase.Began) {
					touchType = TouchType.DOWN;
					startPosition = touch.position;
				} else if (p == TouchPhase.Moved || p == TouchPhase.Stationary) {
					touchType = TouchType.DRAG;
					dragPosition = touch.position;
				} else if (p == TouchPhase.Canceled || p == TouchPhase.Ended) {
					touchType = TouchType.UP;
					endPosition = touch.position;
				} else {
					touchType = TouchType.NONE;
				}
			}
		} else {
			if (Input.GetMouseButtonDown (0)) {
				touchType = TouchType.DOWN;
				startPosition = Input.mousePosition;
			} else if (Input.GetMouseButton (0)) {
				touchType = TouchType.DRAG;
				dragPosition = Input.mousePosition;
			} else if (Input.GetMouseButtonUp (0)) {
				touchType = TouchType.UP;
				endPosition = Input.mousePosition; 
			} else {
				touchType = TouchType.NONE;
			}
		}

		if (touchType == TouchType.DOWN) {
			if (OnDown != null) {
				OnDown ();
			}
		} else if (touchType == TouchType.DRAG) {
			if (OnDrag != null) {
				OnDrag ();
			}
		} else if (touchType == TouchType.UP) {
			if (OnUp != null) {
				OnUp ();
			}
		}
	}

	private bool IsTouchPhone ()
	{
		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) {
			return true;
		} else {
			return false;
		}
	}
}
