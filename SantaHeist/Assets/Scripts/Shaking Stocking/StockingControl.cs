using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StockingControl : MonoBehaviour {

	[SerializeField]
	private Transform _target1;
	[SerializeField]
	private Transform _target2;
	[SerializeField]
	private float _speed;
	[SerializeField]
	private float _acceleration;
	[SerializeField]
	private float _maxAcceleration;

	private Rigidbody2D _rb;
	private List<Vector2> points;
	private int _start;
	
	void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		points = new List<Vector2>();
		points.Add(new Vector2(_target1.position.x, _target1.position.y));
		points.Add(new Vector2(_target2.position.x, _target2.position.y));
		_start = 0;
	}

	void Update()
	{
		_start = PathFollow(_rb, points, _start, _speed, _acceleration, _maxAcceleration);
		if(_start > 1)
		{
			_start = 0;
			points[0] = (new Vector2((Random.Range(_target1.position.x, _target2.position.x)), _target1.position.y));
			points[1] = (new Vector2((Random.Range(_target1.position.x, _target2.position.x)), _target2.position.y));
		}
	}
	public int PathFollow(Rigidbody2D character, List<Vector2> Path, int index, float _speed, float accel, float maxAccel)
	{
		Vector2 dir = (Path[index] - character.position).normalized * _speed;
		character.velocity = dir;
		float distance = Mathf.Abs(Vector2.Distance(character.position, Path[index]));
		if (distance <= .1f)
		{
			index++;
		}
		return index;
	}

	public float DynamicArrive(Vector2 targetpos, Rigidbody2D rb, float maxVelocity, float acceleration, float maxAccel)
	{
		Vector2 targetDis = targetpos - rb.position;

		AccelerateClamped(targetDis, rb, acceleration, maxAccel);
		float dis = Mathf.Abs(Vector2.Distance(rb.position, targetpos));
		return dis;
	}

	public void AccelerateClamped(Vector2 target, Rigidbody2D rb, float acceleration, float maxAccel)
	{
		Vector2 dv = target - rb.velocity;
		rb.AddForce(dv * rb.mass, ForceMode2D.Force);
	}
	
}
