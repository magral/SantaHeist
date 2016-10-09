using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandController : MonoBehaviour {

	[SerializeField]
	private Image _progress;
	[SerializeField]
	private Image _completion;

	private int _score;

	void Awake()
	{
		_score = 0;
		//Cursor.visible = false;

	}

	void Update()
	{
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		this.transform.position = mousePosition;

		if (Input.GetMouseButtonDown(0))
		{
			this.GetComponent<SpriteRenderer>().enabled = false;
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
			if (hit.collider != null && hit.collider.gameObject.GetComponent<StockingControl>() != null)
			{
				_completion.fillAmount += .1f;
				_progress.fillAmount += .1f;
				_score++;
			}
			else if(hit.collider != null && hit.collider.gameObject.tag == "Respawn")
			{
				this.GetComponent<SpriteRenderer>().enabled = true;
			}
			else
			{
				_progress.fillAmount -= .33f;
				_score--;
			}

		}
		if (_score == 10)
		{
			OverworldControl.Instance.TransitionState(OverworldControl.GameState.Game5);
			SceneManager.LoadScene("OverworldMap");
		}
		else if (_progress.fillAmount <= .1f)
		{
			Debug.Log("you lose");
			OverworldControl.Instance.TransitionState(OverworldControl.GameState.Game5);
			SceneManager.LoadScene("OverworldMap");
		}
	}


}
