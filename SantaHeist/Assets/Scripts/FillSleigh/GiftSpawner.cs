using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GiftSpawner : MonoBehaviour {

	[SerializeField]
	private Transform _drop1;
	[SerializeField]
	private Transform _drop2;
	[SerializeField]
	private Transform _drop3;
	[SerializeField]
	private GameObject gift;

	[SerializeField]
	private float KillZ;

	private float _dropTime;
	private float _timeTilDrop;
	private GameObject instGift;

	void Awake()
	{
		_dropTime = Time.time + 1f;


	}

	void Update()
	{
		_timeTilDrop = _dropTime - Time.time;
		if(_timeTilDrop <= 0)
		{
			instGift = SpawnPresent(_drop1, _drop2, _drop3);
			_dropTime += 2;

		}
		if (instGift != null && instGift.transform.position.y < KillZ)
		{
			Destroy(instGift.gameObject);
		}
	}
	public GameObject SpawnPresent(Transform p1, Transform p2, Transform p3)
	{
		List <Transform> locations = new List<Transform>();
		locations.Add(p1);
		locations.Add(p2);
		locations.Add(p3);
		int i = Random.Range(0, 2);
		Transform location = locations[i];
		return (GameObject) Instantiate(gift, location.position, Quaternion.identity);
	}

}
