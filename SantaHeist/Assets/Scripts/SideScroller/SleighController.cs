using UnityEngine;
using System.Collections;

public class SleighController : MonoBehaviour {

	[SerializeField]
	private float _movementSpeed;
	private Rigidbody2D _rb;

	private Rect _cameraRect;

	void Awake()
	{
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

	void Update () {
		_rb.velocity = new Vector2(Input.GetAxis("Horizontal") * _movementSpeed , Input.GetAxis("Vertical") * _movementSpeed );
		transform.position = new Vector3(
		 Mathf.Clamp(transform.position.x, _cameraRect.xMin + Mathf.Abs(_cameraRect.xMin / 4), _cameraRect.xMax - Mathf.Abs(_cameraRect.xMax / 4)),
		 Mathf.Clamp(transform.position.y, _cameraRect.yMin - (_cameraRect.yMin / 4), _cameraRect.yMax - Mathf.Abs(_cameraRect.yMax / 4)),
		 transform.position.z);
	}
}
