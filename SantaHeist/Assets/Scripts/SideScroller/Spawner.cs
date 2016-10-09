using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	[SerializeField]
	private GameObject _obstacle;
	private Rect _cameraRect;
	private float _spawnTime;
	private float _countdown;

	void Awake () {
		_spawnTime = Time.time + 1.5f;

		Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
		Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(
			Camera.main.pixelWidth, Camera.main.pixelHeight));

		_cameraRect = new Rect(
			bottomLeft.x,
			bottomLeft.y,
			topRight.x - bottomLeft.x,
			topRight.y - bottomLeft.y);

	}
	
	void Update () {
		_countdown = _spawnTime - Time.time;
		if(_countdown <= 0)
		{
			GameObject spawned = SpawnObject(_cameraRect);
			spawned.GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0);
			_spawnTime += _spawnTime;
		}
	}

	public GameObject SpawnObject(Rect _camera)
	{
		return (GameObject) Instantiate(_obstacle, new Vector2(_camera.xMax, Random.Range(_camera.yMin, _camera.yMax)), Quaternion.identity) ;
	}
}
