using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HandController : MonoBehaviour {

	private int _score;

	void Awake()
	{
		_score = 0;
	}

	void Update()
	{
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		this.transform.position = mousePosition;

		if (Input.GetMouseButtonDown(0))
		{
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
			if (hit.collider != null && hit.collider.gameObject.GetComponent<StockingControl>() != null)
			{
				_score++;
			}
			else
			{
				_score--;
			}
		}
		if(_score == 10)
		{
			OverworldControl.Instance.TransitionState(OverworldControl.GameState.Game5);
			SceneManager.LoadScene("OverworldMap");
		}
	}


}
