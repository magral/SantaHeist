using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour {

	public void OnCollisionEnter2D(Collision2D other)
	{
		if(other.transform.GetComponent<Sleigh_Controller>() != null)
		{
			Debug.Log("Got hit by a Bird you lose");
			Destroy(this.gameObject);
			Destroy(other.gameObject);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
