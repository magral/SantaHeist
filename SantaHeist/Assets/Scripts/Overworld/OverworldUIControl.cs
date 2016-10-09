using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OverworldUIControl : MonoBehaviour {

	public void CheckState(int button)
	{
		switch (button)
		{
			case 0:
				if (OverworldControl.Instance.State == OverworldControl.GameState.Game1)
				{
					SceneManager.LoadScene("workbench_fillSleigh");
				}
				break;
			case 1:
				if (OverworldControl.Instance.State == OverworldControl.GameState.Game2)
				{
					SceneManager.LoadScene("SideScroller");
				}
				break;
			case 2:
				if (OverworldControl.Instance.State == OverworldControl.GameState.Game3)
				{
					SceneManager.LoadScene("workbench_backup");
				}
				break;
			case 3:
				if (OverworldControl.Instance.State == OverworldControl.GameState.Game4)
				{
					SceneManager.LoadScene("workbench_Stocking");
				}
				break;
			case 4:
				if (OverworldControl.Instance.State == OverworldControl.GameState.Game5)
				{
					SceneManager.LoadScene("");
				}
				break;
			case 5:
				if (OverworldControl.Instance.State == OverworldControl.GameState.Game6)
				{
					SceneManager.LoadScene("");
				}
				break;
			default:
				Debug.LogWarning("Button number went wrong");
				break;
		}
	}
}
