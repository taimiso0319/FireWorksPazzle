using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour
{
	Panel grabedPanel;
	// Use this for initialization
	void Start ()
	{
		TouchManager.Instance.OnDrag = DragOnPanel;
		TouchManager.Instance.OnUp = UpOnPanel;
	}

	private void DragOnPanel ()
	{
		RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (TouchManager.Instance.dragPosition), Vector2.zero);
		if (hit.collider != null) {
			Debug.Log ("test");
			Debug.Log (hit.collider.name);
		}
	}

	private void UpOnPanel ()
	{
		RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (TouchManager.Instance.endPosition), Vector2.zero);
		if (hit.collider != null) {
			hit.collider.gameObject.GetComponent <Panel> ().RotateRight ();
		}
	}

}
