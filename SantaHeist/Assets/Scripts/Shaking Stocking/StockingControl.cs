﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StockingControl : MonoBehaviour {

	[SerializeField]
	private Transform _target1;
	[SerializeField]
	private Transform _target2;

	private Rigidbody2D _rb;
	private List<Vector2> points;
	private int _start;
	private int _currentScore;
	
	void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		points = new List<Vector2>();
		points.Add(new Vector2(_target1.position.x, _target1.position.y));
		points.Add(new Vector2(_target2.position.x, _target2.position.y));
		_start = 0;
		_currentScore = 0;
	}

	void Update()
	{
		_start = PathFollow(_rb, points, _start, 4, 8, 16);
		if(_start > 1)
		{
			_start = 0;
		}
	}
	public int PathFollow(Rigidbody2D character, List<Vector2> Path, int index, float maxVelocity, float accel, float maxAccel)
	{
		float distance = DynamicArrive(Path[index], character, maxVelocity, accel, maxAccel);
		if (distance <= .05f)
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
		//dv = dv.normalized * Mathf.Min(dv.magnitude * acceleration, maxAccel);
		rb.AddForce(dv * rb.mass, ForceMode2D.Force);
	}
	
}
