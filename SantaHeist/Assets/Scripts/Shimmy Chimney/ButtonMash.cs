using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonMash : MonoBehaviour {

	[SerializeField]
	private Image _buttonQ;
	[SerializeField]
	private Image _buttonW;
	[SerializeField]
	private Image _progressBar;
	[SerializeField]
	private Text _timeText;
	[SerializeField]
	private Animator _anim;

	public enum Keys
	{
		W,
		Q
	}

	private Keys _key;
	private Keys _nextKey;
	private int _timeLimit;
	private int _timeLeft;


	void Awake()
	{
		_nextKey = Keys.Q;
		_timeLimit = (int) Time.time + 11;
	}

	public void TransitionState(Keys nextKey)
	{
		_key = nextKey;
	}

	void Update()
	{
		if (_progressBar.fillAmount == 1)
		{
			Debug.Log("Player won");
			OverworldControl.Instance.TransitionState(OverworldControl.GameState.Game4);
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			_key = Keys.Q;
			if(_key == _nextKey)
			{
				//Corect
				_key = _nextKey;
				if(_nextKey == Keys.Q)
				{
					_anim.Play("santa_down");
					_buttonQ.color = Color.grey;
					_buttonW.color = Color.white;
					_nextKey = Keys.W;
					_progressBar.fillAmount += .01f;
				}
				else
				{
					_anim.Play("santa_up");
					_buttonQ.color = Color.white;
					_buttonW.color = Color.grey;
					_nextKey = Keys.Q;
				}
			}
			else
			{
				_anim.Play("santa_down");
			}
		}
		else if (Input.GetKeyDown(KeyCode.W))
		{
			_key = Keys.W;
			if (_key == _nextKey)
			{
				//Corect
				_key = _nextKey;
				if (_nextKey == Keys.W)
				{
					_anim.Play("santa_up");
					_buttonQ.color = Color.white;
					_buttonW.color = Color.grey;
					_nextKey = Keys.Q;
					_progressBar.fillAmount += .01f;
				}
				else
				{
					_anim.Play("santa_down");
					_buttonQ.color = Color.grey;
					_buttonW.color = Color.white;
					_nextKey = Keys.W;
				}
			}
			else
			{
				_anim.Play("santa_down");
			}

		}
		_timeLeft = (int) (_timeLimit - Time.time);
		_timeText.text = (_timeLeft).ToString();
		if(_timeLeft <= 0)
		{
			//Game end and lost
			OverworldControl.Instance.TransitionState(OverworldControl.GameState.Game4);
		}
	}
}
