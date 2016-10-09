using UnityEngine;
using System.Collections;

public class HandController : MonoBehaviour {



	void Update()
	{
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		this.transform.position = mousePosition;

		if (Input.GetMouseButtonDown(0))
		{
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
			if (hit.collider != null && hit.collider.gameObject.GetComponent<StockingControl>() != null)
			{
				//Hit stocking;
				Debug.Log("Hit stocking");
			}
		}
	}


}
