using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour {

	[SerializeField]
	private Image parent;
	[SerializeField]
	private InputField input;
	[SerializeField]
	private Text timeLeft;

	//Present Spawn Points
	[SerializeField]
	private Transform _present1;
	[SerializeField]
	private Transform _present2;
	[SerializeField]
	private Transform _present3;
	[SerializeField]
	private Transform _present4;
	[SerializeField]
	private Transform _present5;


	private List<Text> texts;
	private Text _currentText;
	private int _currentIndex;
	private string _currentString;
	private int _count;

	private float _timeLimit;
	private float _timeLeft;

	void Awake()
	{
		texts = new List<Text>();
		for(int i = 0; i < parent.transform.childCount; i++)
		{
			texts.Add(parent.transform.GetChild(i).GetComponent<Text>());
		}

		input.onEndEdit.AddListener(delegate { Compare(input); });

		_currentIndex = 0;
		_currentText = texts[_currentIndex];
		_currentString = _currentText.text;
		_currentText.color = Color.yellow;
		UpdateText();
		_timeLimit = Time.time + 12f;		
	}

	void Start()
	{
		input.Select();
		input.ActivateInputField();
	}

	void Update()
	{
		_timeLeft = _timeLimit - Time.time;
		timeLeft.text = ((int)_timeLeft).ToString();
		if(_timeLeft <= 0 )
		{
			EvaluateGame();
		}
	}
	public void Compare(InputField field)
	{
		if(field.text.Trim().ToLower().Equals( _currentString.Trim().ToLower()))
		{
			Debug.Log("correct");
			_count++;
			switch (_currentIndex)
			{
				case 1:
					_present1.GetComponent<SpriteRenderer>().enabled = true;
					break;
				case 2:
					_present2.GetComponent<SpriteRenderer>().enabled = true;
					break;
				case 3:
					_present3.GetComponent<SpriteRenderer>().enabled = true;
					break;
				case 4:
					_present4.GetComponent<SpriteRenderer>().enabled = true;
					break;
				case 5:
					_present5.GetComponent<SpriteRenderer>().enabled = true;
					break;
			}
			UpdateText();
			field.Select();
			field.text = "";
			field.ActivateInputField();
			
			
		}
		else
		{
			UpdateText();
			field.Select();
			field.text = "";
			field.ActivateInputField();
		}
	}

	public void UpdateText()
	{
		_currentText.color = Color.black;
		if (_currentIndex + 1 <= texts.Count)
		{
			_currentText = texts[_currentIndex++];
			_currentString = _currentText.text;
			_currentText.color = Color.yellow;
		}
		else
		{
			EvaluateGame();
		}
	}

	public void EvaluateGame()
	{
		if (_count == 5)
		{
			OverworldControl.Instance.TransitionState(OverworldControl.GameState.GameEnd);
			Debug.Log("WON");
		}
		else
		{
			SceneManager.LoadScene("OverworldMap");
			Debug.Log("LOSE");
		}
	}
}
