using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Control : MonoBehaviour {

	[SerializeField]
	private Image parent;
	[SerializeField]
	private InputField input;

	private List<Text> texts;
	private Text _currentText;
	private int _currentIndex;
	private string _currentString;


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
		
	}

	void Start()
	{
		input.Select();
		input.ActivateInputField();
	}

	public void Compare(InputField field)
	{
		if(field.text.Trim().Equals( _currentString.Trim()))
		{
			Debug.Log("correct");
			UpdateText();
			field.Select();
			field.text = "";
			field.ActivateInputField();
		}
		else
		{
			Debug.Log(field.text);
			Debug.Log("incorrect");
		}
	}

	public void UpdateText()
	{
		_currentText.color = Color.black;
		_currentText = texts[_currentIndex++];
		_currentString = _currentText.text;
		_currentText.color = Color.yellow;
	}
}
