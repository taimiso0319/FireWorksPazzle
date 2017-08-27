using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager :  SingletonMonoBehaviour<PanelManager>
{
	const int PANEL_NUM_X = 5;
	const int PANEL_NUM_Y = 5;
	private Panel[,] panels = new Panel [PANEL_NUM_X, PANEL_NUM_Y];

	[SerializeField]
	private Pool[] panelPools = new Pool[5];

	[ContextMenu ("ResetPanels")]
	public void ResetPanels ()
	{
		for (int i = 0; i < PANEL_NUM_X; i++) {
			for (int j = 0; j < PANEL_NUM_Y; j++) {
				InsertPanel (i, j);
			}
		}
	}

	public void InsertPanel (int x, int y)
	{
		int randomPanelType = Random.Range (0, 5);
		GameObject tmpPanel = panelPools [randomPanelType].GetInstance ();
		panels [x, y] = tmpPanel.GetComponent <Panel> ();
		tmpPanel.transform.position = new Vector3 (-2 + x, 0 - y, 0);
	}



	[SerializeField, Tooltip ("テスト用の変数だよ")]
	private Vector2 vec;

	[ContextMenu ("TestInsert")]
	private void TestInsert ()
	{
		InsertPanel ((int)vec.x, (int)vec.y);
	}
}
