using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	[SerializeField]
	private GameObject _obstacle;
	private Rect cameraRect;
    [SerializeField]
	private float _spawnTime;
	private float _countdown;

    void Awake()
    {
        _countdown = _spawnTime;
    }
	
	void Update () {

        CameraPostion();


        _countdown -= Time.deltaTime;
		if(_countdown <= 0)
		{
			GameObject spawned = SpawnObject(cameraRect);
			spawned.GetComponent<Rigidbody2D>().velocity = new Vector2(-3, 0);
			_countdown = _spawnTime;
		}
	}

	public GameObject SpawnObject(Rect _camera)
	{
		return (GameObject) Instantiate(_obstacle, new Vector3(_camera.xMax, Random.Range(_camera.yMin, _camera.yMax)), Quaternion.identity) ;
	}

    void CameraPostion()
    {
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight));

        cameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y);
    }
}
