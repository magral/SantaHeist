using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverworldControl : MonoBehaviour {
	
	public enum GameState
	{
		Game1,
		Game2,
		Game3,
		Game4,
		Game5,
		Game6,
		GameEnd
	}

	private static OverworldControl _instance = null;
	private GameState _state;

	public static OverworldControl Instance
	{
		get { return _instance; }
	}

	public GameState State
	{
		get { return _state; }
	}

	void Awake()
	{
		if(_instance == null)
		{
			_instance = this;
		}
		else if(_instance != this)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this.gameObject);
		_state = GameState.Game1;
	}
	/*
	public void CheckState(int button)
	{
		switch (button)
		{
			case 0:
				if (_state == GameState.Game1)
				{
					SceneManager.LoadScene("workbench_fillSleigh");
				}
				break;
			case 1:
				if(_state == GameState.Game2)
				{
					SceneManager.LoadScene("SideScroller");
				}
				break;
			case 2:
				if(_state == GameState.Game3)
				{
					SceneManager.LoadScene("workbench_backup");
				}
				break;
			case 3:
				if(_state == GameState.Game4)
				{
					SceneManager.LoadScene("workbench_Stocking");
				}
				break;
			case 4:
				if(_state == GameState.Game5)
				{
					SceneManager.LoadScene("");
				}
				break;
			case 5:
				if(_state == GameState.Game6)
				{
					SceneManager.LoadScene("");
				}
				break;
			default:
				Debug.LogWarning("Button number went wrong");
				break;
		}
	}*/

	public void TransitionState(GameState newState)
	{
		_state = newState;
	}
}
