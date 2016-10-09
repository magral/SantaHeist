using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	[SerializeField]
	private float _speed;
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2(Time.time * _speed, 0);

		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}
}
