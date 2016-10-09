using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public void OnCollisionEnter2D(Collision2D other)
	{
		if(other.transform.GetComponent<SleighController>() != null)
		{
			Debug.Log("Got hit by a pepper you lose");
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}
	}
}
