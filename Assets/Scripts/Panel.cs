using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Panel : MonoBehaviour
{

	public bool hasUpConnection;
	public bool hasRightConnection;
	public bool hasDownConnection;
	public bool hasLeftConnection;

	public bool isUpConnected;
	public bool isRightConnected;
	public bool isDownConnected;
	public bool isLeftConnected;

	public Panel upPanel;
	public Panel rightPanel;
	public Panel downPanel;
	public Panel leftPanel;

	[ContextMenu ("RotateRight")]
	public void RotateRight ()
	{
		bool tmp = hasUpConnection;
		hasUpConnection = hasLeftConnection;
		hasLeftConnection = hasDownConnection;
		hasDownConnection = hasRightConnection;
		hasRightConnection = tmp;
		this.gameObject.transform.DORotate (new Vector3 (0, 0, this.transform.rotation.eulerAngles.z - 90.0f), 0f, RotateMode.Fast);
		CheckConnection ();
	}

	[ContextMenu ("RotateLeft")]
	public void RotateLeft ()
	{
		bool tmp = hasUpConnection;
		hasUpConnection = hasRightConnection;
		hasRightConnection = hasDownConnection;
		hasDownConnection = hasLeftConnection;
		hasLeftConnection = tmp;
		this.gameObject.transform.DORotate (new Vector3 (0, 0, this.transform.rotation.eulerAngles.z + 90.0f), 0f, RotateMode.Fast);
		CheckConnection ();
	}

	private void InitIsConnected ()
	{
		isUpConnected = false;
		isRightConnected = false;
		isDownConnected = false;
		isLeftConnected = false;
	}

	public void CheckConnection ()
	{
		InitIsConnected ();
		if (hasUpConnection) {
			if (upPanel != null) {
				if (upPanel.hasDownConnection) {
					isUpConnected = true;
				}
			}
		}
		if (hasRightConnection) {
			if (rightPanel != null) {
				if (rightPanel.hasLeftConnection) {
					isRightConnected = true;
				}
			}
		}
		if (hasDownConnection) {
			if (downPanel != null) {
				if (downPanel.hasUpConnection) {
					isDownConnected = true;
				}
			}
		}
		if (hasLeftConnection) {
			if (leftPanel != null) {
				if (leftPanel.hasRightConnection) {
					isLeftConnected = true;
				}
			}
		}
	}
}
