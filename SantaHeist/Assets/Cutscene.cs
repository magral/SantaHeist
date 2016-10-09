using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour {

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			SceneManager.LoadScene("OverworldMap");
		}
	}
}
