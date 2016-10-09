using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SackController : MonoBehaviour {

	[SerializeField]
	private float _movementSpeed;

	private Rigidbody2D _rb;
	private Rect _cameraRect;

	private int _score;

	void Awake()
	{
		_score = 0;
		_rb = GetComponent<Rigidbody2D>();
		Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
		Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(
			Camera.main.pixelWidth, Camera.main.pixelHeight));

		_cameraRect = new Rect(
			bottomLeft.x,
			bottomLeft.y,
			topRight.x - bottomLeft.x,
			topRight.y - bottomLeft.y);
	}

	void Update()
	{
		_rb.velocity = new Vector2(Input.GetAxis("Horizontal") * _movementSpeed, 0);
		transform.position = new Vector3(
		 Mathf.Clamp(transform.position.x , _cameraRect.xMin, _cameraRect.xMax),
		 Mathf.Clamp(transform.position.y, _cameraRect.yMin, _cameraRect.yMax),
		 transform.position.z);
		if(_score == 10)
		{
			OverworldControl.Instance.TransitionState(OverworldControl.GameState.Game2);
			SceneManager.LoadScene("OverworldMap");
			Debug.Log("YOU WIN");
		}

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		_score += 1;
		Destroy(other.gameObject);
	}

}
